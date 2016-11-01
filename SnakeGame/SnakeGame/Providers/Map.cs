using System;
using System.Linq;

namespace SnakeGame.Providers
{
	public class Map
	{
		private int _width;
		private int _height;

		public int Width
		{
			get { return _width; }
			set
			{
				if (value < 5)
				{
					Console.WriteLine("Width of the map must be bigger that 5");
					Program.GameOver = true;
				}
				_width = value;
			}
		}

		public int Height
		{
			get { return _height; }
			set
			{
				if (value < 5)
				{
					Console.WriteLine("Height of the map must be bigger that 5");
					Program.GameOver = true;
				}
				_height = value;
			}
		}

		public Map(int width, int height)
		{
			Width = width;
			Height = height;
		}

		public void InitMap()
		{
			Console.BackgroundColor = ConsoleColor.White;
			for (int y = 0; y < Height; y++)
			{
				for (int x = 0; x < Width; x++)
				{
					Console.SetCursorPosition(x, y);
					if (y == 0 || y == Height - 1)
						Console.Write(" ");
					else if (x == 0 || x == Width - 1)
						Console.Write(" ");
				}
			}
			Console.ResetColor();
		}

		public void UpdateMap()
		{
			foreach (var segment in Program.Player.Body)
			{
				if (segment == Program.Player.Body.Last()) break;

				Console.SetCursorPosition(segment.Position.X, segment.Position.Y);
				Console.Write("*");
			}
		}
	}
}
