namespace TicTacToeDemy
{
    public class GameBoard
    {
        private string[,] BoardMatrix { get; }

        public GameBoard(string[,] boardMatrix)
        {
            BoardMatrix = boardMatrix;
        }


        public string[,] Board
        {
            get
            {
                return BoardMatrix;
            }
            set
            {
                Board = value;
            }
        }
    }
}
