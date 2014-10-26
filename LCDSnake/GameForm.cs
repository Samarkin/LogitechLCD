using System;
using System.Diagnostics;
using System.Windows.Forms;
using Logitech;

namespace LCDSnake
{
	public class GameForm : Form
	{
		private readonly LogitechBWLCD _lcd;
		private readonly Timer _timer;

		private GameScreen _screen;

		public GameForm()
		{
			_lcd = new LogitechBWLCD("Samara's Snake", true);
			_timer = new Timer();
			_screen = new SplashScreen();
			_timer.Start();
			_timer.Tick += GameStep;
			_lcd.KeyPressed += (o,e) => _screen.ButtonPressed(e.PressedButtons);
		}

		private void GameStep(object sender, EventArgs e)
		{
			GameStatus newStatus = _screen.Step();
			if (newStatus == null)
			{
				using (var g = _lcd.CreateCanvas())
				{
					_screen.Draw(g);
				}
			}
			else
			{
				SwitchState(newStatus);
			}
		}

		private void SwitchState(GameStatus newStatus)
		{
			GameScreen newScreen;
			switch (newStatus.State)
			{
				case GameState.Splash:
					newScreen = new SplashScreen();
					break;
				case GameState.MainScene:
					newScreen = new MainScreen();
					break;
				case GameState.GameOver:
					newScreen = new GameOver(newStatus.Score);
					break;
				case GameState.Score:
					newScreen = new ScoreScreen(newStatus.Score);
					break;
				default:
					Debug.Print("No screen defined for game state: {0}", newStatus.State);
					return;
			}
			GameScreen oldScreen = _screen;
			_screen = newScreen;
			oldScreen.Dispose();
		}

		protected override void SetVisibleCore(bool value)
		{
			base.SetVisibleCore(false);
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
}
