namespace Maze.Listener.Contracts
{
    public interface IListener
    {
        public ConsoleKey GetKey();

        public void KeyListener(ConsoleKey certainKey, bool wait = false);

        public void Assign(ConsoleKey key, Action action = null);
    }
}
