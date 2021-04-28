using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B21_Ex02
{
    class Game
    {
        public enum Players { Player1, Player2 };
        public Players m_currentTurn = Players.Player1;
        public string m_currentMark = "X";

        public Board gameBoard;

        public void GetBoard(Board gameBoard)
        {
            this.gameBoard = gameBoard;
        }

        // public Board.Mark palyer1Mark = Board.Mark.X;
        //public Board.Mark player2Mark = Board.Mark.O;

        public string player1Mark = "X";
        public string player2Mark = "O";

        public ComputerPlayer Player1Obj = new ComputerPlayer();
        public Player Player2Obj = new Player("Moshe");

        public void MakeMove()
        {
            //algoritm
            string playerMark = PlayerMark();
            gameBoard.MakeMove(playerMark);//nikydot x,y
            swapTurns();
        }
        private void swapTurns()
        {
            if (m_currentTurn == Players.Player1)
            {
                m_currentTurn = Players.Player2;
            }
            else
            {
                m_currentTurn = Players.Player1;
            }

        }

        private string PlayerMark()
        {
            //string playerMark = null;
            if (m_currentTurn == Players.Player1)
            {
                m_currentMark = "X";
            }
            else
            {
                m_currentMark = "O";
            }
            return m_currentMark;
        }
    }
}
