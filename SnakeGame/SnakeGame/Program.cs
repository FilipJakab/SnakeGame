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
using System.Threading;

namespace SnakeGame
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var mapProvider = new MapProvider();

			var map = new Map(50, 19);
			var player = new Player();

			// sets the basic stuffs
			Setup(map, player);

			// Making new position of Fruit
			mapProvider.GenerateNewFruit(map);

			// draws lines round the console
			mapProvider.GenerateMap(map);

			do
			{
				// Clearing last Element of body (tail)
				mapProvider.ClearField(map, player);

				// getting input from user
				player.Direction = PlayerProvider.GetInput(player);

				// Validating next position
				var movement = PlayerProvider.NextMove(player, map);
				if (movement != Movement.Wall && movement != Movement.Snake)
					// Setting new position
					PlayerProvider.Move(player, movement);
				else
					player.Direction = Direction.Exit;
				if (movement == Movement.Fruit)
					mapProvider.GenerateNewFruit(map);

				// updating map cuz of updating players position
				mapProvider.RenderObjects(player, map);

				// displaying score outside of map
				mapProvider.DisplayScoreBoard(player);

				// Delay
				Thread.Sleep(100);
			} while (player.Direction != Direction.Exit);

			Console.Clear();
			
			Console.SetCursorPosition(Console.WindowWidth/2 - 5, Console.WindowHeight/2);
			Console.WriteLine("Game Over.");

			Console.ReadKey(true);
		}

		public static void Setup(Map map, Player player)
		{
			Console.Title = "Snake Game";
			Console.SetWindowSize(map.Width + 1, map.Height + 4);

			// setting score board
			Console.SetCursorPosition(0, Console.WindowHeight - 2);
			Console.Write("Snake - head {   ;    }");
		}
	}
}
