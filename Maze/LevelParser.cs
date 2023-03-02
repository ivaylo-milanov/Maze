namespace Maze
{
    public class LevelParser
    {
        public static string[,] parseFileToArray(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            string firstLine = lines[0];
            int rows = lines.Length;
            int cols = firstLine.Length;
            string[,] grid = new string[rows, cols];

            for (int x = 0; x < rows; x++)
            {
                string line = lines[x];
                for (int y = 0; y < cols; y++)
                {
                    char element = line[y];
                    grid[x, y] = element.ToString();
                }
            }

            return grid;
        }

        public static string[] GetTextFilesNames()
        {
            return Directory
                .GetFiles("../../../Levels")
                .Select(f => f.Split("\\").Last())
                .ToArray();
        }
    }
}
