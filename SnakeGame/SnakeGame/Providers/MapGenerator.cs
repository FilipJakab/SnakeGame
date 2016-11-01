using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnakeGame.Data;

namespace SnakeGame.Providers
{
	class MapGenerator
	{
		public Map Map { get; private set; }

		public MapGenerator(Map map)
		{
			Map = map;
		}

		public void InitMap()
		{
			Console.BackgroundColor = ConsoleColor.White;
			for (int y = 0; y < Map.Height; y++)
			{
				for (int x = 0; x < Map.Width; x++)
				{
					Console.SetCursorPosition(x, y);
					if (y == 0 || y == Map.Height - 1)
						Console.Write(" ");
					else if (x == 0 || x == Map.Width - 1)
						Console.Write(" ");
				}
			}
			Console.ResetColor();
		}

		public void ClearMap()
		{
			// for the moment just call InitMap
			InitMap();
		}

		public void DrawSnake(List<SnakeSegment> playerBody)
		{
			foreach (var segment in playerBody)
			{
				if (segment == playerBody.Last()) break;

				Console.SetCursorPosition(segment.Position.X, segment.Position.Y);
				Console.Write("*");
			}
		}
	}
}
