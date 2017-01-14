using System;
using SnakeGame.Data;

namespace SnakeGame.Providers
{
	public static class ConsoleProvider
	{
		/// <summary>
		/// print Space on position in specified color
		/// </summary>
		/// <param name="element">Position</param>
		/// <param name="color">Color of the Space</param>
		public static void WriteElement(Element element, ConsoleColor color)
		{
			Console.SetCursorPosition(element.X, element.Y);
			Console.BackgroundColor = color;
			Console.Write(" ");
			Console.ResetColor();
		}

		/// <summary>
		/// print Space on position in default color
		/// </summary>
		/// <param name="element">Position</param>
		public static void WriteElement(Element element)
		{
			Console.ResetColor();
			Console.SetCursorPosition(element.X, element.Y);
			Console.Write(" ");
		}
	}
}