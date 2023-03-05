using System;

namespace Minesweeper
{
	internal class MainClass
	{
		private static int[,] board;
		private static bool[,] boardFlag;

		public static void Main(string[] args)
		{
			const int ROW = 9;
			const int COL = 9;
			const int MINES_COUNT = 10;

			int[,] mines = MakeMines(ROW, COL, MINES_COUNT);
			board = MakeMinesweeperBoard(ROW, COL, mines);
			boardFlag = new bool[ROW, COL];

			while (true)
			{
				ShowBoard();
				int[] inputCoordinate = new int[2];
				while (true)
				{
					Console.Write("선택할 칸을 입력하시오(1 1 ~ 9 9): ");
					string[] str = Console.ReadLine().Split(" ");
					try
					{
						if (str.Length != 2) throw new Exception();
						for (int i = 0; i < str.Length; i++)
						{
							int num = int.Parse(str[i]);
							if (num < 1 || num > 9)
							{
								throw new Exception();
							}
							inputCoordinate[i] = num;
						}
						break;
					}
					catch
					{
						Console.WriteLine("잘못된 입력입니다!");
					}
				}
				int x = inputCoordinate[0] - 1;
				int y = inputCoordinate[1] - 1;
				boardFlag[x, y] = true;
				if (board[x, y] != -1)
				{
					TraversalZeroNode(x, y);
				}
				else
				{
					Console.WriteLine("지뢰를 밟았습니다!\nGame Over!");
					break;
				}
			}
		}

		private static int[,] MakeMines(int row, int col, int minesCount)
		{
			Random random = new Random();
			int[,] mines = new int[minesCount, 2];
			for (int i = 0; i < minesCount; i++)
			{
				mines[i, 0] = random.Next(9);
				mines[i, 1] = random.Next(9);
			}
			return mines;
		}

		private static int[,] MakeMinesweeperBoard(int row, int col, int[,] mines)
		{
			// 지뢰 = -1로 설정
			int[,] minesweeperBoard = new int[row, col];
			for (int i = 0; i < mines.GetLength(0); i++)
			{
				int x = mines[i, 0];
				int y = mines[i, 1];
				minesweeperBoard[x, y] = -1;
			}

			// 지뢰 주변에 숫자 배정
			for (int i = 0; i < minesweeperBoard.GetLength(0); i++)
			{
				for (int j = 0; j < minesweeperBoard.GetLength(1); j++)
				{
					if (minesweeperBoard[i, j] == -1)
						continue;

					int mineCount = 0;
					for (int k = i - 1; k <= i + 1; k++)
					{
						for (int l = j - 1; l <= j + 1; l++)
						{
							if (k < 0 || k >= 9 || l < 0 || l >= 9)
								continue;

							if (k == i && l == j)
								continue;

							if (minesweeperBoard[k, l] == -1)
								mineCount++;
						}
					}
					minesweeperBoard[i, j] = mineCount;
				}
			}

			return minesweeperBoard;
		}

		private static void PrintMinesForTest(int[,] mines)
		{
			for (int i = 0; i < mines.GetLength(0); i++)
			{
				Console.Write("{0}, {1}", mines[i, 0], mines[i, 1]);
				Console.WriteLine();
			}
		}

		private static void PrintMinesweeperBoard(int[,] board)
		{
			for (int i = 0; i < board.GetLength(0); i++)
			{
				for (int j = 0; j < board.GetLength(1); j++)
				{
					Console.Write(" {0, 2:0} ", board[i, j]);
				}
				Console.WriteLine();
			}
		}

		private static void TraversalZeroNode(int x, int y)
		{
			boardFlag[x, y] = true;

			if (board[x, y] == 0)
			{
				for (int k = x - 1; k <= x + 1; k++)
				{
					for (int l = y - 1; l <= y + 1; l++)
					{
						if (k < 0 || k >= 9 || l < 0 || l >= 9)
							continue;

						if (k == x && l == y)
							continue;

						if (!boardFlag[k, l])
						{
							TraversalZeroNode(k, l);
						}
					}
				}
			}
			else
			{
				return;
			}
		}

		private static void ShowBoard()
		{
			for (int i = 0; i < boardFlag.GetLength(0); i++)
			{
				for (int j = 0; j < boardFlag.GetLength(1); j++)
				{
					if (boardFlag[i, j] == true)
					{
						Console.Write(" {0, 2:0} ", board[i, j]);
					}
					else
					{
						Console.Write(" {0, 2:0} ", "*");
					}
				}
				Console.WriteLine();
			}
		}
	}
}
