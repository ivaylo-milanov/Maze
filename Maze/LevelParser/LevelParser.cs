namespace Maze.Levels
{
    public class LevelParser
    {
        public static string[][] ParseFileToLevel(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            int rows = lines.Length;
            string[][] grid = new string[rows][];

            for (int i = 0; i < rows; i++)
            {
                grid[i] = lines[i]
                    .ToCharArray()
                    .Select(x => x.ToString())
                    .ToArray();
            }

            return grid;
        }

        public static string[] GetTextFilesNames()
        {
            return Directory
                .GetFiles("../../../LevelParser/Levels")
                .Select(f => f.Split("\\").Last())
                .ToArray();
        }
    }
}
