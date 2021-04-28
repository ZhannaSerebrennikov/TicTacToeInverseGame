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
<<<<<<< HEAD
            UI.PrintGameBoard(gameBoard.m_board);
            while(true)
            {
                //gameBoard.MakeMove();
                game.MakeMove();
                Ex02.ConsoleUtils.Screen.Clear();
                UI.PrintGameBoard(gameBoard.m_board);
            }

        }
    }

    public class Board
    {
        public enum Mark { X, O, Empty };
        private int m_width;
        private int m_height;

        public string[,] m_board;

        private GameMove m_gameMove = new GameMove();
=======
>>>>>>> master

            //create 2 player or one by selection
            if (m_decision == 0)
            {
                UI.CreateTwoPlayer();
            }
<<<<<<< HEAD
        }
        public int BoardHeight
        {
            get
            {
                return m_height;
            }
            set
            {
                m_height = value;
            }
        }
        public Board()
        {
            m_board = new string[m_width, m_height];
        }




        public void CreateBoard()
        {
            while (this.BoardWidth != this.BoardHeight || this.BoardWidth < 3 || this.BoardWidth > 9)
=======
            //
            else if (m_decision == 1)
>>>>>>> master
            {
                UI.CreatOnePlayer();
            }
            UI.PrintGameBoard(gameBoard.m_board);
            while(true)
            {
                gameBoard.MakeMove();
                //bool isValid = GameMove.IsValidMove(ref gameBoard);
                Ex02.ConsoleUtils.Screen.Clear();
                UI.PrintGameBoard(gameBoard.m_board);
            }

<<<<<<< HEAD
        public void MakeMove(string i_mark)
        {
            m_gameMove.MakeMove();
            for (int i = 0; i < this.m_width; i++)
            {
                for (int j = 0; j < this.m_height; j++)
                {
                    if (i == (m_gameMove.Column - 1) && j == (m_gameMove.Row - 1))
                    {
                        //this.m_board[i, j] = String.Copy(m_gameMove.Player);
                        this.m_board[i, j] = String.Copy(i_mark);
                    }
                }
            }
=======
>>>>>>> master
        }
    }

}
