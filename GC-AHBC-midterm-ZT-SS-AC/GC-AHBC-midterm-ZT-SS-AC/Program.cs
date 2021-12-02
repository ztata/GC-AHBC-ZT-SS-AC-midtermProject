using System;
using System.Collections.Generic;
using System.Linq;

namespace GC_AHBC_midterm_ZT_SS_AC
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Full Stack After Hours Bootcamp Midterm Project";

            string addressPath = @"C:\Users\schan\Documents\Web Development\Education\Grand Circus\Full Stack C# .NET Bootcamp\MidTermProject\GC-AHBC-midterm-ZT-SS-AC\productList.txt";

            FileHelper.BuildMenuList(addressPath);

            bool runProgramAgain = true;
            string userInput = "";
            int numberToOrder = -1; 

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
                Menu userMenuSelection;
                while (orderAnotherItem) //while loop repeats while they want to keep ordering 
                {
                    Console.WriteLine("Please enter the number preceeding the item you would like to order: ");
                    userInput = Console.ReadLine();
                    int userChoice = -1;

                    //FIX THE LOOP AROUND THE TRY CATCH//
                    bool validOrderNumber = false;
                    while (validOrderNumber == false)
                    {
                        try //try catch makes sure input is a integer number. will repeat loop if it doesnt work
                        {
                            userChoice = int.Parse(userInput);
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Sorry, that is not a valid input!");
                            continue;
                        }

                        if (userChoice < 1 || userChoice > 12) //makes sure it is a valid number for enum selection
                        {
                            Console.WriteLine("Sorry, your input needs to be between 1 and 12!");
                            continue;
                        }
                        else
                        {
                            validOrderNumber = true;
                        }
                    }
                    userMenuSelection = (Menu)userChoice;
                    bool validOrderQuantity = false;
                    while (validOrderQuantity == false)
                    {
                        Console.WriteLine("How many of these would you like to order?");
                        userInput = Console.ReadLine();
                        try
                        {
                            numberToOrder = int.Parse(userInput);

                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Sorry, that is not a valid input!");
                            validOrderNumber = false;
                        }
                        if (numberToOrder < 1)
                        {
                            Console.WriteLine("Sorry, you can't order less than 1 of an item!");
                        }
                        else
                        {
                            validOrderQuantity = true;
                        }
                    }

                    //switch will add user choice to the list for their current order 
                    switch (userMenuSelection)
                    {
                        case Menu.menuItem1:
                            for (int i = 0; i < numberToOrder; i++)
                            {
                                currentOrderList.Add(/* first item*/);
                            }
                            break;
                        case Menu.menuItem2:
                            for (int i = 0; i < numberToOrder; i++)
                            {
                                currentOrderList.Add(/* second item*/);
                            }
                            break;
                        case Menu.menuItem3:
                            for (int i = 0; i < numberToOrder; i++)
                            {
                                currentOrderList.Add(/* third item*/);
                            }
                            break;
                        case Menu.menuItem4:
                            for (int i = 0; i < numberToOrder; i++)
                            {
                                currentOrderList.Add(/* fourth item*/);
                            }
                            break;
                        case Menu.menuItem5:
                            for (int i = 0; i < numberToOrder; i++)
                            {
                                currentOrderList.Add(/* fifth item*/);
                            }
                            break;
                        case Menu.menuItem6:
                            for (int i = 0; i < numberToOrder; i++)
                            {
                                currentOrderList.Add(/* sixth item*/);
                            }
                            break;
                        case Menu.menuItem7:
                            for (int i = 0; i < numberToOrder; i++)
                            {
                                currentOrderList.Add(/* seventh item*/);
                            }
                            break;
                        case Menu.menuItem8:
                            for (int i = 0; i < numberToOrder; i++)
                            {
                                currentOrderList.Add(/* eighth item*/);
                            }
                            break;
                        case Menu.menuItem9:
                            for (int i = 0; i < numberToOrder; i++)
                            {
                                currentOrderList.Add(/* ninth item*/);
                            }
                            break;
                        case Menu.menuItem10:
                            for (int i = 0; i < numberToOrder; i++)
                            {
                                currentOrderList.Add(/* tenth item*/);
                            }
                            break;
                        case Menu.menuItem11:
                            for (int i = 0; i < numberToOrder; i++)
                            {
                                currentOrderList.Add(/* eleventh item*/);
                            }
                            break;
                        case Menu.menuItem12:
                            for (int i = 0; i < numberToOrder; i++)
                            {
                                currentOrderList.Add(/* twelveth item*/);
                            }
                            break;
                    }

                    Console.WriteLine("Would you like to order another item?");
                    Console.Write("Enter y to continue your order or anything else to proceed to checkout: ");
                    userInput = Console.ReadLine();
                    if (userInput.Trim().ToLower() == "y")
                    {
                        orderAnotherItem = true;
                    }
                    else
                    {
                        orderAnotherItem = false;
                    }
                }


            /*
             * 
             * INSERT LOGIC HERE TO TOTAL THE BILL, RECEIVE PAYMENT, ETC
             * 
             */

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
