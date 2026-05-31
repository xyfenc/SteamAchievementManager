/* Copyright (c) 2024 Rick (rick 'at' gibbed 'dot' us)
 *
 * This software is provided 'as-is', without any express or implied
 * warranty. In no event will the authors be held liable for any damages
 * arising from the use of this software.
 *
 * Permission is granted to anyone to use this software for any purpose,
 * including commercial applications, and to alter it and redistribute it
 * freely, subject to the following restrictions:
 *
 * 1. The origin of this software must not be misrepresented; you must not
 *    claim that you wrote the original software. If you use this software
 *    in a product, an acknowledgment in the product documentation would
 *    be appreciated but is not required.
 *
 * 2. Altered source versions must be plainly marked as such, and must not
 *    be misrepresented as being the original software.
 *
 * 3. This notice may not be removed or altered from any source
 *    distribution.
 */

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.XPath;
using SAM.Picker.Theme;
using static SAM.Picker.InvariantShorthand;
using APITypes = SAM.API.Types;

namespace SAM.Picker
{
    internal partial class GamePicker : Form
    {
        private readonly API.Client _SteamClient;

        private readonly Dictionary<uint, GameInfo> _Games;
        private readonly List<GameInfo> _FilteredGames;

        private readonly object _LogoLock;
        private readonly HashSet<string> _LogosAttempting;
        private readonly HashSet<string> _LogosAttempted;
        private readonly ConcurrentQueue<GameInfo> _LogoQueue;

        private readonly API.Callbacks.AppDataChanged _AppDataChangedCallback;

        public GamePicker(API.Client client)
        {
            this._Games = new();
            this._FilteredGames = new();
            this._LogoLock = new();
            this._LogosAttempting = new();
            this._LogosAttempted = new();
            this._LogoQueue = new();

            this.InitializeComponent();

            // Placeholder tile used before the real capsule art downloads
            Bitmap blank = new(this._LogoImageList.ImageSize.Width, this._LogoImageList.ImageSize.Height);
            using (var g = Graphics.FromImage(blank))
            {
                g.Clear(AppTheme.BgSurface);
            }

            this._LogoImageList.Images.Add("Blank", blank);

            this._SteamClient = client;

            this._AppDataChangedCallback = client.CreateAndRegisterCallback<API.Callbacks.AppDataChanged>();
            this._AppDataChangedCallback.OnRun += this.OnAppDataChanged;

            this.AddGames();
        }

        private void OnAppDataChanged(APITypes.AppDataChanged param)
        {
            if (param.Result == false)
            {
                return;
            }

            if (this._Games.TryGetValue(param.Id, out var game) == false)
            {
                return;
            }

            game.Name = this._SteamClient.SteamApps001.GetAppData(game.Id, "name");

            this.AddGameToLogoQueue(game);
            this.DownloadNextLogo();
        }

        private void DoDownloadList(object sender, DoWorkEventArgs e)
        {
            this._PickerStatusLabel.Text = "Downloading game list...";

            byte[] bytes;
            using (WebClient downloader = new())
            {
                bytes = downloader.DownloadData(new Uri("https://gib.me/sam/games.xml"));
            }

            List<KeyValuePair<uint, string>> pairs = new();
            using (MemoryStream stream = new(bytes, false))
            {
                XPathDocument document = new(stream);
                var navigator = document.CreateNavigator();
                var nodes = navigator.Select("/games/game");
                while (nodes.MoveNext() == true)
                {
                    string type = nodes.Current.GetAttribute("type", "");
                    if (string.IsNullOrEmpty(type) == true)
                    {
                        type = "normal";
                    }
                    pairs.Add(new((uint)nodes.Current.ValueAsLong, type));
                }
            }

            this._PickerStatusLabel.Text = "Checking game ownership...";
            foreach (var kv in pairs)
            {
                this.AddGame(kv.Key, kv.Value);
            }
        }

