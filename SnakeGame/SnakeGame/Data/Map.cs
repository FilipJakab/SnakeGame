using System;
using System.Linq;

namespace SnakeGame.Data
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

		

		
	}
}
