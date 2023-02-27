using System;

namespace Minesweeper
{
	internal class MainClass
	{
		public static void Main(string[] args)
		{
			int[,] board = new int[9, 9];
			int count = 1;
			for (int i = 0; i < board.GetLength(0); i++)
			{
				for (int j = 0; j < board.GetLength(1); j++)
				{
					board[i, j] = count;
					count++;
				}
			}

			Minesweeper.MakeMine(board);
			Minesweeper.ShowBoard(board);
			Console.WriteLine();

			Console.Write("선택할 칸을 입력하시오(1 1 ~ 9 9): ");
			string input = Console.ReadLine();
			string[] str = input.Split(" ");
			int[] integers = new int[2];
			for (int i = 0; i < integers.Length; i++)
			{
				integers[i] = int.Parse(str[i]);
			}
			int x = integers[0] - 1;
			int y = integers[1] - 1;

			if (board[x, y] == -1)
			{
				Console.WriteLine("지뢰를 밟았습니다!");
				Console.WriteLine("-----Game Over-----");
			}
			else
			{
				// 칸 선택시 그 칸을 중심으로 한 3x3 영역에 몇 개의 지뢰가 존재하는지 표시
				// 칸 주변에 지뢰가 하나도 존재하지 않는다면 지뢰가 없는 인접한 칸들이 자동으로 열림
				// 보드 출력
				// 다시 칸 선택
				Console.WriteLine("Clear");
			}
		}
	}
}