        private void OnDownloadList(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null || e.Cancelled == true)
            {
                this.AddDefaultGames();
                MessageBox.Show(e.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.RefreshGames();
            this._RefreshGamesButton.Enabled = true;
            this.DownloadNextLogo();
        }

        private void RefreshGames()
        {
            var nameSearch = this._SearchGameTextBox.Text.Length > 0
                ? this._SearchGameTextBox.Text
                : null;

            var wantNormals = this._FilterGamesButton.Checked == true;
            var wantDemos = this._FilterDemosButton.Checked == true;
            var wantMods = this._FilterModsButton.Checked == true;
            var wantJunk = this._FilterJunkButton.Checked == true;

            this._FilteredGames.Clear();
            foreach (var info in this._Games.Values.OrderBy(gi => gi.Name))
            {
                if (nameSearch != null &&
                    info.Name.IndexOf(nameSearch, StringComparison.OrdinalIgnoreCase) < 0)
                {
                    continue;
                }

                bool wanted = info.Type switch
                {
                    "normal" => wantNormals,
                    "demo" => wantDemos,
                    "mod" => wantMods,
                    "junk" => wantJunk,
                    _ => true,
                };
                if (wanted == false)
                {
                    continue;
                }

                this._FilteredGames.Add(info);
            }

            this._GameListView.VirtualListSize = this._FilteredGames.Count;
            this._PickerStatusLabel.Text =
                $"Displaying {this._GameListView.Items.Count} games. Total {this._Games.Count} games.";

            if (this._GameListView.Items.Count > 0)
            {
                this._GameListView.Items[0].Selected = true;
                this._GameListView.Select();
            }
        }

        private void OnGameListViewRetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            var info = this._FilteredGames[e.ItemIndex];
            e.Item = info.Item = new()
            {
                Text = info.Name,
                ImageIndex = info.ImageIndex,
            };
        }

        private void OnGameListViewSearchForVirtualItem(object sender, SearchForVirtualItemEventArgs e)
        {
            if (e.Direction != SearchDirectionHint.Down || e.IsTextSearch == false)
            {
                return;
            }

            var count = this._FilteredGames.Count;
            if (count < 2)
            {
                return;
            }

            var text = e.Text;
            int startIndex = e.StartIndex;

            Predicate<GameInfo> predicate;
            /*if (e.IsPrefixSearch == true)*/
            {
                predicate = gi => gi.Name != null && gi.Name.StartsWith(text, StringComparison.CurrentCultureIgnoreCase);
            }
            /*else
            {
                predicate = gi => gi.Name != null && string.Compare(gi.Name, text, StringComparison.CurrentCultureIgnoreCase) == 0;
            }*/

            int index;
            if (e.StartIndex >= count)
            {
                // starting from the last item in the list
                index = this._FilteredGames.FindIndex(0, startIndex - 1, predicate);
            }
            else if (startIndex <= 0)
            {
                // starting from the first item in the list
                index = this._FilteredGames.FindIndex(0, count, predicate);
            }
            else
            {
                index = this._FilteredGames.FindIndex(startIndex, count - startIndex, predicate);
                if (index < 0)
                {
                    index = this._FilteredGames.FindIndex(0, startIndex - 1, predicate);
                }
            }

            e.Index = index < 0 ? -1 : index;
        }

        private void DoDownloadLogo(object sender, DoWorkEventArgs e)
        {
            var info = (GameInfo)e.Argument;

            this._LogosAttempted.Add(info.ImageUrl);

            using (WebClient downloader = new())
            {
                try
                {
                    var data = downloader.DownloadData(new Uri(info.ImageUrl));
                    using (MemoryStream stream = new(data, false))
                    {
                        Bitmap bitmap = new(stream);
                        e.Result = new LogoInfo(info.Id, bitmap);
                    }
                }
                catch (Exception)
                {
                    e.Result = new LogoInfo(info.Id, null);
                }
            }
        }

        private void OnDownloadLogo(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null || e.Cancelled == true)
            {
                return;
            }

            if (e.Result is LogoInfo logoInfo &&
                logoInfo.Bitmap != null &&
                this._Games.TryGetValue(logoInfo.Id, out var gameInfo) == true)
            {
                this._GameListView.BeginUpdate();
                var imageIndex = this._LogoImageList.Images.Count;
                this._LogoImageList.Images.Add(gameInfo.ImageUrl, logoInfo.Bitmap);
                gameInfo.ImageIndex = imageIndex;
                this._GameListView.EndUpdate();
            }

            this.DownloadNextLogo();
        }

