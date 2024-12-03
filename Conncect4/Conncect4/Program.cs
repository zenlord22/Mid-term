using System;

namespace Connect4
{
    class Program
    {
        static char[,] board = new char[6, 7];
        static char[] players = { 'X', 'O' };
        static int currentPlayer = 0;

        static void Main(string[] args)
        {
            InitializeBoard();
            bool gameWon = false;

            while (!gameWon && !BoardFull())
            {
                PrintBoard();
                Console.WriteLine($"Player {players[currentPlayer]}'s turn. Choose a column (0-6):");
                int column = int.Parse(Console.ReadLine());

                if (PlacePiece(column))
                {
                    gameWon = CheckWin();
                    currentPlayer = (currentPlayer + 1) % 2;
                }
                else
                {
                    Console.WriteLine("Column full or invalid. Try again.");
                }
            }

            PrintBoard();
            if (gameWon)
            {
                Console.WriteLine($"Player {players[(currentPlayer + 1) % 2]} wins!");
            }
            else
            {
                Console.WriteLine("It's a draw!");
            }
        }

        static void InitializeBoard()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    board[i, j] = '.';
                }
            }
        }

        static void PrintBoard()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    Console.Write(board[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        static bool PlacePiece(int column)
        {
            if (column < 0 || column >= 7)
            {
                return false;
            }

            for (int i = 5; i >= 0; i--)
            {
                if (board[i, column] == '.')
                {
                    board[i, column] = players[currentPlayer];
                    return true;
                }
            }

            return false;
        }

        static bool CheckWin()
        {
            // Check horizontal, vertical, and diagonal lines for a win
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (board[i, j] != '.' &&
                        (CheckLine(i, j, 1, 0) || CheckLine(i, j, 0, 1) || CheckLine(i, j, 1, 1) || CheckLine(i, j, 1, -1)))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        static bool CheckLine(int row, int col, int dRow, int dCol)
        {
            char start = board[row, col];
            for (int i = 1; i < 4; i++)
            {
                int newRow = row + i * dRow;
                int newCol = col + i * dCol;
                if (newRow < 0 || newRow >= 6 || newCol < 0 || newCol >= 7 || board[newRow, newCol] != start)
                {
                    return false;
                }
            }
            return true;
        }

        static bool BoardFull()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (board[i, j] == '.')
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
