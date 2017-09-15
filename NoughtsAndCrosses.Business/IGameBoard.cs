namespace NoughtsAndCrosses
{
    public interface IGameBoard
    {
        char[,] GetBoard();
        bool SetTileValue(int i, int j, char value);
        bool ValidateGame();
        void CreateBoard();
    }
    public interface IGameBoardWinner : IGameBoard
    {
        char GetWinner();
        bool IsDraw();
        void PlayerStarts(char player);
    }
}