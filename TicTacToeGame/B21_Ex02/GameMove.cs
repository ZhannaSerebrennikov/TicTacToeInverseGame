using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B21_Ex02
{
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

        public Boolean IsValidMove(ref Board gameBoard)
        {
            bool isValid = false;
            while (m_column > gameBoard.BoardWidth || m_row > gameBoard.BoardHeight || m_column < 1 || m_row < 1)
            {
                Console.WriteLine("Input invalid!");
                MakeMove();
                isValid = false;
            }
            isValid = true;

            return isValid;
        }
        public Boolean CheckIfThePlaceIsEmpty(ref char[,] gameBoard, ref int[] move)
        {
            int row = move[0] - 1;
            int col = move[1] - 1;
            Boolean isEmpty = true;
            if (gameBoard[row, col] == 'o' || gameBoard[row, col] == 'O' || gameBoard[row, col] == 'X'
                || gameBoard[row, col] == 'x')
            {
                isEmpty = false;
                Console.WriteLine("This Place is not empty! choose new place");
                //UI.MakeMove(ref move);
                //Boolean isvalid = Program.IsValidMove(ref move);
            }
            return isEmpty;
        }

    }
}
