using System;
using System.Text.RegularExpressions;

namespace TicTacToeDemy
{
    public class BoardManager
    {
        private readonly GameBoard _gameBoard;
        private Players Players;
        private bool IsWinner = false;
        private int turns = 0;

        public BoardManager(GameBoard gameBoard)
        {
            _gameBoard = gameBoard;
        }

        private bool CheckColumnTest(GameBoard gameBoard, string playerChoice)
        {
            var numOnly = new Regex(@"^(\d{1,9})\b");
            const bool IsEmpty = false;

            for (int x = 0; x < gameBoard.Board.GetLength(0); x++)
            {
                for (int y = 0; y < gameBoard.Board.GetLength(1); y++)
                {
                    if (!numOnly.IsMatch(playerChoice))
                    {
                        Console.WriteLine("Wrong input.. please try again..\n");
                        CheckTurn(gameBoard);
                    }

                    if (Players.ToString().Equals(nameof(Players.Player1)))
                    {
                        if (gameBoard.Board[x, y] != playerChoice)
                            continue;
                        else
                            return ChoicePlayer(gameBoard, IsEmpty, x, y);
                    }
                    else if (gameBoard.Board[x, y] != playerChoice)
                    {
                        continue;
                    }
                    else
                    {
                        return ChoicePlayer(gameBoard, IsEmpty, x, y);
                    }
                }
            }
            return IsEmpty;
        }

        private bool ChoicePlayer(GameBoard gameBoard, bool IsEmpty, int x, int y)
        {
            switch (Players)
            {
                case Players.Player1:
                    gameBoard.Board[x, y] = "X";
                    Console.Clear();
                    turns++;
                    Players++;
                    DrawGameBoard(gameBoard);
                    CheckForWinner(IsWinner, gameBoard);
                    CheckTurn(gameBoard);
                    return IsEmpty;

                case Players.Player2:
                    gameBoard.Board[x, y] = "O";
                    Console.Clear();
                    turns++;
                    Players--;
                    DrawGameBoard(gameBoard);
                    CheckForWinner(IsWinner, gameBoard);
                    CheckTurn(gameBoard);
                    return IsEmpty;
            }
            return IsEmpty;
        }

        public void StartGame(BoardManager boardManager, GameBoard board)
        {
            boardManager.DrawGameBoard(board);
            CheckTurn(board);
        }

        private void ResetGame()
        {
            Console.Clear();

            var game = new GameBoard(new string[,]
                 {
                    { "1","2","3" },
                    { "4","5","6" },
                    { "7","8","9" }
                 });

            var mangr = new BoardManager(game);
            mangr.StartGame(mangr, game);
        }

        private bool CheckForWinner(bool isWin, GameBoard gameBoard)
        {
            CheckCombination1(gameBoard);
            CheckCombination2(gameBoard);

            return isWin;
        }

        private void CheckCombination2(GameBoard gameBoard)
        {
            if ((gameBoard.Board[0, 0].Equals("O") && gameBoard.Board[0, 1].Equals("O") && gameBoard.Board[0, 2].Equals("O"))
                || (gameBoard.Board[1, 0].Equals("O") && gameBoard.Board[1, 1].Equals("O") && gameBoard.Board[1, 2].Equals("O"))
                || (gameBoard.Board[0, 0].Equals("O") && gameBoard.Board[1, 0].Equals("O") && gameBoard.Board[2, 0].Equals("O"))
                || (gameBoard.Board[0, 1].Equals("O") && gameBoard.Board[1, 1].Equals("O") && gameBoard.Board[2, 1].Equals("O"))
                || (gameBoard.Board[0, 2].Equals("O") && gameBoard.Board[1, 2].Equals("O") && gameBoard.Board[2, 2].Equals("O"))
                || (gameBoard.Board[0, 0].Equals("O") && gameBoard.Board[1, 1].Equals("O") && gameBoard.Board[2, 2].Equals("O"))
                || (gameBoard.Board[2, 0].Equals("O") && gameBoard.Board[1, 1].Equals("O") && gameBoard.Board[0, 2].Equals("O"))
                || (gameBoard.Board[2, 0].Equals("O") && gameBoard.Board[1, 1].Equals("O") && gameBoard.Board[0, 2].Equals("O")))
            {
                Console.WriteLine("Player 2 Wins!");
                IsWinner = true;
                string choise = "";

                choise = PlayAgainOrExit(gameBoard, choise);

                Console.Read();
            }
            else if (turns >= 9)
            {
                Console.WriteLine("A Draw!!");
                IsWinner = false;
                string choise = "";

                choise = PlayAgainOrExit(gameBoard, choise);

                Console.Read();
            }
        }

