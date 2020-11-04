using System;
using System.Runtime.InteropServices;

namespace WindowsDrimmer.Base
{
    public static class NativeMethods
    {
        #region "User32.dll"

        public const int ExStyle = -20;
        public const int WS_EX_Transparent = 0x20;
        public const int WS_EX_Layered = 0x80000;
        public const int LWA_ColorKey = 0x01;
        public const int LWA_Alpha = 0x02;


        [DllImport("user32.dll")]
        public static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll")]
        public static extern bool SetLayeredWindowAttributes(IntPtr hwnd, int crKey, byte bAlpha, int dwFlags);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("SHELL32", CallingConvention = CallingConvention.StdCall)]
        public static extern uint SHAppBarMessage(int dwMessage, ref APPBARDATA pData);


        #endregion
    }
}
