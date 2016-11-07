using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnakeGame.Data;
using SnakeGame.Data.Enums;

namespace SnakeGame.Providers
{
	public class Player
	{
		public List<SnakeSegment> Body;
		public Actions Actions;

		public int PlayerLenght => Body.Count;

		public Player()
		{
			Body = new List<SnakeSegment>
			{
				new SnakeSegment(),
				new SnakeSegment(),
				new SnakeSegment()
			};

			Actions = Actions.Right;
		}

		public Actions WaitForNextMove()
		{
			var input = Console.ReadKey(false).Key;

			Actions nextAction;

			switch (input)
			{
				case ConsoleKey.W:
					nextAction = Actions.Up;
					break;

				case ConsoleKey.A:
					nextAction = Actions.Left;
					break;

				case ConsoleKey.S:
					nextAction = Actions.Down;
					break;

				case ConsoleKey.D:
					nextAction = Actions.Right;
					break;

				case ConsoleKey.Escape:
					nextAction = Actions.Exit;
					break;

				default:
					nextAction = Actions.Unknown;
					break;
			}
			return nextAction;
		}

		public bool CanMove(Map map, Actions nextAction)
		{
			var head = Body.ElementAt(0);

			switch (Actions)
			{
				case Actions.Up:
					if (head.Position.Y + 1 == map.Height)
						return false;
					break;

				case Actions.Down:
					if (head.Position.Y - 1 == 0)
						return false;
					break;

				case Actions.Left:
					if (head.Position.X - 1 == 0)
						return false;
					break;

				case Actions.Right:
					if (head.Position.X + 1 == map.Width)
						return false;
					break;
			}

			return true;
		}

		/// <summary>
		/// sets the new position
		/// </summary>
		public void Move()
		{
			var head = Body.ElementAt(0);

			// move by direction
			switch (Actions)
			{
				case Actions.Up:
					head.Position.Y--;
					break;

				case Actions.Down:
					head.Position.Y++;
					break;

				case Actions.Left:
					head.Position.X--;
					break;

				case Actions.Right:
					head.Position.X++;
					break;
			}
		}
	}
}
