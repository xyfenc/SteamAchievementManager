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
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SAM.Picker.Theme
{
    /// <summary>
    /// Enables Windows 10/11 acrylic blur-behind on a WinForms window via the
    /// undocumented SetWindowCompositionAttribute API. Falls back to the older
    /// DwmEnableBlurBehindWindow on Windows Vista/7/8. All failures are silently
    /// swallowed so this is safe to call on any Windows version.
    /// </summary>
    internal static class NativeBlur
    {
        [DllImport("user32.dll")]
        private static extern int SetWindowCompositionAttribute(IntPtr hwnd, ref WindowCompositionAttributeData data);

        [DllImport("dwmapi.dll")]
        private static extern int DwmEnableBlurBehindWindow(IntPtr hWnd, ref DwmBlurBehind blurBehind);

        [StructLayout(LayoutKind.Sequential)]
        private struct DwmBlurBehind
        {
            public uint  Flags;
            [MarshalAs(UnmanagedType.Bool)] public bool Enable;
            public IntPtr Region;
            [MarshalAs(UnmanagedType.Bool)] public bool TransitionOnMaximized;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct AccentPolicy
        {
            public int   State;
            public int   Flags;
            public uint  GradientColor; // AABBGGRR byte order
            public int   AnimationId;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct WindowCompositionAttributeData
        {
            public int   Attribute;
            public IntPtr Data;
            public int   SizeOfData;
        }

        private const int  WcaAccentPolicy        = 19;
        private const int  AccentEnableAcrylicBlur = 4;
        private const int  AccentEnableBlurBehind  = 3;
        private const uint DwmBbEnable             = 0x1;

        /// <summary>
        /// Applies Windows 10+ acrylic blur-behind to a form.
        /// The tint is composited over the blurred desktop visible behind the window.
        /// </summary>
        /// <param name="form">Target form (must have a valid window handle).</param>
        /// <param name="tintABGR">
        /// Tint color in AABBGGRR byte order. Default 0xDD17110D is 87% opacity
        /// #0D1117 (Obsidian Prism BgDeep), letting a subtle blur glow through.
        /// </param>
        public static void EnableAcrylic(Form form, uint tintABGR = 0xDD17110D)
        {
            try
            {
                ApplyAcrylic(form.Handle, tintABGR);
            }
            catch
            {
                try { ApplyDwmBlur(form.Handle); }
                catch { /* No-op on unsupported platforms. */ }
            }
        }

        private static void ApplyAcrylic(IntPtr hwnd, uint tintABGR)
        {
            var accent = new AccentPolicy
            {
                State         = AccentEnableAcrylicBlur,
                Flags         = 2,
                GradientColor = tintABGR,
                AnimationId   = 0,
            };

            int   sz  = Marshal.SizeOf(accent);
            IntPtr ptr = Marshal.AllocHGlobal(sz);
            try
            {
                Marshal.StructureToPtr(accent, ptr, false);
                var attr = new WindowCompositionAttributeData
                {
                    Attribute  = WcaAccentPolicy,
                    Data       = ptr,
                    SizeOfData = sz,
                };
                SetWindowCompositionAttribute(hwnd, ref attr);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        private static void ApplyDwmBlur(IntPtr hwnd)
        {
            var blur = new DwmBlurBehind { Flags = DwmBbEnable, Enable = true };
            DwmEnableBlurBehindWindow(hwnd, ref blur);
        }
    }
}
