using System;
using System.Linq;
using SnakeGame.Data;
using SnakeGame.Data.Enums;

namespace SnakeGame.Providers
{
	public static class PlayerProvider
	{
		public static Movement NextMove(Player player, Map map)
		{
			var head = player.Body.ElementAt(0);

			// Validating next position
			switch (player.Direction)
			{
				case Direction.Up:
					if (head.Y - 1 == 0) // Out of map collision
					{
						return Movement.Wall;
					}
					if (head.Y - 1 == map.Fruit.Y && head.X == map.Fruit.X) // Fruit collision
						return Movement.Fruit;
					if (player.Body.Any(element => head.X == element.X && head.Y - 1 == element.Y)) // self-touch
					{
						return Movement.Snake;
					}
					break;
				case Direction.Down:
					if (head.Y + 1 == map.Height) // Out of map collision
					{
						return Movement.Wall;
					}
					if (head.Y + 1 == map.Fruit.Y && head.X == map.Fruit.X) // Fruit collision
						return Movement.Fruit;
					if (player.Body.Any(element => head.X == element.X && head.Y + 1 == element.Y)) // self-touch
					{
						return Movement.Snake;
					}
					break;
				case Direction.Left:
					if (head.X - 1 == 0) // Out of map collision
					{
						return Movement.Wall;
					}
					if (head.X - 1 == map.Fruit.X && head.Y == map.Fruit.Y) // Fruit collision
						return Movement.Fruit;
					if (player.Body.Any(element => head.X - 1 == element.X && head.Y == element.Y)) // self-touch
					{
						return Movement.Snake;
					}
					break;
				case Direction.Right:
					if (head.X + 1 == map.Width) // Out of map collision
					{
						return Movement.Wall;
					}
					if (head.X + 1 == map.Fruit.X && head.Y == map.Fruit.Y) // Fruit collision
						return Movement.Fruit;
					if (player.Body.Any(element => head.X + 1 == element.X && head.Y == element.Y)) // self-touch
					{
						return Movement.Snake;
					}
					break;
			}

			return Movement.Space;
		}

		public static void Move(Player player, Movement nextMove)
		{
			// Declaring new Element; will be added to List body soon
			var head = new Element();

			switch (player.Direction)
			{
				case Direction.Up:
					{
						head = new Element(player.Body[0].X, player.Body[0].Y - 1);
					}
					break;
				case Direction.Down:
					{
						head = new Element(player.Body[0].X, player.Body[0].Y + 1);
					}
					break;
				case Direction.Left:
					{
						head = new Element(player.Body[0].X - 1, player.Body[0].Y);
					}
					break;
				case Direction.Right:
					{
						head = new Element(player.Body[0].X + 1, player.Body[0].Y);
					}
					break;
			}

			// Checking next position
			if (nextMove == Movement.Space)
			{
				player.Body.Insert(0, head);
				// removing tale from Snake body
				player.Body.RemoveAt(player.Body.Count - 1);
			}
			else if (nextMove == Movement.Fruit)
			{
				player.Body.Insert(0, head);
				player.Score++;
			}
		}

		public static Direction GetInput(Player player)
		{
			if (!Console.KeyAvailable) return player.Direction;
			var key = Console.ReadKey(true).Key;
			switch (key)
			{
				case ConsoleKey.W:
					return player.Direction != Direction.Down ? Direction.Up : player.Direction;
				case ConsoleKey.A:
					return player.Direction != Direction.Right ? Direction.Left : player.Direction;
				case ConsoleKey.S:
					return player.Direction != Direction.Up ? Direction.Down : player.Direction;
				case ConsoleKey.D:
					return player.Direction != Direction.Left ? Direction.Right : player.Direction;
				case ConsoleKey.Escape:
					return Direction.Exit;
				case ConsoleKey.Spacebar:
					Console.ReadKey(true);
					break;
				default:
					return player.Direction;
			}
			return player.Direction;
		}


	}
}