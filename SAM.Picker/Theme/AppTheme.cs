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

namespace SAM.Picker.Theme
{
    /// <summary>
    /// Obsidian Prism design tokens.
    /// Violet-to-cyan dual-accent dark theme for the rebranded SAM interface.
    /// All UI components draw exclusively from this class.
    /// </summary>
    internal static class AppTheme
    {
        // ---- Background depth layers ----
        public static readonly Color BgVoid     = Color.FromArgb(0xFF, 0x08, 0x0B, 0x12); // #080B12
        public static readonly Color BgDeep     = Color.FromArgb(0xFF, 0x0D, 0x11, 0x17); // #0D1117
        public static readonly Color BgPanel    = Color.FromArgb(0xFF, 0x12, 0x16, 0x1E); // #12161E
        public static readonly Color BgSurface  = Color.FromArgb(0xFF, 0x18, 0x1D, 0x27); // #181D27
        public static readonly Color BgElevated = Color.FromArgb(0xFF, 0x1F, 0x25, 0x35); // #1F2535
        public static readonly Color BgHover    = Color.FromArgb(0xFF, 0x25, 0x2D, 0x3E); // #252D3E
        public static readonly Color BgSelected = Color.FromArgb(0xFF, 0x27, 0x1F, 0x4A); // #271F4A

        // ---- Accent ----
        public static readonly Color AccentPrimary   = Color.FromArgb(0xFF, 0x7C, 0x3A, 0xED); // violet #7C3AED
        public static readonly Color AccentSecondary = Color.FromArgb(0xFF, 0x06, 0xB6, 0xD4); // cyan   #06B6D4
        public static readonly Color AccentHover     = Color.FromArgb(0xFF, 0x8B, 0x5C, 0xF6); // lighter violet
        public static readonly Color AccentGlow      = Color.FromArgb(0x50, 0x7C, 0x3A, 0xED); // 31% violet
        public static readonly Color AccentGlow2     = Color.FromArgb(0x35, 0x06, 0xB6, 0xD4); // 21% cyan

        // ---- Text ----
        public static readonly Color TextPrimary   = Color.FromArgb(0xFF, 0xF1, 0xF5, 0xF9); // #F1F5F9
        public static readonly Color TextSecondary = Color.FromArgb(0xFF, 0x94, 0xA3, 0xB8); // #94A3B8
        public static readonly Color TextMuted     = Color.FromArgb(0xFF, 0x47, 0x55, 0x69); // #475569

        // ---- State ----
        public static readonly Color GoldUnlocked = Color.FromArgb(0xFF, 0xF5, 0x9E, 0x0B); // amber #F59E0B
        public static readonly Color RedDanger    = Color.FromArgb(0xFF, 0xEF, 0x44, 0x44); // red   #EF4444

        // ---- Row backgrounds ----
        public static readonly Color RowUnlocked   = Color.FromArgb(0xFF, 0x18, 0x1D, 0x27); // BgSurface
        public static readonly Color RowRestricted = Color.FromArgb(0xFF, 0x2A, 0x10, 0x10); // dark red tint

        // ---- Borders ----
        public static readonly Color BorderSubtle = Color.FromArgb(0xFF, 0x1E, 0x2A, 0x3A); // #1E2A3A
        public static readonly Color BorderFocus  = Color.FromArgb(0x99, 0x7C, 0x3A, 0xED); // 60% violet

        // ---- Typography ----
        public static readonly Font FontBase      = new Font("Segoe UI", 9.5f,  FontStyle.Regular, GraphicsUnit.Point);
        public static readonly Font FontSemibold  = new Font("Segoe UI", 9.5f,  FontStyle.Bold,    GraphicsUnit.Point);
        public static readonly Font FontTitle     = new Font("Segoe UI", 11f,   FontStyle.Bold,    GraphicsUnit.Point);
        public static readonly Font FontHero      = new Font("Segoe UI", 16f,   FontStyle.Bold,    GraphicsUnit.Point);
        public static readonly Font FontSmall     = new Font("Segoe UI", 8.25f, FontStyle.Regular, GraphicsUnit.Point);
        public static readonly Font FontSmallBold = new Font("Segoe UI", 8.25f, FontStyle.Bold,    GraphicsUnit.Point);
    }
}
