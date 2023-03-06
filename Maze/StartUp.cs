namespace Maze
{
    using Core.Contracts;
    using Core;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            IGame game = new Game();
            game.Start();
        }
    }
}
