using System;

namespace B21_Ex02
{
    class Program
    {
        static int width = 0;
        static int height = 0;
        static int m_decision = 0;
        public static void Main()
        {
            Board gameBoard = new Board();
            Game game = new Game();

            UI.GetWidthAndHeightFromUser(ref width, ref height);
            gameBoard.BoardWidth = width;
            gameBoard.BoardHeight = height;

            gameBoard.CreateBoard();
            game.GetBoard(gameBoard);


            /////////////////////////////////not correct place
            UI.IfGameAgainstCompDecision(ref m_decision);
            while (m_decision == 99)//???????????
            {
                UI.PrintErrorMessage();
                UI.IfGameAgainstCompDecision(ref m_decision);
            }
            /////////////////////////////////////////////////

            //create 2 player or one by selection
            if (m_decision == 0)
            {
                UI.CreateTwoPlayer();
            }
            //
            else if (m_decision == 1)
            {
                UI.CreatOnePlayer();
            }
            UI.PrintGameBoard(gameBoard.m_board);
            while(true)
            {
               // game.MakeMove(gameBoard.m_board);
                game.MakeMove();
                //bool isValid = GameMove.IsValidMove(ref gameBoard);
                Ex02.ConsoleUtils.Screen.Clear();
                UI.PrintGameBoard(gameBoard.m_board);
            }

        }
    }

}
