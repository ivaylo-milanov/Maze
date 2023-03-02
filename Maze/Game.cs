using static System.Console;

namespace Maze
{
    public class Game
    {
        private Player player;
        private World world;
        private Queue<string> levels;

        public void Start()
        {
            Title = "Welcome to the maze!";
            CursorVisible = false;

            SetBufferSize(3000, 3000);
            DisplayIntro();
            string[] textFilesNames = LevelParser.GetTextFilesNames();
            this.levels = new Queue<string>(textFilesNames);
            int levelsCount = this.levels.Count;

            while (levelsCount > 0)
            {
                string[,] grid = LevelParser.parseFileToArray($"../../../Levels/{this.levels.Peek()}");
                this.world = new World(grid);
                (int x, int y) = this.world.FindPlayer();
                this.player = new Player(x, y);
                DrawFrame();
                RunGameLoop();
                levelsCount--;

                if (levelsCount > 0)
                {
                    PlayNextOrRestart();
                }
            }

            DisplayOutro();            
        }

        private void DisplayIntro()
        {
            WriteLine("Welcome to the maze!");
            WriteLine("\nInstructions");
            WriteLine("> Use the arrow keys to move");
            Write("> Try to reach the goal, which looks like this: ");
            ForegroundColor = ConsoleColor.Green;
            WriteLine("X");
            ResetColor();
            WriteLine("> Press any key to start");
            ReadKey(true);
        }

        private void PlayNextOrRestart()
        {
            Clear();
            WriteLine("You escaped this level.");
            WriteLine("Enter: Play next level");
            WriteLine("R: Restart the current level");

            while (true)
            {
                ConsoleKey key = KeyPressed();

                if (key == ConsoleKey.Enter)
                {
                    this.levels.Dequeue();
                    break;
                }

                if (key == ConsoleKey.R)
                {
                    break;
                }
            }
        }

        private void DisplayOutro()
        {
            Clear();
            WriteLine("You escaped!");
            WriteLine("Thanks for playing");
            WriteLine("Press any key to exit...");
            ReadKey(true);
        }

        private void DrawFrame()
        {
            Clear();
            this.world.Draw();
        }

        private void HandlePlayerInput()
        {
            ConsoleKey key = KeyPressed();
            
            this.player.ErasePlayer();
            Move(key);
        }

        private ConsoleKey KeyPressed()
        {
            ConsoleKey key;
            do
            {
                ConsoleKeyInfo keyInfo = ReadKey(true);
                key = keyInfo.Key;
            } while (KeyAvailable);

            return key;
        }

        private void Move(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.W:
                    if (world.IsPositionWalkable(player.X - 1, player.Y))
                    {
                        player.X -= 1;
                    }
                    break;
                case ConsoleKey.S:
                    if (world.IsPositionWalkable(player.X + 1, player.Y))
                    {
                        player.X += 1;
                    }
                    break;
                case ConsoleKey.A:
                    if (world.IsPositionWalkable(player.X, player.Y - 1))
                    {
                        player.Y -= 1;
                    }
                    break;
                case ConsoleKey.D:
                    if (world.IsPositionWalkable(player.X, player.Y + 1))
                    {
                        player.Y += 1;
                    }
                    break;
            }
        }

        private void RunGameLoop()
        {
            while(true)
            {
                this.player.Draw();
                HandlePlayerInput();

                string element = this.world.GetElementAt(this.player.X, this.player.Y);

                if (element == "X")
                {
                    break;
                }
            }
        }
    }
}
