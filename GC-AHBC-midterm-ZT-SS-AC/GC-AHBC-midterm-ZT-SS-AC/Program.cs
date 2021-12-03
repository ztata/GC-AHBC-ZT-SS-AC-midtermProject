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
            int userChoice = -1;


            do//repeats the program if the user chooses
            {
                Console.WriteLine("Hello and welcome to Jitters Coffee House!");
            Menu:
                //displays the menu and prices for items available at the shop 
                Console.WriteLine("Please see the menu below: ");
                Console.WriteLine("-------------------------------");
                Console.WriteLine($"{Menu.caffeMocha}). {productList[0].Name} -- ${productList[0].Price}");
                Console.WriteLine($"{Menu.caffeAmericano}). {productList[1].Name} -- ${productList[1].Price}");
                Console.WriteLine($"{Menu.cappucino}). {productList[2].Name} -- ${productList[2].Price}");
                Console.WriteLine($"{Menu.caffeMisto}). {productList[3].Name} -- ${productList[3].Price}");
                Console.WriteLine($"{Menu.chaiTeaLatte}). {productList[4].Name} -- ${productList[4].Price}");
                Console.WriteLine($"{Menu.londonFogTeaLatte}). {productList[5].Name} -- ${productList[5].Price}");
                Console.WriteLine($"{Menu.matchaTeaLatte}). {productList[6].Name} -- ${productList[6].Price}");
                Console.WriteLine($"{Menu.earlGrey}). {productList[7].Name} -- ${productList[7].Price}");
                Console.WriteLine($"{Menu.cranberryScones}). {productList[8].Name} -- ${productList[8].Price}");
                Console.WriteLine($"{Menu.icedLemonLoaf}). {productList[9].Name} -- ${productList[9].Price}");
                Console.WriteLine($"{Menu.vanillaBeanScone}). {productList[10].Name} -- ${productList[10].Price}");
                Console.WriteLine($"{Menu.plainBagel}). {productList[11].Name} -- ${productList[11].Price}");

                //list of items the patron has ordered 
                List<Product> currentOrderList = new List<Product>();


                //bool value that allows them to loop and order another item 
                bool orderAnotherItem = true;
                Menu userMenuSelection;
                while (orderAnotherItem) //while loop repeats while they want to keep ordering 
                {
                    Console.WriteLine("Please enter the number preceeding the item you would like to order: ");
                    userInput = Console.ReadLine();
                    userChoice = -1;

                    bool validOrderNumber = false;
                    while (validOrderNumber == false)
                    {
                        bool validInt = ValidationMethods.ValidateIntInput(userInput);
                        if (validInt == true)
                        {
                            userChoice = int.Parse(userInput);
                        }
                        else if (validInt == false)
                        {
                            Console.WriteLine("Sorry, that is not a valid input!");
                            continue;
                        }           
                        else if (userChoice < 1 || userChoice > 12) //makes sure it is a valid number for enum selection
                        {
                            Console.WriteLine("Sorry, your input needs to be between 1 and 12!");
                            continue;
                        }
                        else
                        {
                            validOrderNumber = true;
                        }
                    }
                    userMenuSelection = (Menu)userChoice; //casts user choice as an enum 
                    bool validOrderQuantity = false;
                    while (validOrderQuantity == false) //will keep looping until we receive a valid quantity of items to be ordered
                    {
                        Console.WriteLine("How many of these would you like to order?");
                        userInput = Console.ReadLine();
                        bool validInt = ValidationMethods.ValidateIntInput(userInput);
                        if (validInt == true)
                        {
                            numberToOrder = int.Parse(userInput);
                        }
                        else if (validInt == false)
                        {
                            Console.WriteLine("Sorry, that is not a valid input!");
                            continue;
                        }
                        else if (numberToOrder < 1) //makes sure it is a valid number for enum selection
                        {
                            Console.WriteLine("Sorry, you can't order less than 1 of an item!");
                            continue;
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
                            currentOrderList = HelperMethods.AddItemToOrder(numberToOrder, currentOrderList, productList[0]);
                            break;
                        case Menu.caffeAmericano:
                            currentOrderList = HelperMethods.AddItemToOrder(numberToOrder, currentOrderList, productList[1]);
                            break;
                        case Menu.cappucino:
                            currentOrderList = HelperMethods.AddItemToOrder(numberToOrder, currentOrderList, productList[2]);
                            break;
                        case Menu.caffeMisto:
                            currentOrderList = HelperMethods.AddItemToOrder(numberToOrder, currentOrderList, productList[3]);
                            break;
                        case Menu.chaiTeaLatte:
                            currentOrderList = HelperMethods.AddItemToOrder(numberToOrder, currentOrderList, productList[4]);
                            break;
                        case Menu.londonFogTeaLatte:
                            currentOrderList = HelperMethods.AddItemToOrder(numberToOrder, currentOrderList, productList[5]);
                            break;
                        case Menu.matchaTeaLatte:
                            currentOrderList = HelperMethods.AddItemToOrder(numberToOrder, currentOrderList, productList[6]);
                            break;
                        case Menu.earlGrey:
                            currentOrderList = HelperMethods.AddItemToOrder(numberToOrder, currentOrderList, productList[7]);
                            break;
                        case Menu.cranberryScones:
                            currentOrderList = HelperMethods.AddItemToOrder(numberToOrder, currentOrderList, productList[8]);
                            break;
                        case Menu.icedLemonLoaf:
                            currentOrderList = HelperMethods.AddItemToOrder(numberToOrder, currentOrderList, productList[9]);
                            break;
                        case Menu.vanillaBeanScone:
                            currentOrderList = HelperMethods.AddItemToOrder(numberToOrder, currentOrderList, productList[10]);
                            break;
                        case Menu.plainBagel:
                            currentOrderList = HelperMethods.AddItemToOrder(numberToOrder, currentOrderList, productList[11]);
                            break;
                    }
                    
                    //try again logic will allow them to order something else
                    Console.WriteLine("Would you like to order another item?");
                    Console.Write("Enter y to continue your order or anything else to proceed to checkout: ");
                    userInput = Console.ReadLine();
                    orderAnotherItem = HelperMethods.TryAgain(userInput);
                    
                }

                //variables to hold the various totals created using methods in BillingTotal class
                double miSalesTax = 0.06;
                double subtotal = BillingTotal.SubTotal(currentOrderList);
                double salesTax = BillingTotal.SalesTax(subtotal, miSalesTax);
                double grandTotal = BillingTotal.GrandTotal(subtotal, salesTax);

                Console.WriteLine($"Your total today comes to {grandTotal}.");

            PaymentMethod:
                userChoice = -1;
                bool validPaymentTypeChoice = false;
                while (validPaymentTypeChoice == false) //will continue looping until they give a valid input for their payment type
                {
                    Console.WriteLine("How would you like to pay for todays order?");
                    Console.WriteLine($"{PaymentMethod.cash}). Cash");
                    Console.WriteLine($"{PaymentMethod.check}). Check");
                    Console.WriteLine($"{PaymentMethod.creditCard}). Credit Card ");
                    Console.WriteLine("Please enter the number preceeding your choice.");
                    userInput = Console.ReadLine();
                    bool validInt = ValidationMethods.ValidateIntInput(userInput);
                    if (validInt == true)
                    {
                        userChoice = int.Parse(userInput);
                    }
                    else if (validInt == false)
                    {
                        Console.WriteLine("Sorry, that is not a valid input type!");
                        continue;
                    }
                    else if (userChoice < 1 || userChoice > 3)
                    {
                        Console.WriteLine("Sorry, your number has to be one of the 3 displayed above!");
                        continue;
                    }
                    else
                    {
                        validPaymentTypeChoice = true;
                    }
                }
                //casts user choice as a payment method enum 
                PaymentMethod paymentChoice = (PaymentMethod)userChoice;

                switch (paymentChoice) //switch case will take you to the various code blocks for the different payment methods 
                {
                    case PaymentMethod.cash:
                        goto PayByCash;
                        break;
                    case PaymentMethod.check:
                        goto PayByCheck;
                        break;
                    case PaymentMethod.creditCard:
                        goto PayByCard;
                        break;
                }

            PayByCash:
                bool validAmountTendered = false;
                double amountTendered = 0.0;
                while (validAmountTendered == false) //keeps looping until they offer a valid number for the amount tendered 
                {
                    Console.WriteLine("How much are you providing for payment?");
                    userInput = Console.ReadLine();
                    bool validDouble = ValidationMethods.ValidateDoubleInput(userInput);
                    if (validDouble == true)
                    {
                        amountTendered = double.Parse(userInput);
                    }
                    else if (validDouble == false)
                    {
                        Console.WriteLine("Sorry, we only expect payment in USD!");
                        continue;
                    }
 
                    //uses make change method to return the amount of change
                    double change = HelperMethods.MakeChange(amountTendered, grandTotal);
                    if (change < 0) //checks to see if they provided enough to pay for the total 
                    {
                        Console.WriteLine("Sorry, we are going to need a little more than that!");
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("Thanks -- enjoy your purchases and come again!");
                        validAmountTendered = true;
                    }
                }                
                goto TryAgain;
            PayByCheck:
                bool validCheckNumber = false;
                while (validCheckNumber == false)
                {
                    Console.WriteLine("What is the four digit check number from the check you would like to pay with (numbers only please)?");
                    userInput = Console.ReadLine();
                    validCheckNumber = BillingRegexMethods.ValidateCheckNumber(userInput.Trim());
                    if (validCheckNumber == false)
                    {
                        Console.WriteLine("Sorry, that is not a valid check number.");
                        Console.WriteLine("Please re-enter a valid four digit check number.");
                    }
                }
                Console.WriteLine("Thank you for your payment, enjoy your purchases and come again!");
                goto TryAgain;
            PayByCard:
                bool validCardNumber = false;
                bool validExpirationDate = false;
                bool validCWCode = false;

                while (validCardNumber == false)
                {
                    Console.WriteLine("Please enter the number on the card you would like to use in the following format(dashes included): XXXX-XXXX-XXXX-XXXX");
                    userInput = Console.ReadLine();
                    validCardNumber = BillingRegexMethods.ValidateCardNumber(userInput.Trim());
                    if (validCardNumber == false)
                    {
                        Console.WriteLine("Sorry, that is not a valid card number.");
                        Console.WriteLine("Please re-enter a valid card number.");
                    }
                }
                Console.WriteLine("Thank you!");
                while (validExpirationDate == false)
                {
                    Console.WriteLine("Please enter the expiration date on your card using the following format (slashes included): MM/YYYY");
                    userInput = Console.ReadLine();
                    validExpirationDate = BillingRegexMethods.ValidateExpirationDate(userInput.Trim());
                    if (validExpirationDate == false)
                    {
                        Console.WriteLine("Sorry, that is not a valid expiration date.");
                        Console.WriteLine("Please re-enter a valid date.");
                    }
                }
                Console.WriteLine("Thank you, only more more piece of info is required.");
                while (validCWCode == false)
                {
                    Console.WriteLine("Please enter the 3 digit CW code on your card: ");
                    userInput = Console.ReadLine();
                    validCWCode = BillingRegexMethods.ValidateCWCode(userInput.Trim());
                    if (validCWCode == false)
                    {
                        Console.WriteLine("Sorry, that is not a valid CW code.");
                        Console.WriteLine("Please re-enter a valid code.");
                    }
                }
                Console.WriteLine("All set!");
                Console.WriteLine("Thank you for your payment, enjoy your purchases and come again!");

                Console.WriteLine("Complete Order Details:");
                foreach (var product in currentOrderList)
                    {
                        Console.WriteLine($"{product.Name} -- {product.Price}"); 
                    }
                Console.WriteLine($"SUBTOTAL: ${subtotal}\nTAX: {salesTax}\nGRAND TOTAL: ${grandTotal}\nPAYMENT METHOD: {paymentChoice}");

            TryAgain:
                Console.WriteLine("Would you like to repeat the program?");
                Console.Write("Enter y to coninue or anything else to quit: ");
                userInput = Console.ReadLine();
                runProgramAgain = HelperMethods.TryAgain(userInput);
            } while (runProgramAgain);

        Exit:
            Console.WriteLine("Thank you for shopping at Jitters Coffee House!");
            Console.WriteLine("Please press any key to continue: ");
            Console.ReadKey();
        }
    }
}