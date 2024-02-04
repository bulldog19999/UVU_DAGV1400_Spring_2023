using System;

namespace console_app_1 
{
    class program 
    {
        static void Main(string[] args) 
        {

            int pyramid_lines;

            //Get user Input and convert to int. Using an infinite while loop to prevent user 
            //from finishing the code with an invalid number (any negative or 0 number)
            while (true)
            {
                Console.WriteLine("Please type a number for the pyramid: ");
                pyramid_lines = int.Parse(Console.ReadLine());
                Console.WriteLine();

                if (pyramid_lines > 0)  //Checks if input is positive number
                {
                    break;
                }
            }

            for(int line = 1; line <= pyramid_lines; line++)
            {
                for(int num = 0; num < line; num++)
                {
                    Console.Write((line));  //Write the current line number line amount of times per line
                }
                Console.WriteLine();        //Add a new line after numbers have been printed
            }
        }
    }
}