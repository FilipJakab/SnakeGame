using System;
using System.Linq;
using SnakeGame.Data;

namespace SnakeGame.Providers
{
	public class MapProvider
	{
		public void GenerateMap(Map map)
		{
			Console.BackgroundColor = ConsoleColor.Cyan;
			for (var i = 0; i <= map.Height; i++)
			{
				for (var j = 0; j <= map.Width; j++)
				{
					if (i == 0 || i == map.Height)
						ConsoleProvider.WriteElement(new Element(j, i), ConsoleColor.Cyan);
					else if (j == 0 || j == map.Width)
						ConsoleProvider.WriteElement(new Element(j, i), ConsoleColor.Cyan);
				}
			}
			Console.ResetColor();
		}

		public void DisplayScoreBoard(Player player)
		{
			Console.BackgroundColor = ConsoleColor.Blue;

			Console.SetCursorPosition(0, Console.WindowHeight - 3);
			Console.Write("Score: {0}", player.Score);
			//Console.SetCursorPosition(0, Console.WindowHeight - 2);
			Console.SetCursorPosition(15, Console.WindowHeight - 2);
			Console.Write(player.Body[0].X);
			Console.SetCursorPosition(19, Console.WindowHeight - 2);
			Console.Write(player.Body[0].Y);

			Console.ResetColor();
		}

		public void GenerateNewFruit(Map map, Player player)
		{
			var random = new Random();

			map.Fruit.X = random.Next(1, map.Width - 1);
			map.Fruit.Y = random.Next(1, map.Height - 1);

			restart:
			foreach (Element element in player.Body)
			{
				if (element.X != map.Fruit.X && element.Y != map.Fruit.Y) continue;
				map.Fruit.X = random.Next(1, map.Width - 1);
				map.Fruit.Y = random.Next(1, map.Height - 1);
				goto restart;
			}
		}

		public void ClearField(Map map, Player player)
		{
			ConsoleProvider.WriteElement(player.Body.Last());
		}

		public void RenderObjects(Player player, Map map)
		{
			foreach (var element in player.Body)
			{
				ConsoleProvider.WriteElement(element, element == player.Body[0] ? ConsoleColor.Gray : ConsoleColor.DarkGray);
			}

			ConsoleProvider.WriteElement(map.Fruit, ConsoleColor.Red);
		}
	}
}