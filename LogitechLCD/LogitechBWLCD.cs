using System;
using System.Drawing;

namespace Logitech
{
	public sealed class LogitechBWLCD : IDisposable
	{
		public const int Width = 160;
		public const int Height = 43;

		private readonly bool _initialized;

		private readonly int _connection = DMcLgLCD.LGLCD_INVALID_CONNECTION;
		private readonly int _device = DMcLgLCD.LGLCD_INVALID_DEVICE;
		private readonly Bitmap _lcd;
// ReSharper disable PrivateFieldCanBeConvertedToLocalVariable
// It's here to avoid disposal of the delegate
		private readonly DMcLgLCD.btnCallback _callback;
// ReSharper restore PrivateFieldCanBeConvertedToLocalVariable

		public event EventHandler<ButtonsEventArgs> KeyPressed;

		public LogitechBWLCD(string appFriendlyName, bool btnCallbacks)
		{
			if (DMcLgLCD.LcdInit() != DMcLgLCD.ERROR_SUCCESS)
			{
				throw new LogitechLCDException("Cannot initialize");
			}
			_initialized = true;
			_connection = DMcLgLCD.LcdConnectEx(appFriendlyName, 0, 0);
			if (_connection == DMcLgLCD.LGLCD_INVALID_CONNECTION)
			{
				throw new LogitechLCDException("Cannot connect");
			}
			_device = DMcLgLCD.LcdOpenByType(_connection, DMcLgLCD.LGLCD_DEVICE_BW);
			if (_device == DMcLgLCD.LGLCD_INVALID_DEVICE)
			{
				throw new LogitechLCDException("B/W device was not found");
			}
			_lcd = new Bitmap(Width, Height);
			using (var g = CreateCanvas())
			{
				g.Clear(Color.White);
			}
			DMcLgLCD.LcdSetAsLCDForegroundApp(_device, DMcLgLCD.LGLCD_FORE_YES);
			if (btnCallbacks)
			{
				_callback = ButtonCallback;
				DMcLgLCD.LcdSetButtonCallback(_callback);
			}
		}

		private void ButtonCallback(int devicetype, int dwbuttons)
		{
			if (KeyPressed != null)
			{
				KeyPressed(this, new ButtonsEventArgs((LCDButtons) dwbuttons));
			}
		}

		public LcdGraphics CreateCanvas()
		{
			var g = new LcdGraphics(Graphics.FromImage(_lcd), Width, Height);
			g.Disposed += (o, e) => UpdateBitmap();
			return g;
		}

		private void UpdateBitmap()
		{
			// TODO: Dispose Hbitmap?
			DMcLgLCD.LcdUpdateBitmap(_device, _lcd.GetHbitmap(), DMcLgLCD.LGLCD_DEVICE_BW);
		}

		#region Dispose

		~LogitechBWLCD()
		{
			Dispose(false);
		}

		private void Dispose(bool disposing)
		{
			if (disposing)
			{
				_lcd.Dispose();
			}
			if (_initialized)
			{
				if (_connection != DMcLgLCD.LGLCD_INVALID_CONNECTION)
				{
					if (_device != DMcLgLCD.LGLCD_INVALID_DEVICE)
					{
						DMcLgLCD.LcdClose(_device);
					}
					DMcLgLCD.LcdDisconnect(_connection);
				}
				DMcLgLCD.LcdDeInit();
			}
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		#endregion
	}

	[Flags]
	public enum LCDButtons : uint
	{
		Button1 = DMcLgLCD.LGLCD_BUTTON_1,
		Button2 = DMcLgLCD.LGLCD_BUTTON_2,
		Button3 = DMcLgLCD.LGLCD_BUTTON_3,
		Button4 = DMcLgLCD.LGLCD_BUTTON_4
	}

	public class ButtonsEventArgs : EventArgs
	{
		public readonly LCDButtons PressedButtons;

		public ButtonsEventArgs(LCDButtons pressedButtons)
		{
			PressedButtons = pressedButtons;
		}
	}
}
