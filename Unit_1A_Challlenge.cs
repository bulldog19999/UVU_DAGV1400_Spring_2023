using System;

namespace Unit1A_Challenge {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Please enter your first name: ");
            string firstName = Console.ReadLine();

            Console.WriteLine("Please enter your last name: ");
            string lastName = Console.ReadLine();

            Console.WriteLine("Please enter you age: ");
            int age = int.Parse((Console.ReadLine()));

            Console.WriteLine("Please enter a decimal number: ");
            float percentage = float.Parse((Console.ReadLine()));
            
            //Prints user Variables
            Console.WriteLine("First name: " + firstName);
            Console.WriteLine("Last name: " + lastName);
            Console.WriteLine("Your age: " + age);
            Console.WriteLine("Your custom percentage: " + percentage);
             
            //A bit of math using age and user percentage
            Console.WriteLine("This is half of your age: " + (age / 2));
            Console.WriteLine("This is double your age: " + (age * 2));
            Console.WriteLine("This is " + (percentage) + " percent of your age: " + (percentage * age));
            Console.WriteLine("This is your age minus your custom input: " + (age - percentage));
        }
    }
}