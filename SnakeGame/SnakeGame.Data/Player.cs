using System.Collections.Generic;
using SnakeGame.Data.Enums;

namespace SnakeGame.Data
{
	public class Player
	{
		public List<Element> Body;
		public int Score { get; set; }
		public Direction Direction { get; set; }

		public Player()
		{
			Body = new List<Element>(40);

			for (int i = 10; i > 2; i--)
			{
				Body.Add(new Element(5, i));
			}

			Score = 0;

			Direction = Direction.Down;
		}
	}
}