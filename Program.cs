using System;

namespace GAME.NUMBERGUESS.CONSOLEAPP
{
	class Program
	{
		static void Main(string[] args)
		{
			GameStatus gameStatus = GameStatus.TRIGER;
			int target;
			string startGame;
			int guess;

			while (true)
			{

				while (gameStatus == GameStatus.TRIGER)
				{
					Console.WriteLine("Do you want to start number guessing game?");
					Console.WriteLine("Please input Y/N");

					startGame = Console.ReadLine();

					if (startGame.ToUpper() == "Y")
						gameStatus = GameStatus.START;
					if (startGame.ToUpper() == "N")
						gameStatus = GameStatus.STOP;
				}

				if (gameStatus == GameStatus.STOP)
					break;

				if (gameStatus == GameStatus.START)
				{
					Random rand = new Random();
					target = rand.Next(0, 100);
					Console.WriteLine("Please input a integer between 0 to 100");

					while (gameStatus == GameStatus.START)
					{
						var readGuess = Console.ReadLine();

						while (!Int32.TryParse(readGuess, out guess) || guess < 0 || guess > 100)
						{
							Console.WriteLine("Please input a integer between 0 to 100");
							readGuess = Console.ReadLine();
						}

						if (guess > target)
							Console.WriteLine($"Your guess number {guess} is too large");
						if (guess < target)
							Console.WriteLine($"Your guess number {guess} is too small");
						if (guess == target)
						{
							Console.WriteLine("You win");
							gameStatus = GameStatus.TRIGER;
						}

					}
				}
			}
		}
	}
}
