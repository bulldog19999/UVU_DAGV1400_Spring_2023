using System;

namespace MyApplication {
    class Program {
        static void Main(string[] args) {
            //All of my below veriables are declared using type varName = data;
            //The data is assigned to each variable using the assignment operator =.
            //Easily confused with the comparison operator ==.

            string firstName = "Michael";
            string lastName = "Brumwell";

            int depositAmount = 25;

            float tax = 0.03F;
            double dollars = 20.0F;
            double withdrawMinimum = 100.0D;

            bool canWithdraw;


            //------------------------------------ARITHMATIC OPERATORS-----------------------------


            string fullName = firstName + " " + lastName;                                      //Combining first and last names to get a full name         
            Console.WriteLine("My name is: " + fullName);                                      //Prints Michael Brumwell

            dollars += depositAmount;                                                          //Adding money(depositeAmount) to our current total, using += to add and reassign the result
            Console.WriteLine("Checking: $" + dollars);                                        //Prints 45 (20 + 25)

            Console.WriteLine("3% of our total is: " + dollars * tax);                         //Checking 3% of 45 (1.35) ... SHOULD BE but because of how computers work it returns 1.349999...

            dollars -= (dollars * tax);                                                        //Take the taxed amomunt from current total: (45 - 1.35)
            Console.WriteLine(dollars);                                                        //Prints 43.65 or a little less because of line 24


            //----------------------------------COMPARISON OPERATORS------------------------------
            //Great to use when you need to use as checks with if/else statements

            Console.WriteLine("Can you withdraw money? " + (dollars >= withdrawMinimum));      //Checks if 43 >= 100 --> prints FALSE


            //I wanted to write this if/else statement to help
            //demonsrate the use case of comparisons

            if(dollars >= withdrawMinimum){
                canWithdraw = true;                                                            //Will not be set to true
            }
            else{
                canWithdraw = false;                                                           //Will be executed
            }

            Console.WriteLine(canWithdraw);                                                    


            //In games, we can make decisions or return information based on how much health a player has compared to their maximum health.
            int maxHealth = 10;
            int currentHealth = 9;

            Console.WriteLine("Is current health less than max health? " + (currentHealth < maxHealth));               //True -> Player has taken damage
            Console.WriteLine("Is current health different than max health? " + (currentHealth != maxHealth));         //True -> Same result as above.
            Console.WriteLine("Is player at full health? " + (currentHealth == maxHealth));                            //False


            //------------------------------------LOGICAL OPERATORS----------------------------------
            //Are best to be combined the result of comparison operators and booleans variables to execute decision trees
            //Can also be used to check within ranges when using numbers

            int x = 20;
            int y = 5;
            int z = -10;

            Console.WriteLine(x < y && x >= z);                   //20 < 5 (False) AND 20 >= -10 (True) -> Prints FALSE because one part of the expression is false
            Console.WriteLine(x > y && x >= z);                   //20 > 5 (True) AND 20 >= -10  (True) -> Prints TRUE because both conditions are true
            Console.WriteLine(x < y || x >= z);                   //20 < 5 (False) OR 20 >= -10 (True) -> Prints True because one conditional is true

            //Declared a boolean variable to have as an extra example to check if a player is dead
            bool isDead = false;

            Console.WriteLine("Is the player dead? "+ (isDead || (currentHealth == 0)));      //False, both conditions are false and the Player is still alive
        }
    }
}