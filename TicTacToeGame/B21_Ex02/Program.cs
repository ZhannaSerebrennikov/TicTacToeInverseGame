using System;

namespace B21_Ex02
{
    class Program
    {
        static int m_width = 0;
        static int m_height = 0;
        static int m_decision = 0;
        public static void Main()
        {
            CreateGameBoard();
            char[,] gameBoard = new char[m_width, m_height];
            for(int i = 0; i<gameBoard.GetLength(0); i++)
            {
                for (int j = 0; j < gameBoard.GetLength(1); j++)
                {
                    gameBoard[i, j] = ' ';
                }
            }
            UI.PrintGameBoard(ref gameBoard);
        }
        public static void CreateGameBoard()
        {
            UI.GetWidthAndHeightFromUser(ref m_width, ref m_height);
            while (m_width != m_height || m_width < 3 || m_width > 9)
            {
                UI.PrintErrorMessage();
                UI.GetWidthAndHeightFromUser(ref m_width, ref m_height);
            }

            //=======not correct place ===========
            UI.IfGameAgainstCompDecision(ref m_decision);
            while (m_decision == 99)//???????????
            {
                UI.PrintErrorMessage();
                UI.IfGameAgainstCompDecision(ref m_decision);
            }
            //===========================================
        }
    }


}
