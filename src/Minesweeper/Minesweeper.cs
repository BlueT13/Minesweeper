using System;

namespace Minesweeper
{
	internal class Minesweeper
	{
		public static void ShowBoard(int[,] board)
		{
			for (int i = 0; i < board.GetLength(0); i++)
			{
				for (int j = 0; j < board.GetLength(1); j++)
				{
					if (board[i, j] != -1)
					{
						Console.Write(" 0 ");
					}
					else
					{
						Console.Write(" 1 ");
					}
				}
				Console.WriteLine();
			}
		}

		public static void MakeMine(int[,] board)
		{
			int[] mine = new int[10];
			CreateMine(mine);

			for (int i = 0; i < board.GetLength(0); i++)
			{
				for (int j = 0; j < board.GetLength(1); j++)
				{
					for (int k = 0; k < mine.Length; k++)
					{
						if (board[i, j] == mine[k] || board[i, j] == mine[9])
						{
							board[i, j] = -1;
						}
					}
				}
			}
		}

		private static void CreateMine(int[] mine)
		{
			Random rand = new Random();
			mine[0] = rand.Next(81) + 1;
			for (int i = 1; i < mine.Length; i++)
			{
				mine[i] = rand.Next(81) + 1;
				if (mine[i] == mine[i - 1])
				{
					i--;
				}
			}
		}

	}
}
