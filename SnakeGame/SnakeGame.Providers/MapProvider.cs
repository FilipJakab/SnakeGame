using System;
using System.Linq;
using SnakeGame.Data;

namespace SnakeGame.Providers
{
	public class MapProvider
	{
		public void GenerateMap(Map map)
		{
			for (var i = 0; i <= map.Height; i++)
			{
				for (var j = 0; j <= map.Width; j++)
				{
					Console.SetCursorPosition(j, i);
					if (i == 0 || i == map.Height)
						Console.Write("{0}", map.Wall);
					else if (j == 0 || j == map.Width)
						Console.Write("{0}", map.Wall);
				}
			}
		}

		public void DisplayScoreBoard(Player player)
		{
			Console.SetCursorPosition(0, Console.WindowHeight - 3);
			Console.Write("Score: {0}", player.Score);
			Console.SetCursorPosition(0, Console.WindowHeight - 2);
			Console.SetCursorPosition(15, Console.WindowHeight - 2);
			Console.Write(player.Body[0].X);
			Console.SetCursorPosition(19, Console.WindowHeight - 2);
			Console.Write(player.Body[0].Y);
		}

		public void GenerateNewFruit(Map map)
		{
			var random = new Random();

			map.Fruit.X = random.Next(1, map.Width - 1);
			map.Fruit.Y = random.Next(1, map.Height - 1);
		}

		public void ClearField(Map map, Player player)
		{
			Console.SetCursorPosition(player.Body.Last().X, player.Body.Last().Y);
			Console.WriteLine(" ");
		}

		public void RenderObjects(Player player, Map map)
		{
			foreach (var element in player.Body)
			{
				Console.SetCursorPosition(element.X, element.Y);
				Console.Write(element == player.Body[0] ? "O" : "o");
			}
			Console.SetCursorPosition(map.Fruit.X, map.Fruit.Y);
			Console.WriteLine("*");
		}
	}
}