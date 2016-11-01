using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using SnakeGame.Providers;

namespace SnakeGame
{
	public class Program
	{
		public static Player Player;
		public static Map Map;

		public static bool GameOver = false;

		public static void Main(string[] args)
		{
			Map = new Map(40, 20);
			Player = new Player();

			if (GameOver) goto EndProgram;

			// setting map
			Map.InitMap();

			//game loop
			do
			{
				// get input
				Player.Input();

				// validations
				if (!Player.CanMove())
					goto EndProgram;

				// updating map
				Map.UpdateMap();

			} while (!GameOver);

		EndProgram:
			Console.Clear();

			Console.WriteLine(" > Game Over <");

			Console.ReadKey(false);
		}
	}
}
