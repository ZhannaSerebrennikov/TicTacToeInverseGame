using System;
using System.Text;

namespace B21_Ex02
{
    public class UI
    {
        public static void GetWidthAndHeightFromUser(ref int io_width, ref int io_height)
        {
           // System.Console.WriteLine("Hello! Welcome to Tic Tac Toe inverse game. Please enter width and hight of your matrix! The input should be digits, matrix shold have shape of squre and it shold be not less than 3x3 and not bigger than 9x9.");
            string msg = string.Format(@"Hello!
Welcome to Tic Tac Toe inverse game.
Please enter width and hight of your matrix following the next rools:
1.The input numers should be digits.
2.Matrix shold have shape of squre.
3.Width and height of matrix shold be not less than 3x3.
4.Width and height of matrix shold be not bigger than 9x9.");
            System.Console.WriteLine(msg);
            System.Console.WriteLine("Please enter width of matrix: ");
            string width = System.Console.ReadLine();
            if(isAllDigits(width))
            {
                io_width = Int32.Parse(width);
            }
            System.Console.WriteLine("Please enter height of matrix: ");
            string height = System.Console.ReadLine();
            if (isAllDigits(height))
            {
                io_height = Int32.Parse(height);
            }
            
        }

        public static void PrintErrorMessage()
        {
            System.Console.WriteLine("User input was incorrect. Please try againe.");
        }

        public static void IfGameAgainstCompDecision(ref int io_decision)
        {
            System.Console.WriteLine("Press 0 if the game of two players or press 1 if the game against the computer?");
            string decision = System.Console.ReadLine();
            io_decision = Int32.Parse(decision);

            if (!isAllDigits(decision) || io_decision <0 || io_decision>1)
            {
                io_decision = 99;
            }
        }

        public static void MakeMove(ref int io_column, ref int io_row, ref string io_palyer)
        {
            System.Console.WriteLine("What is your move ?");
            io_column = Int32.Parse(System.Console.ReadLine());
            io_row = Int32.Parse(System.Console.ReadLine());
            System.Console.WriteLine("And you are ?");
            io_palyer = System.Console.ReadLine();
        }

        public static void PrintGameBoard(string[,] gameBoard)
        {
            StringBuilder newString = new StringBuilder();
            int rows = gameBoard.GetLength(0);
            int cols = gameBoard.GetLength(1);

            for (int i = 0; i< cols; i++)
            {
                //newString.Append("   {0}", i + 1);
                System.Console.Write("   {0}", i+1);
            }
            System.Console.WriteLine();
            for (int i = 0; i< rows; i++)
            {
                System.Console.Write("{0}|", i + 1);
                for (int j = 0; j < cols; j++)
                {
                    System.Console.Write(" {0} |", gameBoard[i,j]);
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

    }
}
