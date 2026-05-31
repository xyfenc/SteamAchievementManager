namespace SAM.Picker
{
    partial class GamePicker
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GamePicker));

            // ---- Non-visual components ----
            this._LogoImageList  = new System.Windows.Forms.ImageList(this.components);
            this._CallbackTimer  = new System.Windows.Forms.Timer(this.components);
            this._LogoWorker     = new System.ComponentModel.BackgroundWorker();
            this._ListWorker     = new System.ComponentModel.BackgroundWorker();

            // ---- Header panel children ----
            this._AddGameTextBox       = new System.Windows.Forms.TextBox();
            this._AddGameButton        = new System.Windows.Forms.Button();
            this._SearchGameTextBox    = new System.Windows.Forms.TextBox();
            this._RefreshGamesButton   = new System.Windows.Forms.Button();

            // ---- Filter panel ----
            this._FilterPanel          = new System.Windows.Forms.Panel();
            this._FilterStrip          = new System.Windows.Forms.ToolStrip();
            this._FilterGamesButton    = new System.Windows.Forms.ToolStripButton();
            this._FilterDemosButton    = new System.Windows.Forms.ToolStripButton();
            this._FilterModsButton     = new System.Windows.Forms.ToolStripButton();
            this._FilterJunkButton     = new System.Windows.Forms.ToolStripButton();

            // ---- Header panel (created after children so children can be added) ----
            this._HeaderPanel          = new System.Windows.Forms.Panel();

            // ---- Game list ----
            this._GameListView         = new SAM.Picker.MyListView();

            // ---- Status panel ----
            this._StatusPanel          = new System.Windows.Forms.Panel();
            this._PickerStatusLabel    = new System.Windows.Forms.Label();
            this._DownloadStatusLabel  = new System.Windows.Forms.Label();

            this._HeaderPanel.SuspendLayout();
            this._FilterPanel.SuspendLayout();
            this._FilterStrip.SuspendLayout();
            this._StatusPanel.SuspendLayout();
            this.SuspendLayout();

            // =========================================================
            // _LogoImageList
            // =========================================================
            this._LogoImageList.ColorDepth       = System.Windows.Forms.ColorDepth.Depth32Bit;
            this._LogoImageList.ImageSize         = new System.Drawing.Size(184, 69);
            this._LogoImageList.TransparentColor  = System.Drawing.Color.Transparent;

            // =========================================================
            // _CallbackTimer
            // =========================================================
            this._CallbackTimer.Enabled = true;
            this._CallbackTimer.Tick   += new System.EventHandler(this.OnTimer);

            // =========================================================
            // _LogoWorker / _ListWorker
            // =========================================================
            this._LogoWorker.WorkerSupportsCancellation = true;
            this._LogoWorker.DoWork              += new System.ComponentModel.DoWorkEventHandler(this.DoDownloadLogo);
            this._LogoWorker.RunWorkerCompleted  += new System.ComponentModel.RunWorkerCompletedEventHandler(this.OnDownloadLogo);

            this._ListWorker.WorkerSupportsCancellation = true;
            this._ListWorker.DoWork              += new System.ComponentModel.DoWorkEventHandler(this.DoDownloadList);
            this._ListWorker.RunWorkerCompleted  += new System.ComponentModel.RunWorkerCompletedEventHandler(this.OnDownloadList);

            // =========================================================
            // _AddGameTextBox  (game ID input, left side of header)
            // =========================================================
            this._AddGameTextBox.BackColor    = SAM.Picker.Theme.AppTheme.BgElevated;
            this._AddGameTextBox.ForeColor    = SAM.Picker.Theme.AppTheme.TextPrimary;
            this._AddGameTextBox.BorderStyle  = System.Windows.Forms.BorderStyle.None;
            this._AddGameTextBox.Font         = SAM.Picker.Theme.AppTheme.FontBase;
            this._AddGameTextBox.Location     = new System.Drawing.Point(158, 22);
            this._AddGameTextBox.Size         = new System.Drawing.Size(108, 20);
            this._AddGameTextBox.Name         = "_AddGameTextBox";
            this._AddGameTextBox.TabIndex     = 0;

            // =========================================================
            // _AddGameButton  (secondary outline button)
            // =========================================================
            this._AddGameButton.BackColor                            = SAM.Picker.Theme.AppTheme.BgElevated;
            this._AddGameButton.FlatStyle                           = System.Windows.Forms.FlatStyle.Flat;
            this._AddGameButton.FlatAppearance.BorderSize           = 1;
            this._AddGameButton.FlatAppearance.BorderColor          = SAM.Picker.Theme.AppTheme.AccentPrimary;
            this._AddGameButton.FlatAppearance.MouseOverBackColor   = SAM.Picker.Theme.AppTheme.BgHover;
            this._AddGameButton.FlatAppearance.MouseDownBackColor   = SAM.Picker.Theme.AppTheme.BgSelected;
            this._AddGameButton.ForeColor                           = SAM.Picker.Theme.AppTheme.TextPrimary;
            this._AddGameButton.Font                                = SAM.Picker.Theme.AppTheme.FontSemibold;
            this._AddGameButton.Location                            = new System.Drawing.Point(274, 14);
            this._AddGameButton.Size                                = new System.Drawing.Size(100, 30);
            this._AddGameButton.Name                                = "_AddGameButton";
            this._AddGameButton.Text                                = "Add Game";
            this._AddGameButton.UseVisualStyleBackColor             = false;
            this._AddGameButton.TabIndex                            = 1;
            this._AddGameButton.Click                              += new System.EventHandler(this.OnAddGame);

            // =========================================================
            // _SearchGameTextBox  (search field, anchored, fills center)
            // =========================================================
            this._SearchGameTextBox.Anchor       = System.Windows.Forms.AnchorStyles.Top
                                                   | System.Windows.Forms.AnchorStyles.Left
                                                   | System.Windows.Forms.AnchorStyles.Right;
            this._SearchGameTextBox.BackColor    = SAM.Picker.Theme.AppTheme.BgElevated;
            this._SearchGameTextBox.ForeColor    = SAM.Picker.Theme.AppTheme.TextPrimary;
            this._SearchGameTextBox.BorderStyle  = System.Windows.Forms.BorderStyle.None;
            this._SearchGameTextBox.Font         = SAM.Picker.Theme.AppTheme.FontBase;
            this._SearchGameTextBox.Location     = new System.Drawing.Point(392, 22);
            this._SearchGameTextBox.Size         = new System.Drawing.Size(410, 20);
            this._SearchGameTextBox.Name         = "_SearchGameTextBox";
            this._SearchGameTextBox.TabIndex     = 2;
            this._SearchGameTextBox.KeyUp       += new System.Windows.Forms.KeyEventHandler(this.OnFilterUpdate);

            // =========================================================
            // _RefreshGamesButton  (primary violet button, right)
            // =========================================================
            this._RefreshGamesButton.Anchor                          = System.Windows.Forms.AnchorStyles.Top
                                                                      | System.Windows.Forms.AnchorStyles.Right;
            this._RefreshGamesButton.BackColor                       = SAM.Picker.Theme.AppTheme.AccentPrimary;
            this._RefreshGamesButton.FlatStyle                      = System.Windows.Forms.FlatStyle.Flat;
            this._RefreshGamesButton.FlatAppearance.BorderSize      = 0;
            this._RefreshGamesButton.FlatAppearance.MouseOverBackColor = SAM.Picker.Theme.AppTheme.AccentHover;
            this._RefreshGamesButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(0xFF, 0x6D, 0x28, 0xD9);
            this._RefreshGamesButton.ForeColor                      = SAM.Picker.Theme.AppTheme.TextPrimary;
            this._RefreshGamesButton.Font                           = SAM.Picker.Theme.AppTheme.FontSemibold;
            this._RefreshGamesButton.Location                       = new System.Drawing.Point(816, 14);
            this._RefreshGamesButton.Size                           = new System.Drawing.Size(132, 30);
            this._RefreshGamesButton.Name                           = "_RefreshGamesButton";
            this._RefreshGamesButton.Text                           = "Refresh Library";
            this._RefreshGamesButton.UseVisualStyleBackColor        = false;
            this._RefreshGamesButton.TabIndex                       = 3;
            this._RefreshGamesButton.Click                         += new System.EventHandler(this.OnRefresh);

            // =========================================================
            // _HeaderPanel  (64px frosted glass header, painted custom)
            // =========================================================
            this._HeaderPanel.Dock      = System.Windows.Forms.DockStyle.Top;
            this._HeaderPanel.Size      = new System.Drawing.Size(960, 64);
            this._HeaderPanel.BackColor = SAM.Picker.Theme.AppTheme.BgPanel;
            this._HeaderPanel.Name      = "_HeaderPanel";
            this._HeaderPanel.Controls.Add(this._RefreshGamesButton);
            this._HeaderPanel.Controls.Add(this._SearchGameTextBox);
            this._HeaderPanel.Controls.Add(this._AddGameButton);
            this._HeaderPanel.Controls.Add(this._AddGameTextBox);
            this._HeaderPanel.Paint    += new System.Windows.Forms.PaintEventHandler(this.OnHeaderPanelPaint);

            // =========================================================
            // _FilterStrip  (inside filter panel, holds chip buttons)
            // =========================================================
            this._FilterStrip.BackColor  = SAM.Picker.Theme.AppTheme.BgSurface;
            this._FilterStrip.Dock       = System.Windows.Forms.DockStyle.Fill;
            this._FilterStrip.GripStyle  = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this._FilterStrip.Renderer   = new SAM.Picker.Theme.DarkToolStripRenderer();
            this._FilterStrip.Name       = "_FilterStrip";
            this._FilterStrip.Padding    = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this._FilterStrip.TabIndex   = 0;
            this._FilterStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[]
            {
                this._FilterGamesButton,
                this._FilterDemosButton,
                this._FilterModsButton,
                this._FilterJunkButton,
            });

            // ---- Filter chip buttons ----
            this._FilterGamesButton.CheckOnClick    = true;
            this._FilterGamesButton.Checked         = true;
            this._FilterGamesButton.CheckState      = System.Windows.Forms.CheckState.Checked;
            this._FilterGamesButton.DisplayStyle    = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._FilterGamesButton.Font            = SAM.Picker.Theme.AppTheme.FontBase;
            this._FilterGamesButton.ForeColor       = SAM.Picker.Theme.AppTheme.TextPrimary;
            this._FilterGamesButton.Name            = "_FilterGamesButton";
            this._FilterGamesButton.Text            = "Games";
            this._FilterGamesButton.Padding         = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this._FilterGamesButton.CheckedChanged += new System.EventHandler(this.OnFilterUpdate);

            this._FilterDemosButton.CheckOnClick    = true;
            this._FilterDemosButton.DisplayStyle    = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._FilterDemosButton.Font            = SAM.Picker.Theme.AppTheme.FontBase;
            this._FilterDemosButton.ForeColor       = SAM.Picker.Theme.AppTheme.TextPrimary;
            this._FilterDemosButton.Name            = "_FilterDemosButton";
            this._FilterDemosButton.Text            = "Demos";
            this._FilterDemosButton.Padding         = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this._FilterDemosButton.CheckedChanged += new System.EventHandler(this.OnFilterUpdate);

            this._FilterModsButton.CheckOnClick    = true;
            this._FilterModsButton.DisplayStyle    = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._FilterModsButton.Font            = SAM.Picker.Theme.AppTheme.FontBase;
            this._FilterModsButton.ForeColor       = SAM.Picker.Theme.AppTheme.TextPrimary;
            this._FilterModsButton.Name            = "_FilterModsButton";
            this._FilterModsButton.Text            = "Mods";
            this._FilterModsButton.Padding         = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this._FilterModsButton.CheckedChanged += new System.EventHandler(this.OnFilterUpdate);

            this._FilterJunkButton.CheckOnClick    = true;
            this._FilterJunkButton.DisplayStyle    = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._FilterJunkButton.Font            = SAM.Picker.Theme.AppTheme.FontBase;
            this._FilterJunkButton.ForeColor       = SAM.Picker.Theme.AppTheme.TextPrimary;
            this._FilterJunkButton.Name            = "_FilterJunkButton";
            this._FilterJunkButton.Text            = "Junk";
            this._FilterJunkButton.Padding         = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this._FilterJunkButton.CheckedChanged += new System.EventHandler(this.OnFilterUpdate);

            // =========================================================
            // _FilterPanel  (40px sub-header for filter chips)
            // =========================================================
            this._FilterPanel.Dock      = System.Windows.Forms.DockStyle.Top;
            this._FilterPanel.Height    = 40;
            this._FilterPanel.BackColor = SAM.Picker.Theme.AppTheme.BgSurface;
            this._FilterPanel.Name      = "_FilterPanel";
            this._FilterPanel.Controls.Add(this._FilterStrip);

            // =========================================================
            // _GameListView  (Details view, full-width card rows)
            // =========================================================
            this._GameListView.BackColor             = SAM.Picker.Theme.AppTheme.BgDeep;
            this._GameListView.ForeColor             = SAM.Picker.Theme.AppTheme.TextPrimary;
            this._GameListView.Dock                  = System.Windows.Forms.DockStyle.Fill;
            this._GameListView.HideSelection         = false;
            this._GameListView.LargeImageList        = this._LogoImageList;
            this._GameListView.MultiSelect           = false;
            this._GameListView.Name                  = "_GameListView";
            this._GameListView.OwnerDraw             = true;
            this._GameListView.Sorting               = System.Windows.Forms.SortOrder.Ascending;
            this._GameListView.UseCompatibleStateImageBehavior = false;
            this._GameListView.VirtualMode           = true;
            this._GameListView.BorderStyle           = System.Windows.Forms.BorderStyle.None;
            this._GameListView.View                  = System.Windows.Forms.View.Details;
            this._GameListView.HeaderStyle           = System.Windows.Forms.ColumnHeaderStyle.None;
            this._GameListView.TabIndex              = 0;
            // One full-width phantom column — width set dynamically in code
            this._GameListView.Columns.Add(new System.Windows.Forms.ColumnHeader { Text = string.Empty, Width = 860 });
            this._GameListView.DrawItem             += new System.Windows.Forms.DrawListViewItemEventHandler(this.OnGameListViewDrawItem);
            this._GameListView.DrawSubItem          += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.OnGameListViewDrawSubItem);
            this._GameListView.DrawColumnHeader     += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.OnGameListViewDrawColumnHeader);
            this._GameListView.ItemActivate         += new System.EventHandler(this.OnActivateGame);
            this._GameListView.RetrieveVirtualItem  += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.OnGameListViewRetrieveVirtualItem);
            this._GameListView.SearchForVirtualItem += new System.Windows.Forms.SearchForVirtualItemEventHandler(this.OnGameListViewSearchForVirtualItem);
            this._GameListView.SizeChanged          += new System.EventHandler(this.OnListViewSizeChanged);

            // =========================================================
            // _PickerStatusLabel / _DownloadStatusLabel  (inside status panel)
            // =========================================================
            this._PickerStatusLabel.Dock        = System.Windows.Forms.DockStyle.Fill;
            this._PickerStatusLabel.ForeColor   = SAM.Picker.Theme.AppTheme.TextSecondary;
            this._PickerStatusLabel.Font        = SAM.Picker.Theme.AppTheme.FontSmall;
            this._PickerStatusLabel.TextAlign   = System.Drawing.ContentAlignment.MiddleLeft;
            this._PickerStatusLabel.Padding     = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this._PickerStatusLabel.Name        = "_PickerStatusLabel";
            this._PickerStatusLabel.TabIndex    = 0;

            this._DownloadStatusLabel.Anchor    = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this._DownloadStatusLabel.ForeColor = SAM.Picker.Theme.AppTheme.AccentSecondary;
            this._DownloadStatusLabel.Font      = SAM.Picker.Theme.AppTheme.FontSmall;
            this._DownloadStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._DownloadStatusLabel.Location  = new System.Drawing.Point(620, 0);
            this._DownloadStatusLabel.Size      = new System.Drawing.Size(240, 28);
            this._DownloadStatusLabel.Name      = "_DownloadStatusLabel";
            this._DownloadStatusLabel.Visible   = false;
            this._DownloadStatusLabel.TabIndex  = 1;

            // =========================================================
            // _StatusPanel  (28px footer bar)
            // =========================================================
            this._StatusPanel.Dock      = System.Windows.Forms.DockStyle.Bottom;
            this._StatusPanel.Height    = 28;
            this._StatusPanel.BackColor = SAM.Picker.Theme.AppTheme.BgPanel;
            this._StatusPanel.Name      = "_StatusPanel";
            this._StatusPanel.Controls.Add(this._DownloadStatusLabel);
            this._StatusPanel.Controls.Add(this._PickerStatusLabel);
            this._StatusPanel.Paint    += new System.Windows.Forms.PaintEventHandler(this.OnStatusPanelPaint);

            // =========================================================
            // GamePicker form
            // =========================================================
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(960, 680);
            this.MinimumSize         = new System.Drawing.Size(760, 520);
            // Docking order: Fill first, then Bottom, then Top panels (last added = topmost)
            this.Controls.Add(this._GameListView);
            this.Controls.Add(this._StatusPanel);
            this.Controls.Add(this._FilterPanel);
            this.Controls.Add(this._HeaderPanel);
            this.Icon            = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name            = "GamePicker";
            this.Text            = "SAM - Steam Achievement Manager";
            this.BackColor       = SAM.Picker.Theme.AppTheme.BgDeep;
            this.ForeColor       = SAM.Picker.Theme.AppTheme.TextPrimary;
            this.Load           += new System.EventHandler(this.OnFormLoad);

            this._HeaderPanel.ResumeLayout(false);
            this._FilterPanel.ResumeLayout(false);
            this._FilterStrip.ResumeLayout(false);
            this._FilterStrip.PerformLayout();
            this._StatusPanel.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        // ---- Non-visual ----
        private SAM.Picker.MyListView              _GameListView;
        private System.Windows.Forms.ImageList     _LogoImageList;
        private System.Windows.Forms.Timer         _CallbackTimer;
        private System.ComponentModel.BackgroundWorker _LogoWorker;
        private System.ComponentModel.BackgroundWorker _ListWorker;

        // ---- Header panel ----
        private System.Windows.Forms.Panel         _HeaderPanel;
        private System.Windows.Forms.TextBox       _AddGameTextBox;
        private System.Windows.Forms.Button        _AddGameButton;
        private System.Windows.Forms.TextBox       _SearchGameTextBox;
        private System.Windows.Forms.Button        _RefreshGamesButton;

        // ---- Filter panel ----
        private System.Windows.Forms.Panel         _FilterPanel;
        private System.Windows.Forms.ToolStrip     _FilterStrip;
        private System.Windows.Forms.ToolStripButton _FilterGamesButton;
        private System.Windows.Forms.ToolStripButton _FilterDemosButton;
        private System.Windows.Forms.ToolStripButton _FilterModsButton;
        private System.Windows.Forms.ToolStripButton _FilterJunkButton;

        // ---- Status panel ----
        private System.Windows.Forms.Panel         _StatusPanel;
        private System.Windows.Forms.Label         _PickerStatusLabel;
        private System.Windows.Forms.Label         _DownloadStatusLabel;
    }
}
