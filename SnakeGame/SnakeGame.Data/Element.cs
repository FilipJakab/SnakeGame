namespace SnakeGame.Data
{
	public class Element
	{
		public int X { get; set; }
		public int Y { get; set; }

		public Element() {}

		public Element(int x, int y)
		{
			X = x;
			Y = y;
		}
	}
}