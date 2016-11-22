using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Data
{
	public class Map
	{
		public int Width { get; private set; }
		public int Height { get; private set; }

		public Element Fruit { get; set; }

		public char Wall { get; } = '#';

		public Map(int width, int height)
		{
			Width = width;
			Height = height;
			Fruit = new Element();
		}
	}
}
