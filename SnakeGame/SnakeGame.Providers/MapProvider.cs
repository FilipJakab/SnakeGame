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
					Console.SetCursorPosition(j, i);
					if (i == 0 || i == map.Height)
						Console.Write(" ");
					else if (j == 0 || j == map.Width)
						Console.Write(" ");
				}
			}
			Console.ResetColor();
		}

		public void DisplayScoreBoard(Player player)
		{
			Console.BackgroundColor = ConsoleColor.Blue;

			Console.SetCursorPosition(0, Console.WindowHeight - 3);
			Console.Write("Score: {0}", player.Score);
			Console.SetCursorPosition(0, Console.WindowHeight - 2);
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
			Console.ResetColor();
			Console.SetCursorPosition(player.Body.Last().X, player.Body.Last().Y);
			Console.WriteLine(" ");
		}

		public void RenderObjects(Player player, Map map)
		{
			foreach (var element in player.Body)
			{
				Console.SetCursorPosition(element.X, element.Y);

				Console.BackgroundColor = element == player.Body[0] ? ConsoleColor.Gray : ConsoleColor.DarkGray;

				Console.Write(" ");
			}

			Console.SetCursorPosition(map.Fruit.X, map.Fruit.Y);
			Console.BackgroundColor = ConsoleColor.Red;
			Console.WriteLine(" ");

			Console.ResetColor();
		}
	}
}