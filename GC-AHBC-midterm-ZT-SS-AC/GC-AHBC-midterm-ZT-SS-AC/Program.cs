using System;
using System.Collections.Generic;

namespace GC_AHBC_midterm_ZT_SS_AC
{
    class Program
    {
        static void Main(string[] args)
        {
            bool runProgramAgain = true;
            string userInput = "";

            do//repeats the program if the user chooses
            {
                Console.WriteLine("Hello and welcome to Jitters Coffee House!");
                Menu:
                //displays the menu and prices for items available at the shop 
                Console.WriteLine("Please see the menu below: ");
                Console.WriteLine("-------------------------------");
                Console.WriteLine($"{Menu.menuItem1}). Menu Item 1 -- Price");
                Console.WriteLine($"{Menu.menuItem2}). Menu Item 2 -- Price");
                Console.WriteLine($"{Menu.menuItem3}). Menu Item 3 -- Price");
                Console.WriteLine($"{Menu.menuItem4}). Menu Item 4 -- Price");
                Console.WriteLine($"{Menu.menuItem5}). Menu Item 5 -- Price");
                Console.WriteLine($"{Menu.menuItem6}). Menu Item 6 -- Price");
                Console.WriteLine($"{Menu.menuItem7}). Menu Item 7 -- Price");
                Console.WriteLine($"{Menu.menuItem8}). Menu Item 8 -- Price");
                Console.WriteLine($"{Menu.menuItem9}). Menu Item 9 -- Price");
                Console.WriteLine($"{Menu.menuItem10}). Menu Item 10 -- Price");
                Console.WriteLine($"{Menu.menuItem11}). Menu Item 11 -- Price");
                Console.WriteLine($"{Menu.menuItem12}). Menu Item 12 -- Price");

                //list of items the patron has ordered 
                List<ImenuItem> currentOrderList = new List<ImenuItem>();


                //bool value that allows them to loop and order another item 
                bool orderAnotherItem = true;
                while (orderAnotherItem)
                {
                    Console.WriteLine("Please enter the number preceeding the item you would like to order: ");




                }




                TryAgain:
                Console.WriteLine("Would you like to repeat the program?");
                Console.Write("Enter y to coninue or anything else to quit: ");
                userInput = Console.ReadLine();
                if (userInput.Trim().ToLower() == "y")
                {
                    runProgramAgain = true;
                }
                else
                {
                    runProgramAgain = false;
                }




            } while (runProgramAgain);

            Exit:
            Console.WriteLine("Thank you for shopping at Jitters Coffee House!");
            Console.WriteLine("Please press any key to continue: ");
            Console.ReadKey();









        }

        
    }
}
