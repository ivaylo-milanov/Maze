namespace Maze.FieldNS.Contracts
{

    public interface IField
    {
        int Level { get; }
        void InitializeLevel();

        void Update(int x, int y);

        bool IsWon();

        bool HasMoreLevels();
    }
}
