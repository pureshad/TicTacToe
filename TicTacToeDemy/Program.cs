namespace TicTacToeDemy
{
    static class Program
    {
        static void Main(string[] args)
        {
            var gameBoard = new GameBoard(new string[,]
                 {
                    { "1","2","3" },
                    { "4","5","6" },
                    { "7","8","9" }
                 });

            var mnger = new BoardManager(gameBoard);

            mnger.StartGame(mnger, gameBoard);
        }
    }
}
