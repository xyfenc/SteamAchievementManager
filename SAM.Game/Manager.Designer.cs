namespace SAM.Game
{
    partial class Manager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Manager));

            // ---- Non-visual ----
            this._AchievementImageList = new System.Windows.Forms.ImageList(this.components);
            this._CallbackTimer        = new System.Windows.Forms.Timer(this.components);

            // ---- Header panel children ----
            this._StoreButton          = new System.Windows.Forms.Button();
            this._ReloadButton         = new System.Windows.Forms.Button();
            this._ResetButton          = new System.Windows.Forms.Button();

            // ---- Header panel ----
            this._HeaderPanel          = new System.Windows.Forms.Panel();

            // ---- Tab control ----
            this._MainTabControl       = new System.Windows.Forms.TabControl();
            this._AchievementsTabPage  = new System.Windows.Forms.TabPage();
            this._StatisticsTabPage    = new System.Windows.Forms.TabPage();

            // ---- Achievements tab children ----
            this._AchievementListView             = new SAM.Game.DoubleBufferedListView();
            this._AchievementNameColumnHeader     = new System.Windows.Forms.ColumnHeader();
            this._AchievementDescriptionColumnHeader = new System.Windows.Forms.ColumnHeader();
            this._AchievementUnlockTimeColumnHeader  = new System.Windows.Forms.ColumnHeader();

            // ---- Achievements sub-toolbar ----
            this._AchievementsToolStrip          = new System.Windows.Forms.ToolStrip();
            this._LockAllButton                  = new System.Windows.Forms.ToolStripButton();
            this._InvertAllButton                = new System.Windows.Forms.ToolStripButton();
            this._UnlockAllButton                = new System.Windows.Forms.ToolStripButton();
            this._DisplayLabel                   = new System.Windows.Forms.ToolStripLabel();
            this._DisplayLockedOnlyButton        = new System.Windows.Forms.ToolStripButton();
            this._DisplayUnlockedOnlyButton      = new System.Windows.Forms.ToolStripButton();
            this._MatchingStringLabel            = new System.Windows.Forms.ToolStripLabel();
            this._MatchingStringTextBox          = new System.Windows.Forms.ToolStripTextBox();

            // ---- Statistics tab children ----
            this._StatisticsDataGridView   = new System.Windows.Forms.DataGridView();
            this._EnableStatsEditingCheckBox = new System.Windows.Forms.CheckBox();

            // ---- Status panel ----
            this._StatusPanel            = new System.Windows.Forms.Panel();
            this._CountryStatusLabel     = new System.Windows.Forms.Label();
            this._GameStatusLabel        = new System.Windows.Forms.Label();
            this._DownloadStatusLabel    = new System.Windows.Forms.Label();

            this._HeaderPanel.SuspendLayout();
            this._MainTabControl.SuspendLayout();
            this._AchievementsTabPage.SuspendLayout();
            this._AchievementsToolStrip.SuspendLayout();
            this._StatisticsTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._StatisticsDataGridView)).BeginInit();
            this._StatusPanel.SuspendLayout();
            this.SuspendLayout();

            // =========================================================
            // _AchievementImageList
            // =========================================================
            this._AchievementImageList.ColorDepth      = System.Windows.Forms.ColorDepth.Depth32Bit;
            this._AchievementImageList.ImageSize        = new System.Drawing.Size(64, 64);
            this._AchievementImageList.TransparentColor = System.Drawing.Color.Transparent;

            // =========================================================
            // _CallbackTimer
            // =========================================================
            this._CallbackTimer.Enabled = true;
            this._CallbackTimer.Tick   += new System.EventHandler(this.OnTimer);

            // =========================================================
            // _StoreButton  (primary violet, right-aligned)
            // =========================================================
            this._StoreButton.Anchor                          = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this._StoreButton.BackColor                       = SAM.Game.Theme.AppTheme.AccentPrimary;
            this._StoreButton.FlatStyle                      = System.Windows.Forms.FlatStyle.Flat;
            this._StoreButton.FlatAppearance.BorderSize      = 0;
            this._StoreButton.FlatAppearance.MouseOverBackColor = SAM.Game.Theme.AppTheme.AccentHover;
            this._StoreButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(0xFF, 0x6D, 0x28, 0xD9);
            this._StoreButton.ForeColor                      = SAM.Game.Theme.AppTheme.TextPrimary;
            this._StoreButton.Font                           = SAM.Game.Theme.AppTheme.FontSemibold;
            this._StoreButton.Location                       = new System.Drawing.Point(816, 14);
            this._StoreButton.Size                           = new System.Drawing.Size(132, 30);
            this._StoreButton.Enabled                        = false;
            this._StoreButton.Name                           = "_StoreButton";
            this._StoreButton.Text                           = "Commit Changes";
            this._StoreButton.UseVisualStyleBackColor        = false;
            this._StoreButton.TabIndex                       = 0;
            this._StoreButton.Click                         += new System.EventHandler(this.OnStore);

            // =========================================================
            // _ReloadButton  (secondary outline button)
            // =========================================================
            this._ReloadButton.BackColor                            = SAM.Game.Theme.AppTheme.BgElevated;
            this._ReloadButton.FlatStyle                           = System.Windows.Forms.FlatStyle.Flat;
            this._ReloadButton.FlatAppearance.BorderSize           = 1;
            this._ReloadButton.FlatAppearance.BorderColor          = SAM.Game.Theme.AppTheme.BorderSubtle;
            this._ReloadButton.FlatAppearance.MouseOverBackColor   = SAM.Game.Theme.AppTheme.BgHover;
            this._ReloadButton.FlatAppearance.MouseDownBackColor   = SAM.Game.Theme.AppTheme.BgSelected;
            this._ReloadButton.ForeColor                           = SAM.Game.Theme.AppTheme.TextPrimary;
            this._ReloadButton.Font                                = SAM.Game.Theme.AppTheme.FontBase;
            this._ReloadButton.Location                            = new System.Drawing.Point(12, 14);
            this._ReloadButton.Size                                = new System.Drawing.Size(90, 30);
            this._ReloadButton.Enabled                             = false;
            this._ReloadButton.Name                                = "_ReloadButton";
            this._ReloadButton.Text                                = "Refresh";
            this._ReloadButton.UseVisualStyleBackColor             = false;
            this._ReloadButton.TabIndex                            = 1;
            this._ReloadButton.Click                              += new System.EventHandler(this.OnRefresh);

            // =========================================================
            // _ResetButton  (danger outline button)
            // =========================================================
            this._ResetButton.BackColor                            = SAM.Game.Theme.AppTheme.BgElevated;
            this._ResetButton.FlatStyle                           = System.Windows.Forms.FlatStyle.Flat;
            this._ResetButton.FlatAppearance.BorderSize           = 1;
            this._ResetButton.FlatAppearance.BorderColor          = SAM.Game.Theme.AppTheme.RedDanger;
            this._ResetButton.FlatAppearance.MouseOverBackColor   = System.Drawing.Color.FromArgb(0x30, 0xEF, 0x44, 0x44);
            this._ResetButton.FlatAppearance.MouseDownBackColor   = System.Drawing.Color.FromArgb(0x60, 0xEF, 0x44, 0x44);
            this._ResetButton.ForeColor                           = SAM.Game.Theme.AppTheme.RedDanger;
            this._ResetButton.Font                                = SAM.Game.Theme.AppTheme.FontBase;
            this._ResetButton.Location                            = new System.Drawing.Point(110, 14);
            this._ResetButton.Size                                = new System.Drawing.Size(80, 30);
            this._ResetButton.Name                                = "_ResetButton";
            this._ResetButton.Text                                = "Reset";
            this._ResetButton.UseVisualStyleBackColor             = false;
            this._ResetButton.TabIndex                            = 2;
            this._ResetButton.Click                              += new System.EventHandler(this.OnResetAllStats);

            // =========================================================
            // _HeaderPanel  (64px glass header bar)
            // =========================================================
            this._HeaderPanel.Dock      = System.Windows.Forms.DockStyle.Top;
            this._HeaderPanel.Size      = new System.Drawing.Size(960, 64);
            this._HeaderPanel.BackColor = SAM.Game.Theme.AppTheme.BgPanel;
            this._HeaderPanel.Name      = "_HeaderPanel";
            this._HeaderPanel.Controls.Add(this._StoreButton);
            this._HeaderPanel.Controls.Add(this._ResetButton);
            this._HeaderPanel.Controls.Add(this._ReloadButton);
            this._HeaderPanel.Paint    += new System.Windows.Forms.PaintEventHandler(this.OnHeaderPanelPaint);

            // =========================================================
            // _AchievementsToolStrip  (sub-bar inside achievements tab)
            // =========================================================
            this._AchievementsToolStrip.BackColor  = SAM.Game.Theme.AppTheme.BgPanel;
            this._AchievementsToolStrip.GripStyle  = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this._AchievementsToolStrip.Renderer   = new SAM.Game.Theme.DarkToolStripRenderer();
            this._AchievementsToolStrip.Dock       = System.Windows.Forms.DockStyle.Top;
            this._AchievementsToolStrip.Height     = 40;
            this._AchievementsToolStrip.AutoSize   = false;
            this._AchievementsToolStrip.Name       = "_AchievementsToolStrip";
            this._AchievementsToolStrip.TabIndex   = 5;
            this._AchievementsToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[]
            {
                this._LockAllButton,
                this._InvertAllButton,
                this._UnlockAllButton,
                new System.Windows.Forms.ToolStripSeparator(),
                this._DisplayLabel,
                this._DisplayLockedOnlyButton,
                this._DisplayUnlockedOnlyButton,
                new System.Windows.Forms.ToolStripSeparator(),
                this._MatchingStringLabel,
                this._MatchingStringTextBox,
            });

            // ---- Lock / Invert / Unlock chip buttons ----
            this._LockAllButton.CheckOnClick    = true;
            this._LockAllButton.DisplayStyle    = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._LockAllButton.Font            = SAM.Game.Theme.AppTheme.FontBase;
            this._LockAllButton.ForeColor       = SAM.Game.Theme.AppTheme.TextPrimary;
            this._LockAllButton.Name            = "_LockAllButton";
            this._LockAllButton.Text            = "Lock All";
            this._LockAllButton.ToolTipText     = "Lock all achievements.";
            this._LockAllButton.Padding         = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this._LockAllButton.Click          += new System.EventHandler(this.OnLockAll);

            this._InvertAllButton.CheckOnClick  = true;
            this._InvertAllButton.DisplayStyle  = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._InvertAllButton.Font          = SAM.Game.Theme.AppTheme.FontBase;
            this._InvertAllButton.ForeColor     = SAM.Game.Theme.AppTheme.TextPrimary;
            this._InvertAllButton.Name          = "_InvertAllButton";
            this._InvertAllButton.Text          = "Invert";
            this._InvertAllButton.ToolTipText   = "Invert all achievements.";
            this._InvertAllButton.Padding       = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this._InvertAllButton.Click        += new System.EventHandler(this.OnInvertAll);

            this._UnlockAllButton.CheckOnClick  = true;
            this._UnlockAllButton.DisplayStyle  = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._UnlockAllButton.Font          = SAM.Game.Theme.AppTheme.FontBase;
            this._UnlockAllButton.ForeColor     = SAM.Game.Theme.AppTheme.TextPrimary;
            this._UnlockAllButton.Name          = "_UnlockAllButton";
            this._UnlockAllButton.Text          = "Unlock All";
            this._UnlockAllButton.ToolTipText   = "Unlock all achievements.";
            this._UnlockAllButton.Padding       = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this._UnlockAllButton.Click        += new System.EventHandler(this.OnUnlockAll);

            this._DisplayLabel.Font             = SAM.Game.Theme.AppTheme.FontBase;
            this._DisplayLabel.ForeColor        = SAM.Game.Theme.AppTheme.TextSecondary;
            this._DisplayLabel.Name             = "_DisplayLabel";
            this._DisplayLabel.Text             = "Show";

            this._DisplayLockedOnlyButton.CheckOnClick  = true;
            this._DisplayLockedOnlyButton.DisplayStyle  = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._DisplayLockedOnlyButton.Font          = SAM.Game.Theme.AppTheme.FontBase;
            this._DisplayLockedOnlyButton.ForeColor     = SAM.Game.Theme.AppTheme.TextPrimary;
            this._DisplayLockedOnlyButton.Name          = "_DisplayLockedOnlyButton";
            this._DisplayLockedOnlyButton.Text          = "Locked";
            this._DisplayLockedOnlyButton.Padding       = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this._DisplayLockedOnlyButton.Click        += new System.EventHandler(this.OnDisplayCheckedOnly);

            this._DisplayUnlockedOnlyButton.CheckOnClick = true;
            this._DisplayUnlockedOnlyButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._DisplayUnlockedOnlyButton.Font         = SAM.Game.Theme.AppTheme.FontBase;
            this._DisplayUnlockedOnlyButton.ForeColor    = SAM.Game.Theme.AppTheme.TextPrimary;
            this._DisplayUnlockedOnlyButton.Name         = "_DisplayUnlockedOnlyButton";
            this._DisplayUnlockedOnlyButton.Text         = "Unlocked";
            this._DisplayUnlockedOnlyButton.Padding      = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this._DisplayUnlockedOnlyButton.Click       += new System.EventHandler(this.OnDisplayUncheckedOnly);

            this._MatchingStringLabel.Font          = SAM.Game.Theme.AppTheme.FontBase;
            this._MatchingStringLabel.ForeColor     = SAM.Game.Theme.AppTheme.TextSecondary;
            this._MatchingStringLabel.Name          = "_MatchingStringLabel";
            this._MatchingStringLabel.Text          = "Filter";

            this._MatchingStringTextBox.BackColor   = SAM.Game.Theme.AppTheme.BgSurface;
            this._MatchingStringTextBox.ForeColor   = SAM.Game.Theme.AppTheme.TextPrimary;
            this._MatchingStringTextBox.Font        = SAM.Game.Theme.AppTheme.FontBase;
            this._MatchingStringTextBox.Name        = "_MatchingStringTextBox";
            this._MatchingStringTextBox.Size        = new System.Drawing.Size(180, 40);
            this._MatchingStringTextBox.ToolTipText = "Type at least 3 characters to filter by name or description";
            this._MatchingStringTextBox.KeyUp      += new System.Windows.Forms.KeyEventHandler(this.OnFilterUpdate);

            // =========================================================
            // _AchievementListView
            // =========================================================
            this._AchievementListView.Activation          = System.Windows.Forms.ItemActivation.OneClick;
            this._AchievementListView.BackColor           = SAM.Game.Theme.AppTheme.BgDeep;
            this._AchievementListView.ForeColor           = SAM.Game.Theme.AppTheme.TextPrimary;
            this._AchievementListView.CheckBoxes          = true;
            this._AchievementListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[]
            {
                this._AchievementNameColumnHeader,
                this._AchievementDescriptionColumnHeader,
                this._AchievementUnlockTimeColumnHeader,
            });
            this._AchievementListView.Dock              = System.Windows.Forms.DockStyle.Fill;
            this._AchievementListView.FullRowSelect     = true;
            this._AchievementListView.GridLines         = false;
            this._AchievementListView.HideSelection     = false;
            this._AchievementListView.LargeImageList    = this._AchievementImageList;
            this._AchievementListView.Name              = "_AchievementListView";
            this._AchievementListView.SmallImageList    = this._AchievementImageList;
            this._AchievementListView.Sorting           = System.Windows.Forms.SortOrder.Ascending;
            this._AchievementListView.UseCompatibleStateImageBehavior = false;
            this._AchievementListView.View              = System.Windows.Forms.View.Details;
            this._AchievementListView.BorderStyle       = System.Windows.Forms.BorderStyle.None;
            this._AchievementListView.Font              = SAM.Game.Theme.AppTheme.FontBase;
            this._AchievementListView.TabIndex          = 4;
            this._AchievementListView.ItemCheck        += new System.Windows.Forms.ItemCheckEventHandler(this.OnCheckAchievement);
            this._AchievementListView.ItemActivate     += new System.EventHandler(this.OnAchievementActivate);

            this._AchievementNameColumnHeader.Text  = "Name";
            this._AchievementNameColumnHeader.Width = 240;

            this._AchievementDescriptionColumnHeader.Text  = "Description";
            this._AchievementDescriptionColumnHeader.Width = 400;

            this._AchievementUnlockTimeColumnHeader.Text  = "Unlock Time";
            this._AchievementUnlockTimeColumnHeader.Width = 180;

            // =========================================================
            // _AchievementsTabPage
            // =========================================================
            this._AchievementsTabPage.Controls.Add(this._AchievementListView);
            this._AchievementsTabPage.Controls.Add(this._AchievementsToolStrip);
            this._AchievementsTabPage.Name      = "_AchievementsTabPage";
            this._AchievementsTabPage.Padding   = new System.Windows.Forms.Padding(0);
            this._AchievementsTabPage.TabIndex  = 0;
            this._AchievementsTabPage.Text      = "Achievements";
            this._AchievementsTabPage.BackColor = SAM.Game.Theme.AppTheme.BgDeep;

            // =========================================================
            // _EnableStatsEditingCheckBox
            // =========================================================
            this._EnableStatsEditingCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom
                                                    | System.Windows.Forms.AnchorStyles.Left
                                                    | System.Windows.Forms.AnchorStyles.Right;
            this._EnableStatsEditingCheckBox.AutoSize        = true;
            this._EnableStatsEditingCheckBox.Location        = new System.Drawing.Point(6, 330);
            this._EnableStatsEditingCheckBox.Name            = "_EnableStatsEditingCheckBox";
            this._EnableStatsEditingCheckBox.TabIndex        = 1;
            this._EnableStatsEditingCheckBox.Text            = "I understand that by modifying stats values I may break things and can't blame anyone but myself.";
            this._EnableStatsEditingCheckBox.ForeColor       = SAM.Game.Theme.AppTheme.TextSecondary;
            this._EnableStatsEditingCheckBox.Font            = SAM.Game.Theme.AppTheme.FontSmall;
            this._EnableStatsEditingCheckBox.UseVisualStyleBackColor = false;
            this._EnableStatsEditingCheckBox.BackColor       = SAM.Game.Theme.AppTheme.BgDeep;
            this._EnableStatsEditingCheckBox.CheckedChanged += new System.EventHandler(this.OnStatAgreementChecked);

            // =========================================================
            // _StatisticsDataGridView
            // =========================================================
            this._StatisticsDataGridView.AllowUserToAddRows    = false;
            this._StatisticsDataGridView.AllowUserToDeleteRows = false;
            this._StatisticsDataGridView.Anchor = System.Windows.Forms.AnchorStyles.Top
                                                | System.Windows.Forms.AnchorStyles.Bottom
                                                | System.Windows.Forms.AnchorStyles.Left
                                                | System.Windows.Forms.AnchorStyles.Right;
            this._StatisticsDataGridView.Location        = new System.Drawing.Point(6, 6);
            this._StatisticsDataGridView.Name            = "_StatisticsDataGridView";
            this._StatisticsDataGridView.Size            = new System.Drawing.Size(848, 316);
            this._StatisticsDataGridView.TabIndex        = 0;
            this._StatisticsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._StatisticsDataGridView.CellEndEdit    += new System.Windows.Forms.DataGridViewCellEventHandler(this.OnStatCellEndEdit);
            this._StatisticsDataGridView.DataError      += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.OnStatDataError);

            // =========================================================
            // _StatisticsTabPage
            // =========================================================
            this._StatisticsTabPage.Controls.Add(this._EnableStatsEditingCheckBox);
            this._StatisticsTabPage.Controls.Add(this._StatisticsDataGridView);
            this._StatisticsTabPage.Name      = "_StatisticsTabPage";
            this._StatisticsTabPage.Padding   = new System.Windows.Forms.Padding(6);
            this._StatisticsTabPage.TabIndex  = 1;
            this._StatisticsTabPage.Text      = "Statistics";
            this._StatisticsTabPage.BackColor = SAM.Game.Theme.AppTheme.BgDeep;

            // =========================================================
            // _MainTabControl  (owner-draw pill tabs)
            // =========================================================
            this._MainTabControl.Anchor = System.Windows.Forms.AnchorStyles.Top
                                        | System.Windows.Forms.AnchorStyles.Bottom
                                        | System.Windows.Forms.AnchorStyles.Left
                                        | System.Windows.Forms.AnchorStyles.Right;
            this._MainTabControl.Controls.Add(this._AchievementsTabPage);
            this._MainTabControl.Controls.Add(this._StatisticsTabPage);
            this._MainTabControl.Location      = new System.Drawing.Point(0, 64);
            this._MainTabControl.Name          = "_MainTabControl";
            this._MainTabControl.SelectedIndex = 0;
            this._MainTabControl.Size          = new System.Drawing.Size(960, 516);
            this._MainTabControl.TabIndex      = 5;
            this._MainTabControl.DrawMode      = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this._MainTabControl.ItemSize      = new System.Drawing.Size(140, 32);
            this._MainTabControl.SizeMode      = System.Windows.Forms.TabSizeMode.Fixed;
            this._MainTabControl.Padding       = new System.Drawing.Point(16, 4);
            this._MainTabControl.DrawItem     += new System.Windows.Forms.DrawItemEventHandler(this.OnTabControlDrawItem);

            // =========================================================
            // Status panel labels
            // =========================================================
            this._CountryStatusLabel.AutoSize   = false;
            this._CountryStatusLabel.ForeColor  = SAM.Game.Theme.AppTheme.TextMuted;
            this._CountryStatusLabel.Font       = SAM.Game.Theme.AppTheme.FontSmall;
            this._CountryStatusLabel.TextAlign  = System.Drawing.ContentAlignment.MiddleLeft;
            this._CountryStatusLabel.Location   = new System.Drawing.Point(8, 0);
            this._CountryStatusLabel.Size       = new System.Drawing.Size(120, 28);
            this._CountryStatusLabel.Name       = "_CountryStatusLabel";
            this._CountryStatusLabel.TabIndex   = 0;

            this._GameStatusLabel.Dock          = System.Windows.Forms.DockStyle.Fill;
            this._GameStatusLabel.ForeColor     = SAM.Game.Theme.AppTheme.TextSecondary;
            this._GameStatusLabel.Font          = SAM.Game.Theme.AppTheme.FontSmall;
            this._GameStatusLabel.TextAlign     = System.Drawing.ContentAlignment.MiddleLeft;
            this._GameStatusLabel.Padding       = new System.Windows.Forms.Padding(130, 0, 160, 0);
            this._GameStatusLabel.Name          = "_GameStatusLabel";
            this._GameStatusLabel.TabIndex      = 1;

            this._DownloadStatusLabel.Anchor    = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this._DownloadStatusLabel.ForeColor = SAM.Game.Theme.AppTheme.AccentSecondary;
            this._DownloadStatusLabel.Font      = SAM.Game.Theme.AppTheme.FontSmall;
            this._DownloadStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._DownloadStatusLabel.Location  = new System.Drawing.Point(720, 0);
            this._DownloadStatusLabel.Size      = new System.Drawing.Size(240, 28);
            this._DownloadStatusLabel.Name      = "_DownloadStatusLabel";
            this._DownloadStatusLabel.Visible   = false;
            this._DownloadStatusLabel.TabIndex  = 2;

            // =========================================================
            // _StatusPanel  (28px footer)
            // =========================================================
            this._StatusPanel.Dock      = System.Windows.Forms.DockStyle.Bottom;
            this._StatusPanel.Height    = 28;
            this._StatusPanel.BackColor = SAM.Game.Theme.AppTheme.BgPanel;
            this._StatusPanel.Name      = "_StatusPanel";
            this._StatusPanel.Controls.Add(this._DownloadStatusLabel);
            this._StatusPanel.Controls.Add(this._GameStatusLabel);
            this._StatusPanel.Controls.Add(this._CountryStatusLabel);
            this._StatusPanel.Paint    += new System.Windows.Forms.PaintEventHandler(this.OnStatusPanelPaint);

            // =========================================================
            // Manager form
            // =========================================================
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(960, 608);
            this.MinimumSize         = new System.Drawing.Size(800, 500);
            this.Controls.Add(this._MainTabControl);
            this.Controls.Add(this._StatusPanel);
            this.Controls.Add(this._HeaderPanel);
            this.Icon            = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name            = "Manager";
            this.Text            = "SAM - Steam Achievement Manager";
            this.BackColor       = SAM.Game.Theme.AppTheme.BgDeep;
            this.ForeColor       = SAM.Game.Theme.AppTheme.TextPrimary;
            this.Load           += new System.EventHandler(this.OnFormLoad);

            this._HeaderPanel.ResumeLayout(false);
            this._MainTabControl.ResumeLayout(false);
            this._AchievementsTabPage.ResumeLayout(false);
            this._AchievementsToolStrip.ResumeLayout(false);
            this._AchievementsToolStrip.PerformLayout();
            this._StatisticsTabPage.ResumeLayout(false);
            this._StatisticsTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._StatisticsDataGridView)).EndInit();
            this._StatusPanel.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        // ---- Non-visual ----
        private System.Windows.Forms.ImageList      _AchievementImageList;
        private System.Windows.Forms.Timer          _CallbackTimer;

        // ---- Header panel ----
        private System.Windows.Forms.Panel          _HeaderPanel;
        private System.Windows.Forms.Button         _StoreButton;
        private System.Windows.Forms.Button         _ReloadButton;
        private System.Windows.Forms.Button         _ResetButton;

        // ---- Tab control ----
        private System.Windows.Forms.TabControl     _MainTabControl;
        private System.Windows.Forms.TabPage        _AchievementsTabPage;
        private System.Windows.Forms.TabPage        _StatisticsTabPage;

        // ---- Achievements tab ----
        private SAM.Game.DoubleBufferedListView      _AchievementListView;
        private System.Windows.Forms.ColumnHeader   _AchievementNameColumnHeader;
        private System.Windows.Forms.ColumnHeader   _AchievementDescriptionColumnHeader;
        private System.Windows.Forms.ColumnHeader   _AchievementUnlockTimeColumnHeader;
        private System.Windows.Forms.ToolStrip      _AchievementsToolStrip;
        private System.Windows.Forms.ToolStripButton _LockAllButton;
        private System.Windows.Forms.ToolStripButton _InvertAllButton;
        private System.Windows.Forms.ToolStripButton _UnlockAllButton;
        private System.Windows.Forms.ToolStripLabel  _DisplayLabel;
        private System.Windows.Forms.ToolStripButton _DisplayLockedOnlyButton;
        private System.Windows.Forms.ToolStripButton _DisplayUnlockedOnlyButton;
        private System.Windows.Forms.ToolStripLabel  _MatchingStringLabel;
        private System.Windows.Forms.ToolStripTextBox _MatchingStringTextBox;

        // ---- Statistics tab ----
        private System.Windows.Forms.DataGridView    _StatisticsDataGridView;
        private System.Windows.Forms.CheckBox        _EnableStatsEditingCheckBox;

        // ---- Status panel ----
        private System.Windows.Forms.Panel           _StatusPanel;
        private System.Windows.Forms.Label           _CountryStatusLabel;
        private System.Windows.Forms.Label           _GameStatusLabel;
        private System.Windows.Forms.Label           _DownloadStatusLabel;
    }
}
