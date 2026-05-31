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

using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SAM.Picker.Theme
{
    /// <summary>
    /// Custom ToolStrip renderer that applies the Obsidian Prism dark theme.
    /// Replaces the system default professional renderer with flat, dark controls
    /// and a violet accent highlight on active/pressed/checked states.
    /// </summary>
    internal sealed class DarkToolStripRenderer : ToolStripProfessionalRenderer
    {
        public DarkToolStripRenderer()
            : base(new DarkColorTable())
        {
            this.RoundedEdges = false;
        }

        // ------------------------------------------------------------------ strip background

        protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
        {
            using (var brush = new SolidBrush(AppTheme.BgPanel))
            {
                e.Graphics.FillRectangle(brush, e.AffectedBounds);
            }
        }

        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            // Draw a single 1px bottom border line in the subtle border color
            var rect = e.AffectedBounds;
            using (var pen = new Pen(AppTheme.BorderSubtle))
            {
                e.Graphics.DrawLine(pen, rect.Left, rect.Bottom - 1, rect.Right - 1, rect.Bottom - 1);
            }
        }

        // ------------------------------------------------------------------ button backgrounds

        protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
        {
            var item   = e.Item;
            var g      = e.Graphics;
            var bounds = new Rectangle(1, 1, item.Width - 2, item.Height - 2);

            if (item.Pressed)
            {
                using (var brush = new SolidBrush(AppTheme.BgSelected))
                {
                    g.FillRectangle(brush, bounds);
                }
                using (var pen = new Pen(AppTheme.AccentPrimary))
                {
                    g.DrawRectangle(pen, bounds);
                }
            }
            else if (item.Selected || (item is ToolStripButton btn && btn.Checked))
            {
                using (var brush = new SolidBrush(AppTheme.BgHover))
                {
                    g.FillRectangle(brush, bounds);
                }
                // Accent top edge
                using (var pen = new Pen(AppTheme.AccentPrimary, 2))
                {
                    g.DrawLine(pen, bounds.Left, bounds.Top, bounds.Right, bounds.Top);
                }
            }
        }

        protected override void OnRenderDropDownButtonBackground(ToolStripItemRenderEventArgs e)
        {
            OnRenderButtonBackground(e);
        }

        // ------------------------------------------------------------------ separator

        protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
        {
            var g      = e.Graphics;
            var bounds = e.Item.ContentRectangle;
            int x      = bounds.Width / 2;

            using (var pen = new Pen(AppTheme.BorderSubtle))
            {
                g.DrawLine(pen, x, 2, x, bounds.Height - 2);
            }
        }

        // ------------------------------------------------------------------ item text

        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            e.TextColor = e.Item.Enabled ? AppTheme.TextPrimary : AppTheme.TextMuted;
            base.OnRenderItemText(e);
        }

        // ------------------------------------------------------------------ item image (ensure no magenta bleed)

        protected override void OnRenderItemImage(ToolStripItemImageRenderEventArgs e)
        {
            var g      = e.Graphics;
            var image  = e.Image;
            var bounds = e.ImageRectangle;

            if (image == null)
            {
                return;
            }

            var attrs = new System.Drawing.Imaging.ImageAttributes();
            if (e.Item.Enabled == false)
            {
                // Greyed-out disabled state
                var matrix = new System.Drawing.Imaging.ColorMatrix()
                {
                    Matrix33 = 0.4f,
                    Matrix00 = 0.4f,
                    Matrix11 = 0.4f,
                    Matrix22 = 0.4f,
                };
                attrs.SetColorMatrix(matrix);
            }

            g.DrawImage(image, bounds, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, attrs);
        }

        // ------------------------------------------------------------------ overflow arrow

        protected override void OnRenderOverflowButtonBackground(ToolStripItemRenderEventArgs e)
        {
            using (var brush = new SolidBrush(AppTheme.BgPanel))
            {
                e.Graphics.FillRectangle(brush, new Rectangle(Point.Empty, e.Item.Size));
            }
        }

        // ------------------------------------------------------------------ menu item background (drop-down menus)

        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            var g      = e.Graphics;
            var bounds = new Rectangle(Point.Empty, e.Item.Size);

            if (e.Item.Selected)
            {
                using (var brush = new SolidBrush(AppTheme.BgHover))
                {
                    g.FillRectangle(brush, bounds);
                }
            }
            else
            {
                using (var brush = new SolidBrush(AppTheme.BgPanel))
                {
                    g.FillRectangle(brush, bounds);
                }
            }
        }


        // ------------------------------------------------------------------ check mark for menu items

        protected override void OnRenderItemCheck(ToolStripItemImageRenderEventArgs e)
        {
            var g      = e.Graphics;
            var bounds = e.ImageRectangle;

            // Draw an accent-colored square indicator
            bounds.Inflate(-2, -2);
            using (var brush = new SolidBrush(AppTheme.AccentPrimary))
            {
                g.FillRectangle(brush, bounds);
            }
        }

        // ------------------------------------------------------------------ color table

        private sealed class DarkColorTable : ProfessionalColorTable
        {
            public override Color MenuStripGradientBegin    => AppTheme.BgPanel;
            public override Color MenuStripGradientEnd      => AppTheme.BgPanel;
            public override Color ToolStripDropDownBackground => AppTheme.BgPanel;
            public override Color MenuBorder                 => AppTheme.BorderSubtle;
            public override Color MenuItemBorder             => AppTheme.BorderSubtle;
            public override Color MenuItemSelected           => AppTheme.BgHover;
            public override Color MenuItemSelectedGradientBegin => AppTheme.BgHover;
            public override Color MenuItemSelectedGradientEnd   => AppTheme.BgHover;
            public override Color ImageMarginGradientBegin   => AppTheme.BgPanel;
            public override Color ImageMarginGradientEnd     => AppTheme.BgPanel;
            public override Color ImageMarginGradientMiddle  => AppTheme.BgPanel;
            public override Color SeparatorDark              => AppTheme.BorderSubtle;
            public override Color SeparatorLight             => AppTheme.BorderSubtle;
        }
    }
}
