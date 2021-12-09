using System;
using System.Collections.Generic;
using System.Linq;

namespace GC_AHBC_midterm_ZT_SS_AC
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Title = "Full Stack After Hours Bootcamp Midterm Project - Steve Schaner, April Carden, Zachary Tata";



            bool runProgramAgain = true;
            string userInput = "";
            int numberToOrder = -1;
            int userChoice = -1;
            string userType = "";
            //list of items the patron has ordered 
            List<Product> currentOrderList = new List<Product>();


            do//repeats the program if the user chooses
            {
                string addressPath = @$"{Environment.CurrentDirectory}\MenuItems.txt";
                List<Product> productList = FileHelper.BuildMenuList(addressPath);
                Console.Clear();
                Console.WriteLine("Hello and welcome to Jitters Coffee House!");

                bool validUserType = false;
                do
                {
                    Console.Write("Are you an employee or are a customer? ");
                    userInput = Console.ReadLine();
                    if (userInput.ToLower().Trim() == "employee" || userInput.ToLower().Trim() == "customer")
                    {
                        userType = userInput;
                        validUserType = true;
                    }
                    else
                    {
                        Console.WriteLine("Sorry, that is not a valid input! give either 'employee' or 'customer'.");
                        continue;
                    }
                } while (validUserType == false);

                //bool value that allows them to loop and order another item 
                bool orderAnotherItem = true;
                Menu userMenuSelection;
                while (orderAnotherItem) //while loop repeats while they want to keep ordering 
                {
                    if (userType.ToLower().Trim() == "customer")
                    {
                        goto Menu;
                    }
                    else
                    {
                        Console.Write("Would you like to add a product to the menu (y/n)? ");
                        userInput = Console.ReadLine();
                        
                        switch (userInput.ToLower().Trim())
                        {
                            case "n":
                                Console.WriteLine("Ok. Have a nice day.");
                                goto EmployeeExit;
                            case "y":
                                AddAnotherProduct:
                                Product product = new Product();
                                Console.Write("Product name: ");
                                product.Name = Console.ReadLine().Trim();
                                bool validDouble = false;
                                do
                                {
                                    Console.Write("Product price: ");
                                    userInput = Console.ReadLine();
                                    validDouble = ValidationMethods.ValidateDoubleInput(userInput);
                                    if (validDouble == true)
                                    {
                                        product.Price = double.Parse(userInput);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Sorry, that is not a valid input! Please enter a decimal.");
                                    }
                                } while (validDouble == false);
                                Console.Write("Product category: ");
                                product.Category = Console.ReadLine().Trim();
                                Console.Write("Product description: ");
                                product.Description = Console.ReadLine().Trim();

                                FileHelper.AddProductToFile(addressPath, product);

                                Console.Write("Would you like to add another product (y/n)? ");
                                userInput = Console.ReadLine();
                                if (userInput.ToLower().Trim() == "y")
                                {
                                    goto AddAnotherProduct;
                                }else if (userInput.ToLower().Trim() == "n")
                                {
                                    goto EmployeeExit;
                                }

                                break;
                            default:
                                Console.WriteLine("Please enter either 'y' or 'n'.");
                                continue;
                        }
                    }

                Menu:
                    //displays the menu and prices for items available at the shop 
                    Console.WriteLine("Please see the menu below: ");
                    Console.WriteLine("-------------------------------");
                    for (int i = 0; i < productList.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}.) {productList[i].Name} -- ${productList[i].Price}");
                    }
                    Console.WriteLine();
                    Console.WriteLine("Would you like to order now, or learn a little bit more about our products?");
                    Console.WriteLine($"{OrderOrLearn.orderNow}). Order now");
                    Console.WriteLine($"{OrderOrLearn.learnMore}). See product descriptions and ingredients");
                    Console.WriteLine();

                    bool validOrderOrLearn = false;
                    int orderOrLearnChoice =-1;
                    OrderOrLearn orderOrLearnEnum;
                    while (validOrderOrLearn == false)
                    {
                        Console.WriteLine("Please enter the number preceeding your choice");
                        userInput = Console.ReadLine();
                        validOrderOrLearn = ValidationMethods.ValidateIntInput(userInput);
                        if (validOrderOrLearn == true)
                        {
                            orderOrLearnChoice = int.Parse(userInput);
                        }
                        else
                        {
                            Console.WriteLine("Sorry, that is not a valid input!");
                            continue;
                        }

                        if (orderOrLearnChoice < 1 || orderOrLearnChoice > 2)
                        {
                            Console.WriteLine("Sorry, your choices needs to either be a 1 or 2!");
                            continue;
                        }
                        else
                        {
                            validOrderOrLearn = true;
                        }
                    }
                    //casts user choice as an enum 
                    orderOrLearnEnum = (OrderOrLearn) orderOrLearnChoice;

                    switch (orderOrLearnEnum)
                    {
                        case OrderOrLearn.orderNow:
                            goto Order;
                            break;
                        case OrderOrLearn.learnMore:
                            goto DescriptionAndIngredients;
                            break;
                    }

                DescriptionAndIngredients:
                    bool seeAnotherItem = true;
                    while (seeAnotherItem == true) 
                    {
                        Console.WriteLine("Please see the menu below: ");
                        Console.WriteLine("-------------------------------");
                        for (int i = 0; i < productList.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}.) {productList[i].Name} -- ${productList[i].Price}");
                        }
                        Console.WriteLine();
                        bool validDescriptionNumber = false;
                        do
                        {
                            Console.Write("Please enter the number preceeding the item you would like to learn more about: ");
                            userInput = Console.ReadLine();
                            bool validInt = ValidationMethods.ValidateIntInput(userInput);
                            if (validInt == true)
                            {
                                userChoice = int.Parse(userInput);
                            }
                            else
                            {
                                Console.WriteLine($"Sorry, that is not a valid input! Please provide an integer between 1 and {productList.Count}.");
                                continue;
                            }

                            if (userChoice < 1 || userChoice > productList.Count) //makes sure it is a valid number on the menu
                            {
                                Console.WriteLine($"Sorry, your input needs to be between 1 and {productList.Count}!");
                                validDescriptionNumber = false;
                            }
                            else
                            {
                                validDescriptionNumber = true;
                            }
                        } while (validDescriptionNumber == false);

                        Console.WriteLine();
                        Console.WriteLine("Thanks, please see product information below:");
                        Console.WriteLine($"{productList[userChoice - 1].Name}");
                        Console.WriteLine($"{productList[userChoice - 1].Price}");
                        Console.WriteLine($"{productList[userChoice - 1].Category}");
                        Console.WriteLine($"{productList[userChoice-1].Description}");

                        Console.WriteLine("Would you like to see info on another item?");
                        Console.WriteLine("Enter y to see another item or anything else to proceed to ordering");
                        userInput = Console.ReadLine();
                        seeAnotherItem = HelperMethods.TryAgain(userInput);
                        Console.Clear();
                    }

                Order:
                    bool validOrderNumber = false;
                    do
                    {
                        Console.Write("Please enter the number preceeding the item you would like to order: ");
                        userInput = Console.ReadLine();
                        bool validInt = ValidationMethods.ValidateIntInput(userInput);
                        if (validInt == true)
                        {
                            userChoice = int.Parse(userInput);
                        }
                        else
                        {
                            Console.WriteLine($"Sorry, that is not a valid input! Please provide an integer between 1 and {productList.Count}.");
                            continue;
                        }

                        if (userChoice < 1 || userChoice > productList.Count) //makes sure it is a valid number for enum selection
                        {
                            Console.WriteLine($"Sorry, your input needs to be between 1 and {productList.Count}!");
                            validOrderNumber = false;
                        }
                        else
                        {
                            validOrderNumber = true;
                        }
                    } while (validOrderNumber == false);

                    //we do not use this enum anymore 
                    //userMenuSelection = (Menu)userChoice; //casts user choice as an enum 

                    bool validOrderQuantity = false;
                    while (validOrderQuantity == false) //will keep looping until we receive a valid quantity of items to be ordered
                    {
                        Console.Write("How many of these would you like to order? ");
                        userInput = Console.ReadLine();
                        bool validInt = ValidationMethods.ValidateIntInput(userInput);
                        if (validInt == true)
                        {
                            numberToOrder = int.Parse(userInput);
                        }
                        else
                        {
                            Console.WriteLine("Sorry, that is not a valid input!");
                            continue;
                        }

                        if (numberToOrder < 1) //makes sure it is a valid number to order
                        {
                            Console.WriteLine("Sorry, you can't order less than 1 of an item!");
                            continue;
                        }
                        else
                        {
                            validOrderQuantity = true;
                        }
                    }

                    //adds user selected item to list containing current order 
                    currentOrderList = HelperMethods.AddItemToOrder(numberToOrder, currentOrderList, productList[userChoice - 1]);

                    Console.WriteLine();
                    //displays a line total for the current item ordered
                    Console.WriteLine($"Item total: {productList[userChoice - 1].Name}({numberToOrder}) -- ${(numberToOrder * productList[userChoice - 1].Price).ToString("0.00")}");
                    Console.WriteLine();

                    //try again logic will allow them to order something else
                    Console.WriteLine("Would you like to order another item?");
                    Console.Write("Enter y to continue your order or anything else to proceed to checkout: ");
                    userInput = Console.ReadLine();
                    orderAnotherItem = HelperMethods.TryAgain(userInput);
                    Console.Clear();

                }

                //variables to hold the various totals created using methods in BillingTotal class
                double miSalesTax = 0.06;
                double subtotal = BillingTotal.SubTotal(currentOrderList);
                double salesTax = BillingTotal.SalesTax(subtotal, miSalesTax);
                double grandTotal = BillingTotal.GrandTotal(subtotal, salesTax);

                Console.WriteLine($"Your total today comes to ${grandTotal.ToString("0.00")}.");
                Console.WriteLine();

            PaymentMethod:
                userChoice = -1;
                bool validPaymentTypeChoice = false;
                while (validPaymentTypeChoice == false) //will continue looping until they give a valid input for their payment type
                {
                    Console.WriteLine("How would you like to pay for todays order?");
                    Console.WriteLine($"{(int)PaymentMethod.Cash}.) {PaymentMethod.Cash}");
                    Console.WriteLine($"{(int)PaymentMethod.Check}.) {PaymentMethod.Check}");
                    Console.WriteLine($"{(int)PaymentMethod.Card}.) {PaymentMethod.Card} ");

                    Console.WriteLine();
                    Console.WriteLine("Please enter the number preceeding your choice.");
                    userInput = Console.ReadLine();
                    bool validInt = ValidationMethods.ValidateIntInput(userInput);
                    if (validInt == true)
                    {
                        userChoice = int.Parse(userInput);
                    }
                    else
                    {
                        Console.WriteLine("Sorry, that is not a valid input type!");
                        continue;
                    }

                    if (userChoice < 1 || userChoice > 3)
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
                    case PaymentMethod.Cash:
                        goto PayByCash;
                        break;
                    case PaymentMethod.Check:
                        goto PayByCheck;
                        break;
                    case PaymentMethod.Card:
                        goto PayByCard;
                        break;
                }

            PayByCash:
                Console.WriteLine();
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
                    else
                    {
                        Console.WriteLine("Sorry, we only accept payment in USD!");
                        continue;
                    }

                    //uses make change method to return the amount of change
                    double change = HelperMethods.MakeChange(amountTendered, grandTotal);
                    if (change < 0) //checks to see if they provided enough to pay for the total 
                    {
                        Console.WriteLine("Sorry, we are going to need a little more than that!");
                        Console.WriteLine();
                        continue;
                    }
                    else if (change == 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine($"Thanks for your purchase as well as your exactitude!");
                        Console.WriteLine("Enjoy and please come again!");
                        Console.WriteLine();
                        validAmountTendered = true;
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine($"Thanks! Your change comes to ${change.ToString("0.00")} today.");
                        Console.WriteLine("Enjoy your purchases and come again!");
                        Console.WriteLine();
                        validAmountTendered = true;
                    }
                }
                goto Receipt;
            PayByCheck:
                bool validCheckNumber = false;
                while (validCheckNumber == false)
                {
                    Console.WriteLine();
                    Console.WriteLine("What is the four digit check number from the check you would like to pay with (numbers only please)?");
                    userInput = Console.ReadLine();
                    validCheckNumber = BillingRegexMethods.ValidateCheckNumber(userInput.Trim());
                    if (validCheckNumber == false)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Sorry, that is not a valid check number.");
                        Console.WriteLine("Please re-enter a valid four digit check number.");
                        Console.WriteLine();
                    }
                }
                Console.WriteLine();
                Console.WriteLine("Thank you for your payment, enjoy your purchases and come again!");
                Console.WriteLine();
                goto Receipt;
            PayByCard:
                bool validCardNumber = false;
                bool validExpirationDate = false;
                bool validCWCode = false;

                while (validCardNumber == false)
                {
                    Console.WriteLine();
                    Console.WriteLine("Please enter the number on the card you would like to use in the following format(dashes included): XXXX-XXXX-XXXX-XXXX");
                    userInput = Console.ReadLine();
                    validCardNumber = BillingRegexMethods.ValidateCardNumber(userInput.Trim());
                    if (validCardNumber == false)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Sorry, that is not a valid card number.");
                        Console.WriteLine("Please re-enter a valid card number.");
                        Console.WriteLine();
                    }
                }
                Console.WriteLine();
                Console.WriteLine("Thank you!");
                Console.WriteLine();
                while (validExpirationDate == false)
                {
                    Console.WriteLine();
                    Console.WriteLine("Please enter the expiration date on your card using the following format (slashes included): MM/YYYY");
                    userInput = Console.ReadLine();
                    validExpirationDate = BillingRegexMethods.ValidateExpirationDate(userInput.Trim());
                    if (validExpirationDate == false)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Sorry, that is not a valid expiration date.");
                        Console.WriteLine("Please re-enter a valid date.");
                        Console.WriteLine();
                    }
                }
                Console.WriteLine();
                Console.WriteLine("Thank you, only one more piece of info is required.");
                Console.WriteLine();
                while (validCWCode == false)
                {
                    Console.WriteLine("Please enter the 3 digit CW code on your card: ");
                    userInput = Console.ReadLine();
                    validCWCode = BillingRegexMethods.ValidateCWCode(userInput.Trim());
                    if (validCWCode == false)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Sorry, that is not a valid CW code.");
                        Console.WriteLine("Please re-enter a valid code.");
                        Console.WriteLine();
                    }
                }
                Console.WriteLine();
                Console.WriteLine("All set!");
                Console.WriteLine("Thank you for your payment, enjoy your purchases and come again!");
                Console.WriteLine();
            Receipt:
                Console.WriteLine("Complete Order Details:");
                foreach (var product in currentOrderList)
                {
                    Console.WriteLine($"{product.Name} -- ${product.Price}");
                }
                Console.WriteLine();
                Console.WriteLine($"SUBTOTAL: ${subtotal.ToString("0.00")}\nTAX: ${salesTax.ToString("0.00")}\nGRAND TOTAL: ${grandTotal.ToString("0.00")}\nPAYMENT METHOD: {paymentChoice}");
                Console.WriteLine();
                //clears current order from the list so the next order can start out with a clean slate
                currentOrderList.Clear();

            TryAgain:
                Console.WriteLine("Would you like to place another order?");
                Console.Write("Enter y to coninue or anything else to quit: ");
                userInput = Console.ReadLine();
                runProgramAgain = HelperMethods.TryAgain(userInput);

            } while (runProgramAgain);

        Exit:
            Console.WriteLine("Thank you for shopping at Jitters Coffee House!");
        EmployeeExit:
            Console.WriteLine("Please press any key to continue: ");
            Console.ReadKey();
        }
    }
}