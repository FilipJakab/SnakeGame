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
			Body = new List<Element>
			{
				new Element(5, 5),
				new Element(5, 4),
				new Element(5, 3),
				new Element(5, 2)
			};

			Score = 0;

			Direction = Direction.Down;
		}
	}
}