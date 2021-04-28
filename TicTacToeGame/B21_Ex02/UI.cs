using System;
using System.Text;

namespace B21_Ex02
{
    public class UI
    {

        private int m_LengthBorad = 0;

        public void GetWidthAndHeightFromUser(out int o_Length)
        {
            // System.Console.WriteLine("Hello! Welcome to Tic Tac Toe inverse game. Please enter width and hight of your matrix! The input should be digits, matrix shold have shape of squre and it shold be not less than 3x3 and not bigger than 9x9.");
            string msg = string.Format(@"Hello!
Welcome to Tic Tac Toe inverse game.
Please enter width and hight of your matrix following the next rools:
1.The input numers should be digits.
2.Matrix shold have shape of squre.
3.Width and height of matrix shold be not less than 3x3.
4.Width and height of matrix shold be not bigger than 9x9.");

            o_Length = 3;

            System.Console.WriteLine(msg);
            string lengthInput;

            // the lenget of the matrix nxn
            System.Console.WriteLine("Please enter length of matrix: ");
            lengthInput = System.Console.ReadLine();

            while (!(int.TryParse(lengthInput, out o_Length) && (3 <= o_Length && o_Length <= 9))) 
            {
                System.Console.WriteLine("Invalid input! Please enter length of matrix: ");
                lengthInput = System.Console.ReadLine();
            }

            m_LengthBorad = o_Length;
        }

        internal void UiPlayersNames(out string nameplayer1, out string nameplayer2)
        {

            Console.WriteLine("Player 1, Please enter your name:");
            nameplayer1 = Console.ReadLine();
            nameplayer2 = null;

            if (!IfGameAgainstCompDecision())
            {
                Console.WriteLine("Player 2, Please enter your name:");
                nameplayer2 = Console.ReadLine();
            }
        }

        // get the next move from the user 
        public void GetInputMove(out int rowNumber,out  int colNumber , string playerName)
        {
            System.Console.WriteLine(" >> {0} >> What is your move ?", playerName);

            string input;

            bool quit = false;

            rowNumber = colNumber = 0;

            while (!quit)
            {
                input = System.Console.ReadLine();

                if (input.ToLower() == "q") 
                {
                    rowNumber = colNumber = -2;
                    break;
                }

                if (input.Length != 2)
                {
                    System.Console.WriteLine("What is your move ?");
                    quit = false;
                }
                else 
                {
                    quit = true;
                }


                if (!int.TryParse(input, out int number) && quit == true)
                {
                    System.Console.WriteLine("Enter Only a Number.");
                    quit = false;
                }


                if (!(quit == true &&
                    int.TryParse(input[0].ToString(), out rowNumber) &&
                    int.TryParse(input[1].ToString(), out colNumber) &&
                    (0 <= rowNumber && rowNumber <= m_LengthBorad) &&
                    (0 <= colNumber && colNumber <= m_LengthBorad)))
                {
                    System.Console.WriteLine("Enter Only a Numbers That In The Borad Length (1) - ({0}).", m_LengthBorad);
                    quit = false;
                }
            }
        }

        public static void PrintErrorMessage()
        {
            System.Console.WriteLine("User input was incorrect. Please try againe.");
        }

        public bool IfGameAgainstCompDecision()
        {
            //System.Console.WriteLine("Press 0 if the game of two players or press 1 if the game against the computer?");
            System.Console.WriteLine("Press 0 if want playing against the computer press anything else to game of two players.");
            string decisionInput = System.Console.ReadLine();
            int decision;

            bool answer = false;

            if (int.TryParse(decisionInput, out decision) && decision == 0)
            {
                answer = true;
            }

            return answer;
        }

        /*public static void MakeMove(ref int io_column, ref int io_row, ref string io_palyer)
        {
            System.Console.WriteLine("What is your move ?");
            io_column = Int32.Parse(System.Console.ReadLine());
            io_row = Int32.Parse(System.Console.ReadLine());
            System.Console.WriteLine("And you are ?");
            io_palyer = System.Console.ReadLine();
        }*/

        public void PrintGameBoard(char[,] gameBoard)
        {
            StringBuilder newString = new StringBuilder();
            int rows = gameBoard.GetLength(0);
            int cols = gameBoard.GetLength(1);

            for (int i = 0; i < cols; i++)
            {
                //newString.Append("   {0}", i + 1);
                System.Console.Write("   {0}", i + 1);
            }
            System.Console.WriteLine();
            for (int i = 0; i < rows; i++)
            {
                System.Console.Write("{0}|", i + 1);
                for (int j = 0; j < cols; j++)
                {
                    System.Console.Write(" {0} |", gameBoard[i, j]);
                }
                System.Console.WriteLine();
                System.Console.Write(" ");
                for (int j = 0; j < cols; j++)
                {
                    System.Console.Write("====");
                }
                System.Console.Write("=");
                System.Console.WriteLine();
            }

        }

        private static bool isAllDigits(string i_myString)
        {
            bool v_isAllDigits = true;
            foreach (char c in i_myString)
            {
                if (!char.IsDigit(c))
                {
                    v_isAllDigits = false;
                }
            }

            return v_isAllDigits;
        }

        //public static void CreateTwoPlayer()
        //{
        //    Console.WriteLine("Player 1, Please enter your name:");
        //    string nameplayer1 = Console.ReadLine();
        //    Player player1 = new Player(nameplayer1);

        //    Console.WriteLine("Player 2, Please enter your name:");
        //    string nameplayer2 = Console.ReadLine();
        //    Player player2 = new Player(nameplayer2);
        //}
        //public static void CreatOnePlayer()
        //{
        //    Console.WriteLine(" You Play against the computer, Please enter your name:");
        //    string nameplayer = Console.ReadLine();
        //    Player player = new Player(nameplayer);
        //}

    }
}
