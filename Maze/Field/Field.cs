namespace Maze.Field
{
    using static Console;
    using Contracts;
    using static Maze.Levels.LevelParser;
    
    public class Field : IField
    {
        private IList<string> levels = null!;
        private string[][] grid;
        private int x;
        private int y;
        private int level;
        
        public Field()
        {
            this.levels = new List<string>(GetTextFilesNames());
        }

        public int Level => this.levels.Count;

        public void FindPlayer()
        {
            for (int row = 0; row < this.grid.Length; row++)
            {
                string line = string.Join("", this.grid[row]);
                int col = line.IndexOf("O");

                if (col > -1)
                {
                    this.x = row; 
                    this.y = col;
                    SetCursorPosition(col, row);
                    break;
                }
            }
        }

        public void InitializeLevel()
        {
            Clear();
            CreateLevelGrid();
            this.DrawLevel();
            this.FindPlayer();
        }

        public void Update(int x, int y)
        {
            if (IsWalkable(this.x + x, this.y + y))
            {
                Render(" ");
                this.x += x;
                this.y += y;
                Render("O");
            }
        }

        public bool IsWon()
        {
            if (this.grid[this.x][this.y] != "X") 
            {
                return false;
            }

            this.level++;
            return true;
        }

        private void CreateLevelGrid()
        {
            string level = this.levels[this.level];
            this.grid = ParseFileToLevel($"../../../LevelParser/Levels/{level}");
        }

        private void DrawLevel()
        {
            for (int i = 0; i < this.grid.GetLength(0); i++)
            {
                string[] line = this.grid[i];
                WriteLine(string.Join("", line));
            }
        }

        private bool IsWalkable(int x, int y) =>
            x >= 0 && x < this.grid.Length &&
            y >= 0 && y < this.grid[0].Length &&
            (this.grid[x][y] == "X" ||
            this.grid[x][y] == " ");

        private void Render(string symbol)
        {
            SetCursorPosition(this.y, this.x);
            Write(symbol);
        }

        public bool HasMoreLevels() => this.level < this.levels.Count;
    }
}
