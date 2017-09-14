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
        void CreateBoard();
    }

    public interface IGameBoardWinning : IGameBoard
    {
        char GetWinner();
        bool IsDraw();
        void PlayerStarts(char player);
    }
}