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

        public int BoardWidth
        {
            get
            {
                return m_width;

            }
            set
            {
                m_width = value;            
            }
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
            {
                UI.PrintErrorMessage();
                UI.GetWidthAndHeightFromUser(ref this.m_width, ref this.m_height);
            }

            this.m_board = new string[this.m_width, this.m_height];
            this.initialisateBoard();
        }

        private void initialisateBoard()
        {
            for (int i = 0; i < this.m_width; i++)
            {
                for (int j = 0; j < this.m_height; j++)
                {
                    this.m_board[i, j] = " ";
                }
            }
        }

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
        }
    }

    public class GameMove
    {
        private int m_column;
        private int m_row;
        private string m_player;
        public int Column
        {
            get
            {
                return m_column;
            }
            set
            {
                m_column = value;
            }
        }

        public int Row
        {
            get
            {
                return m_row;
            }
            set
            {
                m_row = value;
            }
        }

        public string Player
        {
            get
            {
                return m_player;
            }
            set
            {
                m_player = value;
            }
        }


        public void MakeMove()
        {
            UI.MakeMove(ref m_column, ref m_row, ref m_player);

        }

    }
}
