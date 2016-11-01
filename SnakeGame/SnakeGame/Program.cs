using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using SnakeGame.Data;
using SnakeGame.Data.Enums;
using SnakeGame.Providers;

namespace SnakeGame
{
	public class Program
	{
		public static Player Player;
		//public static Map Map;

		public static bool GameOver = false;

		public static void Main(string[] args)
		{
			Map map = new Map(40, 20);
			Player = new Player();

			if (GameOver) goto EndProgram;

			MapGenerator generator = new MapGenerator(map);
			// setting map
			generator.InitMap();

			//game loop
			do
			{
				// get input
				var nextMove = Player.WaitForNextMove();

				if(nextMove == Actions.Exit)
					goto EndProgram;
				if (nextMove == Actions.Unknown)
				{
					Console.WriteLine("Invalid move, please, press ASDW or Escape");
					continue;
				}

				// validations
				if (!Player.CanMove(map, nextMove))
					goto EndProgram;

				// updating map
				generator.ClearMap();
				generator.DrawSnake(Player.Body);

			} while (!GameOver);

		EndProgram:
			Console.Clear();

			Console.WriteLine(" > Game Over <");

			Console.ReadKey(false);
		}
	}
}
