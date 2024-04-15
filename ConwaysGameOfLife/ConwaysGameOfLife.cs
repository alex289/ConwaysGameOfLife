namespace ConwaysGameOfLife;

public static class ConwaysGameOfLife
{
    public static void Run(int rows, int cols, int generations, bool showGeneration = false)
    {
        var grid = new bool[rows, cols];
        var random = new Random();

        // Populate grid randomly
        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < cols; j++)
            {
                grid[i, j] = random.Next(2) == 1;
            }
        }

        for (var gen = 0; gen < generations; gen++)
        {
            Console.Clear();
            if (showGeneration)
            {
                Console.WriteLine("Generation: " + (gen + 1));
            }

            PrintGrid(grid);
            grid = NextGeneration(grid, rows, cols);
            Thread.Sleep(500); // Pause for visualization
        }
    }

    private static bool[,] NextGeneration(bool[,] grid, int rows, int cols)
    {
        var newGrid = new bool[rows, cols];

        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < cols; j++)
            {
                var liveNeighbors = CountLiveNeighbors(grid, i, j);
                
                /*
                 * 1. Any live cell with fewer than two live neighbors dies, as if by underpopulation.
                 * 2. Any live cell with two or three live neighbors lives on to the next generation.
                 * 3. Any live cell with more than three live neighbors dies, as if by overpopulation.
                 * 4. Any dead cell with exactly three live neighbors becomes a live cell, as if by reproduction.
                 */

                // Apply the rules of Conway's Game of Life
                if (grid[i, j])
                {
                    if (liveNeighbors is < 2 or > 3)
                    {
                        newGrid[i, j] = false;
                    }
                    else
                    {
                        newGrid[i, j] = true;
                    }
                }
                else
                {
                    if (liveNeighbors == 3)
                    {
                        newGrid[i, j] = true;
                    }
                }
            }
        }

        return newGrid;
    }

    private static int CountLiveNeighbors(bool[,] grid, int x, int y)
    {
        var count = 0;
        var rows = grid.GetLength(0);
        var cols = grid.GetLength(1);

        for (var i = -1; i <= 1; i++)
        {
            for (var j = -1; j <= 1; j++)
            {
                var neighborX = x + i;
                var neighborY = y + j;

                // Skip the current cell
                if (i == 0 && j == 0)
                {
                    continue;
                }

                if (neighborX >= 0 && neighborX < rows && neighborY >= 0 && neighborY < cols &&
                    grid[neighborX, neighborY])
                {
                    count++;
                }
            }
        }

        return count;
    }

    private static void PrintGrid(bool[,] grid)
    {
        var rows = grid.GetLength(0);
        var cols = grid.GetLength(1);

        for (var i = 0; i < rows; i++)
        {
            for (var j = 0; j < cols; j++) Console.Write(grid[i, j] ? "█" : " ");
            Console.WriteLine();
        }
    }
}