using System;

namespace unit_1c_challenge
{
    class program
    {
        static void Main(string[] args)
        {
            //Using the below statement, I also prompt the user for three food items to store in variables
            Console.WriteLine("Please enter your three favorite foods.");
            string first_food = Console.ReadLine();
            string second_food = Console.ReadLine();
            string third_food = Console.ReadLine();

            //After creating three food variables, I store them in a string array
            string[] fav_foods = {first_food, second_food, third_food};

            //Using the foreach() loop method, I use it to print a message for every item in the array
            foreach(string food in fav_foods)
            {
                Console.WriteLine(food + " is one of my favorite foods");
            }
        }
    }
}