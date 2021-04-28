using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B21_Ex02
{
    public class GameMove
    {
        private Player m_Player1;
        private Player m_Player2;

        public const bool Player1Tag = true, Player2Tag = false;

        bool m_PlayingPlayer = Player1Tag;

        UI r_Ui;
        Board board;

        //switch the turn of the player
        public void ChangePlayer()
        {
            m_PlayingPlayer = m_PlayingPlayer == Player1Tag ? Player2Tag : Player1Tag;
        }

        public GameMove()
        {
            r_Ui = new UI();
        }

        public void InitGame()
        {

            int lengthBorad = 0;
            r_Ui.GetWidthAndHeightFromUser(out lengthBorad);
            board = new Board(lengthBorad);

            string player1Name;
            string player2Name;

            r_Ui.UiPlayersNames(out player1Name, out player2Name);

            if (player2Name == null)
            {
                player2Name = "Computer";
            }

            m_Player1 = new Player(player1Name);
            m_Player2 = new Player(player2Name);



        }

        public void StartGame()
        {

            // r_Ui.PrintGameBoard(board.GetBorad());

            int rowMove, colMove;

            while (true)
            {
                r_Ui.PrintGameBoard(board.GetBorad());

                string playerName = m_PlayingPlayer == Player1Tag ? m_Player1.Name : m_Player2.Name;

                r_Ui.GetInputMove(out rowMove, out colMove, playerName);
                Ex02.ConsoleUtils.Screen.Clear();

                if (rowMove < 0)
                {
                    Console.WriteLine("Game Quit . :)");
                    break;
                }

                if (!board.MoveIsValid(rowMove, colMove))
                {
                    Console.WriteLine("The Move is Invalid please try again.");
                }
                else
                {
                    ChangePlayer();
                }
                // everty time the player make move we need to check if someone win
                bool checkWin = board.CheckWin();
                if (checkWin || board.NumberOfMove==(board.NumberOfLength*board.NumberOfLength) )
                {
                    Player player = m_PlayingPlayer != Player1Tag ? m_Player2 : m_Player1;
                    //int score =+ player.Score;
                    Console.WriteLine("The Winner is {0} !! , with {1} points "
                        , player.Name , ++player.Score);
                    Console.WriteLine("Are you want to play again? press Y or N");
                    Console.ReadLine();
                }

                if (!checkWin && board.GameEnd()) 
                {
                    Console.WriteLine("Draw!!!!!!! Game Over , {0} : {1} vs  {2} : {3}",m_Player1.Name , m_Player1.Score, m_Player2.Name , m_Player2.Score);
                }


                if (!checkWin && board.GameEnd()) 
                {
                    board.GameReset();
                }

            }

        }
    }
}
