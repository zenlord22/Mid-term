using System;

class Match3Game
{
    static int[,] grid;
    static Random random = new Random();
    const int gridSize = 8;
    const int numColors = 5;

    static void Main()
    {
        InitializeGrid();
        DisplayGrid();

        while (true)
        {
            Console.WriteLine("Enter the coordinates of the first cell to swap (row and column):");
            int row1 = int.Parse(Console.ReadLine());
            int col1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the coordinates of the second cell to swap (row and column):");
            int row2 = int.Parse(Console.ReadLine());
            int col2 = int.Parse(Console.ReadLine());

            SwapCells(row1, col1, row2, col2);
            DisplayGrid();

            if (CheckMatches())
            {
                Console.WriteLine("Match found!");
                RemoveMatches();
                DisplayGrid();
            }
            else
            {
                Console.WriteLine("No match found. Try again.");
                SwapCells(row1, col1, row2, col2); // Swap back if no match
                DisplayGrid();
            }
        }
    }

    static void InitializeGrid()
    {
        grid = new int[gridSize, gridSize];
        for (int row = 0; row < gridSize; row++)
        {
            for (int col = 0; col < gridSize; col++)
            {
                grid[row, col] = random.Next(1, numColors + 1);
            }
        }
    }

    static void DisplayGrid()
    {
        for (int row = 0; row < gridSize; row++)
        {
            for (int col = 0; col < gridSize; col++)
            {
                Console.Write(grid[row, col] + " ");
            }
            Console.WriteLine();
        }
    }

    static void SwapCells(int row1, int col1, int row2, int col2)
    {
        int temp = grid[row1, col1];
        grid[row1, col1] = grid[row2, col2];
        grid[row2, col2] = temp;
    }

    static bool CheckMatches()
    {
        bool matchFound = false;

        // Check for horizontal matches
        for (int row = 0; row < gridSize; row++)
        {
            for (int col = 0; col < gridSize - 2; col++)
            {
                if (grid[row, col] == grid[row, col + 1] && grid[row, col] == grid[row, col + 2])
                {
                    matchFound = true;
                    grid[row, col] = -1;
                    grid[row, col + 1] = -1;
                    grid[row, col + 2] = -1;
                }
            }
        }

        // Check for vertical matches
        for (int col = 0; col < gridSize; col++)
        {
            for (int row = 0; row < gridSize - 2; row++)
            {
                if (grid[row, col] == grid[row + 1, col] && grid[row, col] == grid[row + 2, col])
                {
                    matchFound = true;
                    grid[row, col] = -1;
                    grid[row + 1, col] = -1;
                    grid[row + 2, col] = -1;
                }
            }
        }

        return matchFound;
    }

    static void RemoveMatches()
    {
        // Remove all marked matches
        for (int row = 0; row < gridSize; row++)
        {
            for (int col = 0; col < gridSize; col++)
            {
                if (grid[row, col] == -1)
                {
                    grid[row, col] = 0;
                }
            }
        }

        // Fill empty spaces with new random colors
        for (int row = 0; row < gridSize; row++)
        {
            for (int col = 0; col < gridSize; col++)
            {
                if (grid[row, col] == 0)
                {
                    grid[row, col] = random.Next(1, numColors + 1);
                }
            }
        }
    }
}
