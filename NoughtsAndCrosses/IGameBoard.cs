namespace NoughtsAndCrosses
{
    public interface IGameBoard
    {
        char[,] GetBoard();
        void PrintBoard();
        bool SetValue(int i, int j, char value);
        int[] UserInputTile();
        char UserInputValue();
        bool ValidateGame();
    }
}