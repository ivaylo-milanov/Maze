using static System.Console;

namespace Maze
{
    public class Player
    {
        private string playerMarker;
        private ConsoleColor playerColor;

        public Player(int initX, int initY)
        {
            X = initX;
            Y = initY;
            this.playerMarker = "O";
            this.playerColor = ConsoleColor.Red;
        }
        
        public int X { get; set; }
        public int Y { get; set; }
        
        public void Draw()
        {
            ForegroundColor = this.playerColor;
            SetCursorPosition(Y, X);
            Write(playerMarker);
            ResetColor();
        }

        public void ErasePlayer()
        {
            SetCursorPosition(Y, X);
            Write(" ");
        }
    }
}
