using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logitech;

namespace LCDProcMan
{
	public sealed class BackgroundMonitor : Form
	{
		private readonly LogitechBWLCD _lcd;
		private Timer _timer;

		private Font _lcdFont = new Font("Arial", 7, FontStyle.Regular);
		private IntPtr _hWnd;
		private int _procId;

		public BackgroundMonitor()
		{
			Text = "Process monitor";
			_lcd = new LogitechBWLCD("Process monitor", true);
			_lcd.KeyPressed += KeyPressed;
			_timer = new Timer {Interval = 100};
			_timer.Tick += Tick;
			File.Delete(@"some.bmp");
			_timer.Start();
		}

		private void KeyPressed(object sender, ButtonsEventArgs e)
		{
			if (e.PressedButtons == LCDButtons.Button1 && _hWnd != IntPtr.Zero)
			{
				Win32.CloseWindow(_hWnd);
			}
			if (e.PressedButtons == LCDButtons.Button4 && _procId > 0)
			{
				try
				{
					Process.GetProcessById(_procId).Kill();
				}
				catch (ArgumentException)
				{
					Debug.Print("Process does not exist anymore");
				}
			}
		}

		private void Tick(object sender, EventArgs e)
		{
			_hWnd = IntPtr.Zero;
			_procId = 0;
			using (var g = _lcd.CreateCanvas())
			{
				g.Clear(Color.White);
				IntPtr fgWindow = Win32.GetForegroundWindow();
				if (fgWindow == IntPtr.Zero)
				{
					return;
				}
				_hWnd = fgWindow;

				var title = Win32.GetWindowTextRaw(fgWindow);
				g.DrawString(title, _lcdFont, Brushes.Black, 0, 0);

				int procId;
				Win32.GetWindowThreadProcessId(fgWindow, out procId);
				if (procId == 0)
				{
					return;
				}
				_procId = procId;
				Process p;
				try
				{
					p = Process.GetProcessById(procId);
				}
				catch (ArgumentException)
				{
					return;
				}
				g.DrawString(p.ProcessName, _lcdFont, Brushes.Black, 0, 10);
				g.DrawString("Close", _lcdFont, Brushes.Black, 5, 33);
				g.DrawString("Kill", _lcdFont, Brushes.Black, 135, 33);
			}
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				_lcd.Dispose();
				_timer.Dispose();
			}
			base.Dispose(disposing);
		}
	}

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
