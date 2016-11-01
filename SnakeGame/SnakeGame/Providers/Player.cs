using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnakeGame.Data.Enums;

namespace SnakeGame.Providers
{
	public class Player
	{
		public List<SnakeSegment> Body;
		public Direction Direction;

		public int PlayerLenght => Body.Count;

		public Player()
		{
			Body = new List<SnakeSegment>
			{
				new SnakeSegment(),
				new SnakeSegment(),
				new SnakeSegment()
			};

			Direction = Direction.Right;
		}

		public void Input()
		{
			var input = Console.ReadKey(false).Key;

			switch (input)
			{
				case ConsoleKey.W:
					if (Direction != Direction.Down)
						Direction = Direction.Up;
					break;

				case ConsoleKey.A:
					if (Direction != Direction.Right)
						Direction = Direction.Left;
					break;

				case ConsoleKey.S:
					if (Direction != Direction.Up)
						Direction = Direction.Down;
					break;

				case ConsoleKey.D:
					if (Direction != Direction.Left)
						Direction = Direction.Right;
					break;

				case ConsoleKey.Escape:
					Program.GameOver = true;
					break;
			}
		}

		public bool CanMove()
		{
			var head = Body.ElementAt(0);

			switch (Direction)
			{
				case Direction.Up:
					if (head.Position.Y + 1 == Program.Map.Height)
						return false;
					break;

				case Direction.Down:
					if (head.Position.Y - 1 == 0)
						return false;
					break;

				case Direction.Left:
					if (head.Position.X - 1 == 0)
						return false;
					break;

				case Direction.Right:
					if (head.Position.X + 1 == Program.Map.Width)
						return false;
					break;
			}

			return true;
		}

		/// <summary>
		/// All the stuff in one Method => if player can move, sets the new position, TODO removes last element
		/// </summary>
		public void Move()
		{
			var head = Body.ElementAt(0);

			// TODO: remove last element

			// move by direction
			switch (Direction)
			{
				case Direction.Up:
					head.Position.Y--;
					break;

				case Direction.Down:
					head.Position.Y++;
					break;

				case Direction.Left:
					head.Position.X--;
					break;

				case Direction.Right:
					head.Position.X++;
					break;
			}
		}
	}
}
