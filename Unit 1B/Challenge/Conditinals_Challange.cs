using System;

namespace Project_Testing {
    class test{
        static void Main(string[] args)
        {
            //Challenge 1 - Temperature Advisor
            //Uses comparison and the & logic operators to check if a given temperature is within a set of defined ranges

            Console.Write("What is today's temperature in Celsius: ");
            int temp = int.Parse(Console.ReadLine());

            if (temp >= 30) {
                Console.WriteLine("Stay out of the sun and stay hydrated.");
            }
            else if (temp < 30 & temp >= 20) {
                Console.WriteLine("The weather is nice, go outside for a while.");
            }

            else if (temp < 20 & temp >= 10) {
                Console.WriteLine("It's cold today, please bring a light jacket.");
            }

            else {
                Console.WriteLine("Please bring a heavy jacket and make sure to wear warm clothing.");
            }

            //Challenge 2 - Exam grader
            //Checking the grade to various ranges of 60 to 90 with any grade lower than 60 being an F
            //Also gives personalized messages based on the subject
            Console.Write("Please enter a grade: ");
            int grade = int.Parse(Console.ReadLine());

            Console.Write("Please enter a subject: ");
            string subject = Console.ReadLine();

            if (grade >= 90) {
                
                Console.Write("A. ");
                
                //Each switch statement takes the lowercase (.ToLower())version of the subject input to determine an appropriate response
                switch(subject.ToLower()) {
                    case "english":
                        Console.WriteLine("You read and write well, way to go!");
                        break;
                    case "math":
                        Console.WriteLine("Math is tough, way to go!");
                        break;
                    case "history":
                        Console.WriteLine("History is pretty boring, but you did it!");
                        break;
                    default:
                        Console.WriteLine("You are officialy a (non)expert of " + subject);
                        break;
                }
            }

            else if (grade >= 80) {
                
                Console.Write("B. ");
                switch (subject.ToLower()) {
                    case "english":
                        Console.WriteLine("Keep writing those words goodly!");
                        break;
                    case "math":
                        Console.WriteLine("You'll be an exceptional mathmatician in no time, keep pushing for that A.");
                        break;
                    case "history":
                        Console.WriteLine("History is easy as long as you put your miond to it, keep working for that A.");
                        break;
                    default:
                        Console.WriteLine("Almost there to being an expert in " + subject);
                        break;
                }
            }

            else if (grade >= 70) {
                
                Console.Write("C. ");
                switch (subject.ToLower()) {
                    case "english":
                        Console.WriteLine("Hopefully writting essays isn't as painful as writting this code. Keep trying.");
                        break;
                    case "math":
                        Console.WriteLine("It's not easy to be good at math, Keep working on it.");
                        break;
                    case "history":
                        Console.WriteLine("Keep reading and keep taking good notes, you got this.");
                        break;
                    default:
                        Console.WriteLine("An average score, keep trying and you'll be a master at " + subject + " in no time.");
                        break;
                }
            }

            else if (grade >= 60) {

                Console.WriteLine("D. ");
                switch (subject.ToLower()) {
                    case "english":
                        Console.WriteLine("As a native English speaker, English sucks. But you need to work harder.");
                        break;
                    case "math":
                        Console.WriteLine("Math is tough, but that's no excuse for poor grades");
                        break;
                    case "history":
                        Console.WriteLine("Take better notes and stop sleeping. History isn't that hard");
                        break;
                    default:
                        Console.WriteLine("Careful, study harder so you don't suck at " + subject);
                        break;
                }
            }

            else {
                Console.Write("F. ");

                switch (subject.ToLower()) {
                    case "english":
                        Console.WriteLine("Please brush up on basic grammar and other English essentials.");
                        break;
                    case "math":
                        Console.WriteLine("Math sucks, I get it. Please brush up on your times tables and other Mathmatical basics.");
                        break;
                    case "history":
                        Console.WriteLine("Please take better notes and reread everything for history.");
                        break;
                    default:
                        Console.WriteLine("Please review the basics of " + subject);
                        break;
                }
            }
        }
    }
}