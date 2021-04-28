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

        private int r_LengthBorad = 0;

        int numberOfMoves = 0;
        private char[,] m_board;

       // private GameMove m_gameMove = new GameMove();

        public char[,] GetBorad()
        {
            return m_board; 
        }

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
        public int NumberOfLength
        {
            get
            {
                return r_LengthBorad;

            }
            set
            {
                r_LengthBorad = value;
            }
        }
        public int NumberOfMove
        {
            get
            {
                return numberOfMoves;

            }
            set
            {
                numberOfMoves = value;
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

        public Board(int lengthBorad)
        {
            m_board = new char[lengthBorad, lengthBorad];
            r_LengthBorad = lengthBorad;

            this.initialisateBoard();

        }

        public void CreateBoard()
        {
            // while (this.BoardWidth != this.BoardHeight || this.BoardWidth < 3 || this.BoardWidth > 9)

            this.initialisateBoard();
        }

        private void initialisateBoard()
        {
            for (int i = 0; i < r_LengthBorad; i++)
            {
                for (int j = 0; j < r_LengthBorad; j++)
                {
                    this.m_board[i, j] = ' ';
                }
            }
        }

        //check if the move is valid and after make the move
        
        public bool MoveIsValid(int rowMove, int colMove)
        {
            bool isValid = false;

            if (
                (0 <= rowMove && rowMove <= r_LengthBorad) &&
                (0 <= colMove && colMove <= r_LengthBorad) &&
                m_board[rowMove - 1, colMove - 1] == ' '
                )
            {
                MakeMove(rowMove, colMove);
                isValid = true;
            }

            return isValid;
        }

        public void GameReset()
        {
            //need to ask if the player want anoter game
            this.initialisateBoard();

            numberOfMoves = 0;

        }

        public bool CheckWin()
        {
            // check the oblique line      /   , \

            char enemyLetter = Player1 == nowPlayingPlayer ? Player2 : Player1;

            bool answer = true;
            for (int i = 0; i < r_LengthBorad; i++) // Check \
            {
                if (m_board[i, i] != enemyLetter)
                {
                    answer = false;
                    break;
                }
            }

            if (answer == false) // Check /
            {
                answer = true;
                for (int i = 0; i < r_LengthBorad; i++)
                {
                    if (m_board[i, r_LengthBorad - i - 1] != enemyLetter)
                    {
                        answer = false;
                        break;
                    }
                }
            }

            if (answer == false) //Check |  Cols
            {
                for (int i = 0; i < r_LengthBorad; i++)
                {
                    answer = true;

                    for (int k = 0; k < r_LengthBorad; k++)
                    {
                        if (m_board[i, k] != enemyLetter)
                        {
                            answer = false;
                            break;
                        }
                    }

                    if (answer == true)
                    {
                        break;
                    }
                    
                }
            }

            if (answer == false) //Check -- Rows
            {
                for (int i = 0; i < r_LengthBorad; i++)
                {
                    answer = true;

                    for (int k = 0; k < r_LengthBorad; k++)
                    {
                        if (m_board[k, i] != enemyLetter)
                        {
                            answer = false;
                            break;
                        }
                    }

                    if (answer == true)
                    {
                        break;
                    }
                }
            }


            //if (answer == true)
            //{
            //    for (int i = 0; i < r_LengthBorad; i++)
            //    {
            //        if (m_board[i, r_LengthBorad - i - 1] != enemyLetter)
            //        {
            //            answer = false;
            //            break;
            //        }
            //    }
            //}


            return answer;
        }

        public bool GameEnd()
        {
            //check if the number of move is equal to the member of array
            return numberOfMoves >= (r_LengthBorad * r_LengthBorad);
        }

        public void MakeMove(int rowMove, int colMove)
        {
            m_board[rowMove - 1, colMove - 1] = nowPlayingPlayer;
            changePlayer();
            numberOfMoves++;
        }

        const char Player1 = 'x', Player2 = 'o';
        char nowPlayingPlayer = Player1;

        private void changePlayer()
        {
            nowPlayingPlayer = nowPlayingPlayer == Player1 ? Player2 : Player1;
        }
    }
}



//public void MakeMove()
//{
//    m_gameMove.MakeMove();
//    for (int i = 0; i < this.m_width; i++)
//    {
//        for (int j = 0; j < this.m_height; j++)
//        {
//            if (i == (m_gameMove.Column - 1) && j == (m_gameMove.Row - 1)) ;
//            //  this.m_board[i, j] = String.Copy(m_gameMove.Player);
//        }
//    }
//}
