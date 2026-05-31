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
using System.Windows.Forms;

namespace SAM.Game.Theme
{
    /// <summary>
    /// Applies a full dark theme to a DataGridView control.
    /// Call <see cref="Apply"/> once in the form constructor after
    /// InitializeComponent() to configure all cell style properties.
    /// </summary>
    internal static class DarkDataGridViewThemer
    {
        public static void Apply(DataGridView grid)
        {
            // Remove the default Windows chrome
            grid.EnableHeadersVisualStyles     = false;
            grid.BorderStyle                   = BorderStyle.None;
            grid.RowHeadersVisible             = false;
            grid.GridColor                     = AppTheme.BorderSubtle;
            grid.BackgroundColor               = AppTheme.BgDeep;
            grid.CellBorderStyle               = DataGridViewCellBorderStyle.SingleHorizontal;

            // Default cell style (normal rows)
            grid.DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor          = AppTheme.BgSurface,
                ForeColor          = AppTheme.TextPrimary,
                SelectionBackColor = AppTheme.BgSelected,
                SelectionForeColor = AppTheme.TextPrimary,
                Font               = AppTheme.FontBase,
                Padding            = new Padding(6, 0, 6, 0),
            };

            // Alternating row style
            grid.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor          = AppTheme.BgElevated,
                ForeColor          = AppTheme.TextPrimary,
                SelectionBackColor = AppTheme.BgSelected,
                SelectionForeColor = AppTheme.TextPrimary,
                Font               = AppTheme.FontBase,
                Padding            = new Padding(6, 0, 6, 0),
            };

            // Column header style
            grid.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor          = AppTheme.BgPanel,
                ForeColor          = AppTheme.AccentSecondary,
                SelectionBackColor = AppTheme.BgPanel,
                SelectionForeColor = AppTheme.AccentSecondary,
                Font               = AppTheme.FontSmallBold,
                Padding            = new Padding(6, 0, 6, 0),
            };

            // Remove grid lines for a cleaner look
            grid.CellBorderStyle = DataGridViewCellBorderStyle.None;

            // Row height
            grid.RowTemplate.Height = 32;
            grid.ColumnHeadersHeight = 32;
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        }
    }
}