        private void DownloadNextLogo()
        {
            lock (this._LogoLock)
            {

                if (this._LogoWorker.IsBusy == true)
                {
                    return;
                }

                GameInfo info;
                while (true)
                {
                    if (this._LogoQueue.TryDequeue(out info) == false)
                    {
                        this._DownloadStatusLabel.Visible = false;
                        return;
                    }

                    if (info.Item == null)
                    {
                        continue;
                    }

                    if (this._FilteredGames.Contains(info) == false ||
                        info.Item.Bounds.IntersectsWith(this._GameListView.ClientRectangle) == false)
                    {
                        this._LogosAttempting.Remove(info.ImageUrl);
                        continue;
                    }

                    break;
                }

                this._DownloadStatusLabel.Text = $"Downloading {1 + this._LogoQueue.Count} game icons...";
                this._DownloadStatusLabel.Visible = true;

                this._LogoWorker.RunWorkerAsync(info);
            }
        }

        private string GetGameImageUrl(uint id)
        {
            string candidate;

            var currentLanguage = this._SteamClient.SteamApps008.GetCurrentGameLanguage();

            candidate = this._SteamClient.SteamApps001.GetAppData(id, _($"small_capsule/{currentLanguage}"));
            if (string.IsNullOrEmpty(candidate) == false)
            {
                return _($"https://shared.cloudflare.steamstatic.com/store_item_assets/steam/apps/{id}/{candidate}");
            }

            if (currentLanguage != "english")
            {
                candidate = this._SteamClient.SteamApps001.GetAppData(id, "small_capsule/english");
                if (string.IsNullOrEmpty(candidate) == false)
                {
                    return _($"https://shared.cloudflare.steamstatic.com/store_item_assets/steam/apps/{id}/{candidate}");
                }
            }

            candidate = this._SteamClient.SteamApps001.GetAppData(id, "logo");
            if (string.IsNullOrEmpty(candidate) == false)
            {
                return _($"https://cdn.steamstatic.com/steamcommunity/public/images/apps/{id}/{candidate}.jpg");
            }

            return null;
        }

        private void AddGameToLogoQueue(GameInfo info)
        {
            if (info.ImageIndex > 0)
            {
                return;
            }

            var imageUrl = GetGameImageUrl(info.Id);
            if (string.IsNullOrEmpty(imageUrl) == true)
            {
                return;
            }

            info.ImageUrl = imageUrl;

            int imageIndex = this._LogoImageList.Images.IndexOfKey(imageUrl);
            if (imageIndex >= 0)
            {
                info.ImageIndex = imageIndex;
            }
            else if (
                this._LogosAttempting.Contains(imageUrl) == false &&
                this._LogosAttempted.Contains(imageUrl) == false)
            {
                this._LogosAttempting.Add(imageUrl);
                this._LogoQueue.Enqueue(info);
            }
        }

        private bool OwnsGame(uint id)
        {
            return this._SteamClient.SteamApps008.IsSubscribedApp(id);
        }

        private void AddGame(uint id, string type)
        {
            if (this._Games.ContainsKey(id) == true)
            {
                return;
            }

            if (this.OwnsGame(id) == false)
            {
                return;
            }

            GameInfo info = new(id, type);
            info.Name = this._SteamClient.SteamApps001.GetAppData(info.Id, "name");
            this._Games.Add(id, info);
        }

        private void AddGames()
        {
            this._Games.Clear();
            this._RefreshGamesButton.Enabled = false;
            this._ListWorker.RunWorkerAsync();
        }

        private void AddDefaultGames()
        {
            this.AddGame(480, "normal"); // Spacewar
        }

        private void OnTimer(object sender, EventArgs e)
        {
            this._CallbackTimer.Enabled = false;
            this._SteamClient.RunCallbacks(false);
            this._CallbackTimer.Enabled = true;
        }

