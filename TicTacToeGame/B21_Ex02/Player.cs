using System;


    namespace B21_Ex02
    {
        public class Player
        {
            private string name;
            private int score = 0;

            //constractor
            public Player(string name)
            {
                this.name = name;
            }
            //properties
            public string Name
            {
                get
                {
                    return name;
                }
                set
                {
                    name = value;

                }
            }

            public int Score
            {
                get
                {
                    return score;
                }
                set
                {
                    score = value;
                }
            }

        }
    }


