//TODO:
//Update using challenge prompts

using System;

namespace conditionals_switches_Lab {
    class program {
        static void Main(string[] args) {

            //Challenge 1 - Temperature Advisor - Done
            //two if statements which execute based on user input

            Console.Write("What is today's temperature in Celsius: ");
            int temp = int.Parse(Console.ReadLine());

            if (temp > 30)
            {
                Console.WriteLine("Stay out of the sun and stay hydrated.");
            }
            if (temp < 30)
            {
                Console.WriteLine("The weather is nice, go outside for a while.");
            }

            //Challenge 2 - Exam grader - Done
            //Checking the grade to various ranges of 60 to 90 with any grade lower than 60 being an F
            Console.Write("Please enter a grade: ");
            int grade = int.Parse(Console.ReadLine());

            if (grade >= 90) {
                Console.WriteLine("A. Great Job!");
            }
            else if (grade >= 80) {
                Console.WriteLine("B. Almost there!");
            }
            else if (grade >= 70) {
                Console.WriteLine("C. Average.");
            }
            else if (grade >= 60) {
                Console.WriteLine("D. You need to work harder.");
            }
            else {
                Console.WriteLine("F. You REALLY need to work harder.");
            }

        }
    }
}