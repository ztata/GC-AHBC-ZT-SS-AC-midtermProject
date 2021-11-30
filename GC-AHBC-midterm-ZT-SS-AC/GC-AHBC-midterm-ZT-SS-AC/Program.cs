using System;

namespace GC_AHBC_midterm_ZT_SS_AC
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Full Stack After Hours Bootcamp Midterm Project";

            string addressPath = @"C:\Users\schan\Documents\Web Development\Education\Grand Circus\Full Stack C# .NET Bootcamp\MidTermProject\GC-AHBC-midterm-ZT-SS-AC\productList.txt";

            FileHelper.BuildMenuList(addressPath);


                //bool value that allows them to loop and order another item 
                bool orderAnotherItem = true;
                while (orderAnotherItem)
                {
                    Console.WriteLine("Please enter the number preceeding the item you would like to order: ");
                    userInput = Console.ReadLine();
                    int userChoice = -1;
                    try
                    {
                        userChoice = int.Parse(userInput);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Sorry, that is not a valid input!");
                        continue;
                    }

                    if (userChoice < 1 || userChoice > 12)
                    {
                        Console.WriteLine("Sorry, your input needs to be between 1 and 12!");
                        continue;
                    }
                    else
                    {
                        Menu userMenuSelection = (Menu) userChoice;
                    }

                    


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
