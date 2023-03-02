namespace Maze
{
    using System.Xml.Linq;
    using static System.Console;
    public class World
    {
        private string[,] grid;
        private int rows;
        private int cols;

        public World(string[,] grid)
        {
            this.grid = grid;
            this.rows = grid.GetLength(0);
            this.cols = grid.GetLength(1);
        }

        public void Draw()
        {
            for (int x = 0; x < this.rows; x++)
            {
                for (int y = 0; y < this.cols; y++)
                {
                    string element = this.grid[x, y];

                    if (element == "X")
                    {
                        ForegroundColor = ConsoleColor.Green;
                    }

                    Render(x, y, element);
                }
            }
        }

        private void Render(int x, int y, string element)
        {
            SetCursorPosition(y, x);
            Write(element);
            ResetColor();
        }

        public string GetElementAt(int x, int y)
        {
            return this.grid[x, y];
        }

        public bool IsPositionWalkable(int x, int y)
        {
            if (IsOutside(x, y))
            {
                return false;
            }

            return this.grid[x, y] == " " || this.grid[x, y] == "X";
        }

        private bool IsOutside(int x, int y)
        {
            return x < 0 || y < 0 || x >= this.rows || y >= this.cols;
        }

        public (int x, int y) FindPlayer()
        {
            int x = -1;
            int y = -1;
            bool isFound = false;

            for (int r = 0; r < this.rows; r++)
            {
                for (int c = 0; c < this.cols; c++)
                {
                    if (this.grid[r, c] == "O")
                    {
                        x = r;
                        y = c;
                        isFound = true;
                        break;
                    }
                }

                if (isFound)
                {
                    break;
                }
            }

            return (x, y);
        }
    }
}
