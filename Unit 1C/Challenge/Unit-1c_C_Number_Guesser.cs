using System;

namespace unit_1c_challenge
{
    class program
    {
        static void Main(string[] args)
        {

            var random = new Random();            //To generate random numbers, I first need to create an instance of the Random class to use it's functions.
            
            int number = random.Next(1, 11);      //Using random.Next to generate a number between 1 and 10 (it is excluding 11
            int num_guesses = 3;

            /*
             * MAIN Game loop
             * Player has 3 guesses - each incorrect guess they get a hint.
             * If they are correct they win, otherwise they loose.
             */

            //Using a while loop because I want the user to keep playing after they guess. I wanted to use an infinite while loop because
            //it will be easier to modifiy the conditionals. A for loop would also work here as well but for games I prefer while loops.
            while(true)
            {
                //Once the user runs out of guesses, I want this conditional to run a game over message at the START.
                //I don't want them guessing and then getting a game over
                if (num_guesses == 0)
                {
                    Console.WriteLine("Sorry, you're out of guesses. The correct number was: " + number);
                    break;
                }

                Console.WriteLine("Pick a number between 1 and 10: ");
                int guess = int.Parse(Console.ReadLine());

                if (guess > number)
                {
                    Console.WriteLine("Lower");
                    num_guesses--;
                }

                else if(guess < number)
                {
                    Console.WriteLine("Higher");
                    num_guesses--;
                }

                else
                {
                    Console.WriteLine("Correct!");
                    break;
                }
            }
        }
    }
}