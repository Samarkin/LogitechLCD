using System;
using System.Runtime.InteropServices;
using System.Text;

namespace LCDProcMan
{
	// ReSharper disable InconsistentNaming
	internal static class Win32
	{
		[DllImport("user32.dll")]
		public static extern IntPtr GetForegroundWindow();

		[DllImport("user32.dll", SetLastError = true)]
		public static extern int GetWindowThreadProcessId(IntPtr hWnd, out int procId);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, [Out] StringBuilder lParam);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);

		const uint WM_GETTEXTLENGTH = 0x000E;
		const uint WM_GETTEXT = 0x000D;
		const uint WM_CLOSE = 0x0010;

		public static void CloseWindow(IntPtr hWnd)
		{
			SendMessage(hWnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
		}

		public static string GetWindowTextRaw(IntPtr hwnd)
		{
			// Allocate correct string length first
			int length = SendMessage(hwnd, WM_GETTEXTLENGTH, IntPtr.Zero, IntPtr.Zero).ToInt32();
			StringBuilder sb = new StringBuilder(length + 1);
			SendMessage(hwnd, WM_GETTEXT, (IntPtr)sb.Capacity, sb);
			return sb.ToString();
		}
	}
	// ReSharper restore InconsistentNaming
}