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

            string addressPath = @"C:\Users\schan\Documents\Web Development\Education\Grand Circus\Full Stack C# .NET Bootcamp\MidTermProject\GC-AHBC-midterm-ZT-SS-AC\MenuItems.txt";

            Product[] productList =  FileHelper.BuildMenuList(addressPath);

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
                Console.WriteLine($"{Menu.caffeMocha}). Caffe Mocha -- $4.95");
                Console.WriteLine($"{Menu.caffeAmericano}). Caffe Americano -- $3.95");
                Console.WriteLine($"{Menu.cappucino}). Cappucino -- $5.95");
                Console.WriteLine($"{Menu.caffeMisto}). Caffe Misto -- $2.95");
                Console.WriteLine($"{Menu.chaiTeaLatte}). Chai Tea Latte -- $3.95");
                Console.WriteLine($"{Menu.londonFogTeaLatte}). London Fog Tea Latte -- $2.95");
                Console.WriteLine($"{Menu.matchaTeaLatte}). Matcha Tea Latte -- $4.95");
                Console.WriteLine($"{Menu.earlGrey}). Earl Grey -- $2.95");
                Console.WriteLine($"{Menu.cranberryScones}). Cranberry Scone -- $6.25");
                Console.WriteLine($"{Menu.icedLemonLoaf}). Iced Lemon Loaf -- $5.95");
                Console.WriteLine($"{Menu.vanillaBeanScone}). Vanilla Bean Scone -- $2.25");
                Console.WriteLine($"{Menu.plainBagel}). Plain Bagel -- $2.95");

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
                        case Menu.caffeMocha:
                            for (int i = 0; i < numberToOrder; i++)
                            {
                                currentOrderList.Add(/* first item*/);
                            }
                            break;
                        case Menu.caffeAmericano:
                            for (int i = 0; i < numberToOrder; i++)
                            {
                                currentOrderList.Add(/* second item*/);
                            }
                            break;
                        case Menu.cappucino:
                            for (int i = 0; i < numberToOrder; i++)
                            {
                                currentOrderList.Add(/* third item*/);
                            }
                            break;
                        case Menu.caffeMisto:
                            for (int i = 0; i < numberToOrder; i++)
                            {
                                currentOrderList.Add(/* fourth item*/);
                            }
                            break;
                        case Menu.chaiTeaLatte:
                            for (int i = 0; i < numberToOrder; i++)
                            {
                                currentOrderList.Add(/* fifth item*/);
                            }
                            break;
                        case Menu.londonFogTeaLatte:
                            for (int i = 0; i < numberToOrder; i++)
                            {
                                currentOrderList.Add(/* sixth item*/);
                            }
                            break;
                        case Menu.matchaTeaLatte:
                            for (int i = 0; i < numberToOrder; i++)
                            {
                                currentOrderList.Add(/* seventh item*/);
                            }
                            break;
                        case Menu.earlGrey:
                            for (int i = 0; i < numberToOrder; i++)
                            {
                                currentOrderList.Add(/* eighth item*/);
                            }
                            break;
                        case Menu.cranberryScones:
                            for (int i = 0; i < numberToOrder; i++)
                            {
                                currentOrderList.Add(/* ninth item*/);
                            }
                            break;
                        case Menu.icedLemonLoaf:
                            for (int i = 0; i < numberToOrder; i++)
                            {
                                currentOrderList.Add(/* tenth item*/);
                            }
                            break;
                        case Menu.vanillaBeanScone:
                            for (int i = 0; i < numberToOrder; i++)
                            {
                                currentOrderList.Add(/* eleventh item*/);
                            }
                            break;
                        case Menu.plainBagel:
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
