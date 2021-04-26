using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B21_Ex02
{
    public class Board
    {
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

        public void MakeMove()
        {
            m_gameMove.MakeMove();
            for (int i = 0; i < this.m_width; i++)
            {
                for (int j = 0; j < this.m_height; j++)
                {
                    if (i == (m_gameMove.Column - 1) && j == (m_gameMove.Row - 1))
                        this.m_board[i, j] = String.Copy(m_gameMove.Player);
                }
            }
        }
    }
}
