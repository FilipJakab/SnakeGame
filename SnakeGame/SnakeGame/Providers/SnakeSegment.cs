using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Providers
{
	public class SnakeSegment
	{
		public Data.Structs.Position Position;

		public SnakeSegment()
		{
			Position.X = 2;
			Position.Y = 2;
		}

		public SnakeSegment(int x, int y)
		{
			Position.X = x;
			Position.Y = y;
		}
	}
}
