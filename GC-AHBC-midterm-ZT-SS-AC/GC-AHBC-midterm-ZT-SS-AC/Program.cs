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

            // Repeats the program if the user chooses
            do
            {
                string addressPath = @$"{Environment.CurrentDirectory}\MenuItems.txt";
                List<Product> productList = FileHelper.BuildMenuList(addressPath);
                string menu = HelperMethods.DisplayMenu(productList);

                Console.Clear();
                Console.WriteLine("Hello and welcome to Jitters Coffee House!");
                Console.WriteLine();

                bool validUserType = false;
                // Loop determines if the user is an employee or a customer. Loop continues if neither is chosen
                do
                {
                    Console.Write("Are you an employee or are a customer? ");
                    userInput = Console.ReadLine();
                    // if the user is either an employee or customer, we have a valid user. The user is set to either employee or customer
                    if (userInput.ToLower().Trim() == "employee" || userInput.ToLower().Trim() == "customer")
                    {
                        userType = userInput;
                        validUserType = true;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Sorry, that is not a valid input! Give either 'employee' or 'customer'.");
                        Console.ForegroundColor = ConsoleColor.Black;
                        continue;
                    }
                } while (validUserType == false);

                //bool value that allows them to loop and order another item
                bool orderAnotherItem = true;
                // If the user is a customer, they are sent to the menu to start their order
                if (userType.ToLower().Trim() == "customer")
                {
                    goto Menu;
                }
                // If the user is an employee, they are given the option to add at least 1 product
                else
                {
                    Console.Write("Would you like to add a product to the menu (y/n)? ");
                    userInput = Console.ReadLine();

                    switch (userInput.ToLower().Trim())
                    {
                        // If the employee doesn't want to add a product, send them to the exit
                        case "n":
                            Console.WriteLine("Ok. Have a nice day.");
                            goto EmployeeExit;
                        // If the employee wants to add a product, a product is created and added to the file
                        case "y":
                            bool addAnotherProduct = true;
                            while (addAnotherProduct == true)
                            {
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
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Sorry, that is not a valid input! Please enter a decimal.");
                                        Console.ForegroundColor = ConsoleColor.Black;
                                    }
                                } while (validDouble == false);
                                Console.Write("Product category: ");
                                product.Category = Console.ReadLine().Trim();
                                Console.Write("Product description: ");
                                product.Description = Console.ReadLine().Trim();

                                // Adds the new product to the file
                                FileHelper.AddProductToFile(addressPath, product);

                                Console.WriteLine("Would you like to add another product?");
                                Console.Write("Enter y to add another or anything else to proceed: ");
                                userInput = Console.ReadLine();
                                addAnotherProduct = HelperMethods.TryAgain(userInput);

                            }
                            break;
                        default:
                            Console.WriteLine("Please enter either 'y' or 'n'.");
                            continue;
                    }
                    goto TryAgain;
                }

            Menu:
                Console.WriteLine();
                //displays the menu and prices for items available at the shop
                Console.WriteLine(menu);

                Console.WriteLine();
                Console.WriteLine("Would you like to order now or learn a little bit more about our products?");
                Console.WriteLine($"{(int)OrderOrLearn.orderNow}). Order now");
                Console.WriteLine($"{(int)OrderOrLearn.learnMore}). See product description and ingredients");
                Console.WriteLine();

                bool validOrderOrLearn = false;
                int orderOrLearnChoice = -1;
                OrderOrLearn orderOrLearnEnum;
                // Loops while there's a valid order or learn option
                while (validOrderOrLearn == false)
                {
                    Console.Write("Please enter the number preceeding your choice: ");
                    userInput = Console.ReadLine();
                    validOrderOrLearn = ValidationMethods.ValidateIntInput(userInput);
                    // Sets the orderOrLearn to the users choice number if it's valid
                    if (validOrderOrLearn == true)
                    {
                        orderOrLearnChoice = int.Parse(userInput);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Sorry, that is not a valid input!");
                        Console.ForegroundColor = ConsoleColor.Black;
                        continue;
                    }
                    // Displays an error message if the user chooses a number that is not an option
                    if (orderOrLearnChoice < 1 || orderOrLearnChoice > 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Sorry, your choices needs to either be a 1 or 2!");
                        Console.ForegroundColor = ConsoleColor.Black;
                        validOrderOrLearn = false;
                        continue;
                    }
                    else
                    {
                        validOrderOrLearn = true;
                    }
                }
                // Casts user choice as an enum
                orderOrLearnEnum = (OrderOrLearn)orderOrLearnChoice;

                // Goes to the correction section, determined by users choice of ordering now or learning more
                switch (orderOrLearnEnum)
                {
                    case OrderOrLearn.orderNow:
                        Console.Clear();
                        goto Order;
                    case OrderOrLearn.learnMore:
                        Console.Clear();
                        goto DescriptionAndIngredients;
                }

            DescriptionAndIngredients:
                bool seeAnotherItem = true;
                // Loops while the user wants to see details about a specific product
                while (seeAnotherItem == true)
                {
                    string menuWithoutPrice = HelperMethods.DisplayMenuWithoutPrice(productList);
                    Console.WriteLine();
                    // Display the menu without prices
                    Console.WriteLine(menuWithoutPrice);
                    Console.WriteLine();
                    bool validDescriptionNumber = false;
                    do // Loops while there is a valid chosen description number
                    {
                        Console.Write("Please enter the number preceeding the item you would like to learn more about: ");
                        userInput = Console.ReadLine();
                        bool validInt = ValidationMethods.ValidateIntInput(userInput);
                        // Set the users input to userChoice if it's valid
                        if (validInt == true)
                        {
                            userChoice = int.Parse(userInput);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"Sorry, that is not a valid input! Please provide an integer between 1 and {productList.Count}.");
                            Console.ForegroundColor = ConsoleColor.Black;
                            continue;
                        }
                        // Makes sure it is a valid number on the menu
                        if (userChoice < 1 || userChoice > productList.Count)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"Sorry, your input needs to be between 1 and {productList.Count}!");
                            Console.ForegroundColor = ConsoleColor.Black;
                            validDescriptionNumber = false;
                        }
                        else
                        {
                            validDescriptionNumber = true;
                        }
                    } while (validDescriptionNumber == false);

                    Console.WriteLine();
                    Console.WriteLine("Thanks, please see product information below:");
                    Console.WriteLine();
                    Console.WriteLine($"Name: {productList[userChoice - 1].Name}");
                    Console.WriteLine($"Price: ${productList[userChoice - 1].Price}");
                    Console.WriteLine($"Category: {productList[userChoice - 1].Category}");
                    Console.WriteLine($"Description: {productList[userChoice - 1].Description}");
                    Console.WriteLine();
                    Console.WriteLine("Would you like to see info on another item?");
                    Console.Write("Enter y to see another item or anything else to proceed to ordering: ");
                    userInput = Console.ReadLine();
                    seeAnotherItem = HelperMethods.TryAgain(userInput);
                    Console.Clear();
                }

            Order:
                while (orderAnotherItem) // while loop repeats while the customer wants to keep ordering 
                {
                    Console.WriteLine();
                    //displays the menu and prices for items available at the shop
                    Console.WriteLine(menu);
                    Console.WriteLine();
                    bool validOrderNumber = false;
                    do // Loops until the users given choice is valid
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
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"Sorry, that is not a valid input! Please provide an integer between 1 and {productList.Count}.");
                            Console.ForegroundColor = ConsoleColor.Black;
                            continue;
                        }
                        // Makes sure it is a valid number for enum selection
                        if (userChoice < 1 || userChoice > productList.Count)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"Sorry, your input needs to be between 1 and {productList.Count}!");
                            Console.ForegroundColor = ConsoleColor.Black;
                            validOrderNumber = false;
                        }
                        else
                        {
                            validOrderNumber = true;
                        }
                    } while (validOrderNumber == false);

                    bool validOrderQuantity = false;
                    // Will keep looping until we receive a valid quantity of items to be ordered
                    while (validOrderQuantity == false)
                    {
                        Console.Write("How many of these would you like to order? ");
                        userInput = Console.ReadLine();
                        bool validInt = ValidationMethods.ValidateIntInput(userInput);
                        // Sets the numberToOrder to the users input if it's valid
                        if (validInt == true)
                        {
                            numberToOrder = int.Parse(userInput);
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Sorry, that is not a valid input!");
                            Console.ForegroundColor = ConsoleColor.Black;
                            continue;
                        }
                        // Makes sure it is a valid number to order
                        if (numberToOrder < 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Sorry, you can't order less than 1 of an item!");
                            Console.ForegroundColor = ConsoleColor.Black;
                            continue;
                        }
                        else
                        {
                            validOrderQuantity = true;
                        }
                    }

                    // Adds user selected item to list containing current order 
                    currentOrderList = HelperMethods.AddItemToOrder(numberToOrder, currentOrderList, productList[userChoice - 1]);

                    Console.WriteLine();
                    // Displays a line total for the current item ordered
                    Console.WriteLine($"Item total: {productList[userChoice - 1].Name}({numberToOrder}) -- ${(numberToOrder * productList[userChoice - 1].Price).ToString("0.00")}");
                    Console.WriteLine();

                    // Try again logic will allow them to order something else
                    Console.WriteLine("Would you like to order another item?");
                    Console.Write("Enter y to continue your order or anything else to proceed to checkout: ");
                    userInput = Console.ReadLine();
                    orderAnotherItem = HelperMethods.TryAgain(userInput);
                    Console.Clear();
                }
                Console.Clear();

                // Variables to hold the various totals created using methods in BillingTotal class
                double miSalesTax = 0.06;
                double subtotal = BillingTotal.SubTotal(currentOrderList);
                double salesTax = BillingTotal.SalesTax(subtotal, miSalesTax);
                double grandTotal = BillingTotal.GrandTotal(subtotal, salesTax);

                Console.WriteLine();
                Console.WriteLine($"Your total today comes to ${grandTotal.ToString("0.00")}.");
                Console.WriteLine();

            PaymentMethod:
                userChoice = -1;
                bool validPaymentTypeChoice = false;
                // Will continue looping until the customer gives a valid input for their payment type
                while (validPaymentTypeChoice == false)
                {
                    Console.WriteLine("How would you like to pay for todays order?");
                    Console.WriteLine($"{(int)PaymentMethod.Cash}.) {PaymentMethod.Cash}");
                    Console.WriteLine($"{(int)PaymentMethod.Check}.) {PaymentMethod.Check}");
                    Console.WriteLine($"{(int)PaymentMethod.Card}.) {PaymentMethod.Card} ");

                    Console.WriteLine();
                    Console.Write("Please enter the number preceeding your choice: ");
                    userInput = Console.ReadLine();
                    bool validInt = ValidationMethods.ValidateIntInput(userInput);
                    // Sets the userChoice to the users input if it's valid
                    if (validInt == true)
                    {
                        userChoice = int.Parse(userInput);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Sorry, that is not a valid input type!");
                        Console.ForegroundColor = ConsoleColor.Red;
                        continue;
                    }

                    if (userChoice < 1 || userChoice > 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Sorry, your number has to be one of the 3 displayed above!");
                        Console.ForegroundColor = ConsoleColor.Black;
                        continue;
                    }
                    else
                    {
                        validPaymentTypeChoice = true;
                    }
                }
                // Casts user choice as a payment method enum 
                PaymentMethod paymentChoice = (PaymentMethod)userChoice;

                // Switch case will take you to the various code blocks for the different payment methods
                switch (paymentChoice) 
                {
                    case PaymentMethod.Cash:
                        goto PayByCash;
                    case PaymentMethod.Check:
                        goto PayByCheck;
                    case PaymentMethod.Card:
                        goto PayByCard;
                }

            PayByCash:
                Console.WriteLine();
                bool validAmountTendered = false;
                double amountTendered = 0.0;
                // Keeps looping until the customer offers a valid number for the amount tendered
                while (validAmountTendered == false)
                {
                    Console.Write("How much are you providing for payment? ");
                    userInput = Console.ReadLine();
                    bool validDouble = ValidationMethods.ValidateDoubleInput(userInput);
                    // Sets the amountTendered to the users input if it's valid
                    if (validDouble == true)
                    {
                        Console.Clear();
                        amountTendered = double.Parse(userInput);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Sorry, we only accept payment in USD!");
                        Console.ForegroundColor = ConsoleColor.Black;
                        continue;
                    }

                    // Uses MakeChange method to return the amount of change
                    double change = HelperMethods.MakeChange(amountTendered, grandTotal);
                    // Checks to see if the customer provided enough to pay for the total
                    if (change < 0) 
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Sorry, we are going to need a little more than that!");
                        Console.ForegroundColor = ConsoleColor.Black;
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
                        Console.WriteLine($"Thanks! Your change comes to ${change:0.00} today.");
                        Console.WriteLine("Enjoy your purchases and come again!");
                        Console.WriteLine();
                        validAmountTendered = true;
                    }
                }
                goto Receipt;

            PayByCheck:
                bool validCheckNumber = false;
                // Loops if the check number isn't valid
                while (validCheckNumber == false)
                {
                    Console.WriteLine();
                    Console.Write("What is the four digit check number from the check you would like to pay with (numbers only please)? ");
                    userInput = Console.ReadLine();
                    validCheckNumber = BillingRegexMethods.ValidateCheckNumber(userInput.Trim());
                    if (validCheckNumber == false)
                    {
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Sorry, that is not a valid check number.");
                        Console.WriteLine("Please re-enter a valid four digit check number.");
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine();
                    }
                }
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("Thank you for your payment, enjoy your purchases and come again!");
                Console.WriteLine();

                goto Receipt;

            PayByCard:
                bool validCardNumber = false;
                bool validExpirationDate = false;
                bool validCWCode = false;
                // Loop while the card number isn't valid
                while (validCardNumber == false)
                {
                    Console.WriteLine();
                    Console.Write("Please enter the number on the card you would like to use in the following format(dashes included): XXXX-XXXX-XXXX-XXXX: ");
                    userInput = Console.ReadLine();
                    validCardNumber = BillingRegexMethods.ValidateCardNumber(userInput.Trim());
                    if (validCardNumber == false)
                    {
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Sorry, that is not a valid card number.");
                        Console.WriteLine("Please re-enter a valid card number.");
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine();
                    }
                }

                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("Thank you!");
                Console.WriteLine();

                // Loop while the expiration date isn't valid
                while (validExpirationDate == false)
                {
                    Console.WriteLine();
                    Console.Write("Please enter the expiration date on your card using the following format (slashes included): MM/YYYY: ");
                    userInput = Console.ReadLine();
                    validExpirationDate = BillingRegexMethods.ValidateExpirationDate(userInput.Trim());
                    if (validExpirationDate == false)
                    {
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Sorry, that is not a valid expiration date.");
                        Console.WriteLine("Please re-enter a valid date.");
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine();
                    }
                }

                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("Thank you, only one more piece of info is required.");
                Console.WriteLine();

                // Loops while the CW Code is isn't valid
                while (validCWCode == false)
                {
                    Console.Write("Please enter the 3 digit CW code on your card: ");
                    userInput = Console.ReadLine();
                    validCWCode = BillingRegexMethods.ValidateCWCode(userInput.Trim());
                    if (validCWCode == false)
                    {
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Sorry, that is not a valid CW code.");
                        Console.WriteLine("Please re-enter a valid code.");
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine();
                    }
                }

                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("All set!");
                if (currentOrderList.Count == 1)
                {
                    Console.WriteLine("Thank you for your payment. Enjoy your purchase and come again!");
                }
                else
                {
                    Console.WriteLine("Thank you for your payment. Enjoy your purchases and come again!");
                }
                
                Console.WriteLine();

            Receipt:
                Console.WriteLine("Complete Order Details:");
                // Displays the name and price of each product ordered
                foreach (var product in currentOrderList)
                {
                    Console.WriteLine($"{product.Name} -- ${product.Price}");
                }

                Console.WriteLine();
                Console.WriteLine($"SUBTOTAL: ${subtotal.ToString("0.00")}\nTAX: ${salesTax.ToString("0.00")}\nGRAND TOTAL: ${grandTotal.ToString("0.00")}\nPAYMENT METHOD: {paymentChoice}");
                Console.WriteLine();

                // Clears current order from the list so the next order can start out with a clean slate
                currentOrderList.Clear();

            TryAgain:
                Console.WriteLine("Would you like to repeat the program?");
                Console.Write("Enter y to coninue or anything else to quit: ");
                userInput = Console.ReadLine();
                runProgramAgain = HelperMethods.TryAgain(userInput);

            } while (runProgramAgain);

            Console.WriteLine("Thank you for shopping at Jitters Coffee House!");
            Console.WriteLine();
        EmployeeExit:
            Console.WriteLine("Please press any key to continue.");
            Console.ReadKey();
        }
    }
}