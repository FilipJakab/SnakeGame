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

			switch (player.Direction)
			{
				case Direction.Up:
					if (head.Y - 1 == 0)
					{
						// colision
						return Movement.Wall;
					}
					if (head.Y - 1 == map.Fruit.Y && head.X == map.Fruit.X)
						return Movement.Fruit;
					break;
				case Direction.Down:
					if (head.Y + 1 == map.Height)
					{
						// colision
						return Movement.Wall;
					}
					if (head.Y + 1 == map.Fruit.Y && head.X == map.Fruit.X)
						return Movement.Fruit;
					break;
				case Direction.Left:
					if (head.X - 1 == 0)
					{
						// colision
						return Movement.Wall;
					}
					if (head.X - 1 == map.Fruit.X && head.Y == map.Fruit.Y)
						return Movement.Fruit;
					break;
				case Direction.Right:
					if (head.X + 1 == map.Width)
					{
						// colision
						return Movement.Wall;
					}
					if (head.X + 1 == map.Fruit.X && head.Y == map.Fruit.Y)
						return Movement.Fruit;
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
					return Direction.Up;
				case ConsoleKey.A:
					return Direction.Left;
				case ConsoleKey.S:
					return Direction.Down;
				case ConsoleKey.D:
					return Direction.Right;
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