        private void OnActivateGame(object sender, EventArgs e)
        {
            if (this._GameListView.SelectedIndices.Count == 0)
            {
                return;
            }
            var index = this._GameListView.SelectedIndices[0];
            if (index < 0 || index >= this._FilteredGames.Count)
            {
                return;
            }

            var info = this._FilteredGames[index];
            if (info == null)
            {
                return;
            }

            try
            {
                Process.Start("SAM.Game.exe", info.Id.ToString(CultureInfo.InvariantCulture));
            }
            catch (Win32Exception)
            {
                MessageBox.Show(
                    this,
                    "Failed to start SAM.Game.exe.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void OnRefresh(object sender, EventArgs e)
        {
            this._AddGameTextBox.Text = "";
            this.AddGames();
        }

        private void OnAddGame(object sender, EventArgs e)
        {
            uint id;

            if (uint.TryParse(this._AddGameTextBox.Text, out id) == false)
            {
                MessageBox.Show(
                    this,
                    "Please enter a valid game ID.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (this.OwnsGame(id) == false)
            {
                MessageBox.Show(this, "You don't own that game.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            while (this._LogoQueue.TryDequeue(out var logo) == true)
            {
                // clear the download queue because we will be showing only one app
                this._LogosAttempted.Remove(logo.ImageUrl);
            }

            this._AddGameTextBox.Text = "";
            this._Games.Clear();
            this.AddGame(id, "normal");
            this._FilterGamesButton.Checked = true;
            this.RefreshGames();
            this.DownloadNextLogo();
        }

        private void OnFilterUpdate(object sender, EventArgs e)
        {
            this.RefreshGames();

            // Compatibility with _GameListView SearchForVirtualItemEventHandler (otherwise _SearchGameTextBox loose focus on KeyUp)
            this._SearchGameTextBox.Focus();
        }

        private void OnGameListViewDrawItem(object sender, DrawListViewItemEventArgs e)
        {
            if (e.Item.Bounds.IntersectsWith(this._GameListView.ClientRectangle) == false)
            {
                return;
            }

            var info = this._FilteredGames[e.ItemIndex];
            if (info.ImageIndex <= 0)
            {
                this.AddGameToLogoQueue(info);
                this.DownloadNextLogo();
            }

            DrawGameTile(e, info);
        }

        /// <summary>
        /// Custom owner-draw rendering for a single game tile in the ListView.
        /// Paints a dark background, game capsule art, a glass gradient overlay,
        /// and the game name in the foreground.
        /// </summary>
        private static void DrawGameTile(DrawListViewItemEventArgs e, GameInfo info)
        {
            var g      = e.Graphics;
            var bounds = e.Bounds;

            g.SmoothingMode     = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            // 1. Background
            Color bgColor;
            if (e.Item.Selected)
            {
                bgColor = AppTheme.BgSelected;
            }
            else if ((e.State & ListViewItemStates.Hot) != 0)
            {
                bgColor = AppTheme.BgHover;
            }
            else
            {
                bgColor = e.ItemIndex % 2 == 0 ? AppTheme.BgSurface : AppTheme.BgDeep;
            }

            using (var bgBrush = new SolidBrush(bgColor))
            {
                g.FillRectangle(bgBrush, bounds);
            }

            // 2. Accent left border on selected
            if (e.Item.Selected)
            {
                using (var accentBrush = new SolidBrush(AppTheme.AccentPrimary))
                {
                    g.FillRectangle(accentBrush, bounds.Left, bounds.Top, 3, bounds.Height);
                }
            }

            // 3. Game capsule image
            const int ImagePadding = 4;
            int imageH = bounds.Height - ImagePadding * 2;
            int imageW = (int)(imageH * (184.0 / 69.0)); // keep capsule aspect ratio
            var imageRect = new Rectangle(bounds.Left + 8, bounds.Top + ImagePadding, imageW, imageH);

            var imageList = (e.Item.ListView as ListView)?.LargeImageList;
            if (imageList != null && e.Item.ImageIndex >= 0 && e.Item.ImageIndex < imageList.Images.Count)
            {
                var img = imageList.Images[e.Item.ImageIndex];
                if (img != null)
                {
                    // Clip to rounded rectangle for the image
                    using (var clipPath = RoundedRect(imageRect, 4))
                    {
                        g.SetClip(clipPath);
                        g.DrawImage(img, imageRect);
                        g.ResetClip();

                        // Glass gradient overlay at the bottom of the image
                        var gradientRect = new Rectangle(imageRect.Left, imageRect.Bottom - 20, imageRect.Width, 20);
                        using (var gradBrush = new LinearGradientBrush(
                            gradientRect,
                            Color.FromArgb(0, bgColor),
                            Color.FromArgb(160, bgColor),
                            LinearGradientMode.Vertical))
                        {
                            g.FillRectangle(gradBrush, gradientRect);
                        }
                    }

                    // Subtle image border
                    using (var borderPen = new Pen(AppTheme.BorderSubtle))
                    {
                        using (var borderPath = RoundedRect(imageRect, 4))
                        {
                            g.DrawPath(borderPen, borderPath);
                        }
                    }
                }
            }

            // 4. Game name text
            int textX   = imageRect.Right + 10;
            int textW   = bounds.Right - textX - 6;
            var textRect = new Rectangle(textX, bounds.Top, textW, bounds.Height);

            Color textColor = e.Item.Selected ? AppTheme.TextPrimary : AppTheme.TextPrimary;
            using (var textBrush = new SolidBrush(textColor))
            {
                var format = new StringFormat
                {
                    Alignment     = StringAlignment.Near,
                    LineAlignment = StringAlignment.Center,
                    Trimming      = StringTrimming.EllipsisCharacter,
                    FormatFlags   = StringFormatFlags.NoWrap,
                };
                g.DrawString(e.Item.Text, AppTheme.FontSemibold, textBrush, textRect, format);
            }

            // 5. Thin bottom separator line
            using (var separatorPen = new Pen(AppTheme.BorderSubtle))
            {
                g.DrawLine(separatorPen, bounds.Left, bounds.Bottom - 1, bounds.Right, bounds.Bottom - 1);
            }
        }

        /// <summary>
        /// Builds a GraphicsPath for a rectangle with uniformly rounded corners.
        /// </summary>
        private static GraphicsPath RoundedRect(Rectangle rect, int radius)
        {
            int d    = radius * 2;
            var path = new GraphicsPath();
            path.AddArc(rect.Left,            rect.Top,             d, d, 180, 90);
            path.AddArc(rect.Right - d,       rect.Top,             d, d, 270, 90);
            path.AddArc(rect.Right - d,       rect.Bottom - d,      d, d, 0,   90);
            path.AddArc(rect.Left,            rect.Bottom - d,      d, d, 90,  90);
            path.CloseFigure();
            return path;
        }

        // ------------------------------------------------------------------ new UI event handlers

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, string lParam);

        private const int EM_SETCUEBANNER = 0x1501;

        /// <summary>
        /// Wires up acrylic blur after the window handle is created, and sets
        /// placeholder cue text on the TextBox controls (net48 compat via EM_SETCUEBANNER).
        /// </summary>
        private void OnFormLoad(object sender, EventArgs e)
        {
            NativeBlur.EnableAcrylic(this);
            SendMessage(this._AddGameTextBox.Handle,    EM_SETCUEBANNER, (IntPtr)1, "App ID");
            SendMessage(this._SearchGameTextBox.Handle, EM_SETCUEBANNER, (IntPtr)1, "Search your library...");
        }

        /// <summary>
        /// Paints a subtle violet-to-transparent gradient glow along the bottom
        /// edge of the header panel, reinforcing the glass effect.
        /// </summary>
        private void OnHeaderPanelPaint(object sender, PaintEventArgs e)
        {
            var g      = e.Graphics;
            var bounds = (sender as System.Windows.Forms.Control).ClientRectangle;

            // Bottom edge separator line
            using (var pen = new Pen(AppTheme.BorderSubtle))
            {
                g.DrawLine(pen, bounds.Left, bounds.Bottom - 1, bounds.Right, bounds.Bottom - 1);
            }

            // Violet glow strip — bottom 2px
            using (var glow = new LinearGradientBrush(
                new Rectangle(bounds.Left, bounds.Bottom - 2, bounds.Width, 2),
                AppTheme.AccentGlow,
                Color.Transparent,
                LinearGradientMode.Horizontal))
            {
                g.FillRectangle(glow, bounds.Left, bounds.Bottom - 2, bounds.Width, 2);
            }
        }

        /// <summary>
        /// Paints the top separator line of the status footer.
        /// </summary>
        private void OnStatusPanelPaint(object sender, PaintEventArgs e)
        {
            var g      = e.Graphics;
            var bounds = (sender as System.Windows.Forms.Control).ClientRectangle;
            using (var pen = new Pen(AppTheme.BorderSubtle))
            {
                g.DrawLine(pen, bounds.Left, 0, bounds.Right, 0);
            }
        }

        /// <summary>
        /// Swallows the sub-item draw event — all rendering is done in DrawItem.
        /// </summary>
        private void OnGameListViewDrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            // Intentionally empty: DrawItem handles the entire row.
        }

        /// <summary>
        /// Swallows the column-header draw event (header is hidden).
        /// </summary>
        private void OnGameListViewDrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.Graphics.FillRectangle(new SolidBrush(AppTheme.BgDeep), e.Bounds);
        }

        /// <summary>
        /// Keeps the single phantom column as wide as the list view so each
        /// item row spans the full client width.
        /// </summary>
        private void OnListViewSizeChanged(object sender, EventArgs e)
        {
            if (this._GameListView.Columns.Count > 0)
            {
                this._GameListView.Columns[0].Width = this._GameListView.ClientSize.Width;
            }
        }
    }
}
