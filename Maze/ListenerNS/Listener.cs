namespace Maze.Listener
{
    using static Console;
    public class Listener : IListener
    {
        private IDictionary<ConsoleKey, Action> keys;

        public Listener()
        {
            keys = new Dictionary<ConsoleKey, Action>();
        }

        private void WaitForKey(ConsoleKey certainKey)
        {
            ConsoleKey key;
            do
            {
                key = GetKey();
            } while (key != certainKey);
        }

        public ConsoleKey GetKey() => ReadKey(true).Key;

        public void KeyListener(ConsoleKey certainKey, bool wait = false)
        {
            if (wait) WaitForKey(certainKey);

            if (!keys.ContainsKey(certainKey)) return;

            var action = keys[certainKey];

            if (action != null) action();
        }

        public void Assign(ConsoleKey key, Action action = null)
        {
            keys.Add(key, action);
        }
    }
}
