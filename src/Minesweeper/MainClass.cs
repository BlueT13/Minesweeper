using System;
using System.Security.Cryptography.X509Certificates;

namespace Minesweeper
{
	internal class MainClass
	{
		public static void Main(string[] args)
		{
			int[,] board = new int[9, 9];
			int[,] mines = new int[10, 2];
			bool[,] board_bools = new bool[9, 9];

			MakeMines(mines);
			for (int i = 0; i < mines.GetLength(0); i++)
			{
				Console.Write("{0}, {1}", mines[i, 0], mines[i, 1]);
				Console.WriteLine();
			}

			Console.WriteLine("----------------------------");

			for (int i = 0; i < board.GetLength(0); i++)
			{
				for (int j = 0; j < board.GetLength(1); j++)
				{
					for (int k = 0; k < mines.GetLength(0); k++)
					{
						if (i == mines[k, 0] && j == mines[k, 1])
						{
							board[i, j] = -1;
						}
					}
					Console.Write(" {0} ", board[i, j]);
				}
				Console.WriteLine();
			}

			//for (int i = 0; i < board.GetLength(0); i++)
			//{
			//	for (int j = 0; j < board.GetLength(1); j++)
			//	{
			//		if (board[i, j] == -1)
			//		{
			//			if (i < 0 || j < 0 || i > 8 || j > 8)
			//			{
			//				return;
			//			}
			//			else
			//			{
			//				board[i - 1, j - 1]++;
			//				board[i - 1, j]++;
			//				board[i - 1, j + 1]++;
			//				board[i, j - 1]++;
			//				board[i, j + 1]++;
			//				board[i + 1, j - 1]++;
			//				board[i + 1, j]++;
			//				board[i + 1, j + 1]++;
			//			}
			//		}
			//		Console.Write(" {0} ", board[i, j]);
			//	}
			//	Console.WriteLine();
			//}



			Console.Write("선택할 칸을 입력하시오(1 1 ~ 9 9): ");
			string input = Console.ReadLine();
			string[] str = input.Split(" ");
			int[] integers = new int[2];
			for (int i = 0; i < integers.Length; i++)
			{
				integers[i] = int.Parse(str[i]);
			}
			int x = integers[0];
			int y = integers[1];
			board_bools[x, y] = true;
		}

		private static void MakeMines(int[,] mines)
		{
			Random random = new Random();

			for (int i = 0; i < mines.GetLength(0); i++)
			{
				mines[i, 0] = random.Next(9);
				mines[i, 1] = random.Next(9);
			}
		}



		private static void ShowBoard(int[,] board, bool[,] board_bools)
		{
			for (int i = 0; i < board_bools.GetLength(0); i++)
			{
				for (int j = 0; j < board_bools.GetLength(1); j++)
				{
					if (board_bools[i, j] == true)
					{
						Console.WriteLine(" {0} ", board[i, j]);
					}
				}
			}
		}
	}
}
