namespace Maze.Core
{
    using static Console;
    using FieldNS;
    using FieldNS.Contracts;
    using ListenerNS.Contracts;
    using ListenerNS;
    using Contracts;

    public class Game : IGame
    {
        private IField field = null!;
        private IListener listener = null!;

        public void Start(bool isStarted = false)
        {
            ReadyGame();
            if (!isStarted) DisplayIntro();

            GameLoop();
            DisplayOutro();
        }

        private void GameLoop()
        {
            while (this.field.HasMoreLevels())
            {
                LevelLoop();
            }
        }

        private void LevelLoop()
        {
            this.field.InitializeLevel();
            while (true)
            {
                if (this.field.IsWon()) break;
                ConsoleKey key = this.listener.GetKey();
                this.listener.KeyListener(key);
            }
        }

        private void DisplayIntro()
        {
            Clear();
            WriteLine("This is a maze game, developed by Ivaylo Milanov!");
            WriteLine("The task is to reach the X");
            WriteLine("Up arrow - move up");
            WriteLine("Down arrow - move down");
            WriteLine("Left arrow - move left");
            WriteLine("Right arrow - move right");
            WriteLine("R - restart the game");
            WriteLine("Press ENTER to start the game");
            this.listener.KeyListener(ConsoleKey.Enter, true);
        }

        private void DisplayOutro()
        {
            Clear();
            WriteLine("Thanks for playing!");
            WriteLine("Press ESC to return to the main menu");
            this.listener.KeyListener(ConsoleKey.Escape, true);
        }

        private void ReadyGame()
        {
            this.listener = new Listener();
            AssignAllKeys();
            this.field = new Field();
            CursorVisible = false;
        }

        private void AssignAllKeys()
        {
            this.listener.Assign(ConsoleKey.UpArrow, () => this.field.Update(-1, 0));
            this.listener.Assign(ConsoleKey.DownArrow, () => this.field.Update(1, 0));
            this.listener.Assign(ConsoleKey.LeftArrow, () => this.field.Update(0, -1));
            this.listener.Assign(ConsoleKey.RightArrow, () => this.field.Update(0, 1));
            this.listener.Assign(ConsoleKey.Enter);
            this.listener.Assign(ConsoleKey.Escape, () => this.Start());
            this.listener.Assign(ConsoleKey.R, () => this.field.InitializeLevel());
        }
    }
}