        private void CheckCombination1(GameBoard gameBoard)
        {
            if ((gameBoard.Board[0, 0].Equals("X") && gameBoard.Board[0, 1].Equals("X") && gameBoard.Board[0, 2].Equals("X"))
                || (gameBoard.Board[1, 0].Equals("X") && gameBoard.Board[1, 1].Equals("X") && gameBoard.Board[1, 2].Equals("X"))
                || (gameBoard.Board[2, 0].Equals("X") && gameBoard.Board[2, 1].Equals("X") && gameBoard.Board[2, 2].Equals("X"))
                || (gameBoard.Board[0, 0].Equals("X") && gameBoard.Board[1, 0].Equals("X") && gameBoard.Board[2, 0].Equals("X"))
                || (gameBoard.Board[0, 1].Equals("X") && gameBoard.Board[1, 1].Equals("X") && gameBoard.Board[2, 1].Equals("X"))
                || (gameBoard.Board[0, 2].Equals("X") && gameBoard.Board[1, 2].Equals("X") && gameBoard.Board[2, 2].Equals("X"))
                || (gameBoard.Board[0, 0].Equals("X") && gameBoard.Board[1, 1].Equals("X") && gameBoard.Board[2, 2].Equals("X"))
                || (gameBoard.Board[2, 0].Equals("X") && gameBoard.Board[1, 1].Equals("X") && gameBoard.Board[0, 2].Equals("X")))
            {
                Console.WriteLine("Player 1 Wins!\n");
                IsWinner = true;
                string choise = "";
                choise = PlayAgainOrExit(gameBoard, choise);

                Console.Read();
            }
            else if (turns >= 9)
            {
                Console.WriteLine("A Draw!!");
                IsWinner = false;
                string choise = "";
                choise = PlayAgainOrExit(gameBoard, choise);

                Console.Read();
            }
        }

        private string PlayAgainOrExit(GameBoard gameBoard, string choise)
        {
                Console.WriteLine("Would you like to play again? y/n");
                choise = Console.ReadLine();
                if (choise.Equals("y"))
                {
                    ResetGame();
                }
                if (choise.Equals("n"))
                {
                    Console.WriteLine("Thanks for playing!\n");
                    Console.WriteLine("Press any key to exit.");
                    Console.ReadLine();
                    Environment.Exit(0);
                }
                else if (!choise.Equals("y") && !choise.Equals("n"))
                {
                    Console.WriteLine("Wrong Input! please try again..\n");
                    CheckForWinner(IsWinner, gameBoard);
                }

            return choise;
        }

        private void DrawGameBoard(GameBoard gameBoard)
        {
            Console.WriteLine("     |     |     |");

            Console.WriteLine("  {0}  |  {1}  |  {2}  |", gameBoard.Board[0, 0], gameBoard.Board[0, 1], gameBoard.Board[0, 2]);

            Console.WriteLine("-----|-----|-----|");

            Console.WriteLine("  {0}  |  {1}  |  {2}  |", gameBoard.Board[1, 0], gameBoard.Board[1, 1], gameBoard.Board[1, 2]);

            Console.WriteLine("-----|-----|-----|");

            Console.WriteLine("  {0}  |  {1}  |  {2}  |", gameBoard.Board[2, 0], gameBoard.Board[2, 1], gameBoard.Board[2, 2]);

            Console.WriteLine("-----|-----|-----|");

            CheckForWinner(IsWinner, gameBoard);
        }

        private void CheckTurn(GameBoard gameBoard)
        {
            string choise = "";
            switch (Players)
            {
                case Players.Player1:
                    Console.WriteLine("Player 1 Turn, Please Make Your choice");
                    choise = Console.ReadLine();

                    CheckColumnTest(gameBoard, choise);
                    break;

                case Players.Player2:
                    Console.WriteLine("Player 2 turn, Please Make Your choice");
                    choise = Console.ReadLine();

                    CheckColumnTest(gameBoard, choise);
                    break;
                default:
                    Console.WriteLine("No one Played..");
                    break;
            }
        }
    }
}
