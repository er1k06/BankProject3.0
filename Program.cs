
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using bankProject2;



class Program
        {


        static void Main(string[] args)
        {
            Console.WriteLine("*************Eriks Bank*************");
            Console.WriteLine("::Login Page::");

            //password and username
            string userName = ""; string password = "";

            Console.Write("Username:");
            userName = Console.ReadLine();

            if (userName != "")
            {
                Console.Write("Password:");
                password = Console.ReadLine();
            }
            if (userName != "system" || password != "menager")
            {
                Console.Clear();

                do
                {
                    Console.Clear();
                    Console.WriteLine("Invalid username or password");
                    Console.WriteLine("Try again");
                    Console.Write("Username:");
                    userName = Console.ReadLine();
                    if (userName != "")
                    {
                        Console.Write("Password:");
                        password = Console.ReadLine();
                    }
                } while (userName != "system" || password != "menager");
            }

            if (userName == "system" && password == "menager")
            {
                int mainMenuChoice = -1;
                do
                {
                    Console.Clear();
                    Console.WriteLine($"Welcome {userName}!");
                    Console.WriteLine("\n:::Main menu:::");
                    Console.WriteLine("1. Customers");
                    Console.WriteLine("2. Accounts");
                    Console.WriteLine("3. Funds Transfer");
                    Console.WriteLine("4. Funds Transfer Statement");
                    Console.WriteLine("5. Account Statement");
                    Console.WriteLine("0. Exit");

                    Console.Write("Enter choice:");
                    mainMenuChoice = int.Parse(Console.ReadLine());
                    switch (mainMenuChoice)
                    {
                        case 1:
                            Console.Clear();
                            CustomersMenu();
                            break;
                        case 2:
                            Console.Clear();
                            AccountsMenu();
                            break;
                        case 3:
                            Console.Clear();
                            FundsTransferMenu();
                            break;
                        case 4:
                            Console.Clear();
                            FundsTransferStatementMenu();
                            break;
                        case 5:
                            Console.Clear();
                            AccountStatementMenu();
                            break;
                        case 0:
                            Console.Clear();
                            Console.WriteLine("See You Soon! Goodbye! :)");
                            Console.Read();

                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                } while (mainMenuChoice != 0);
            }
        }





             public static void CustomersMenu()
                {
                    int customersMenuChoice = -1;
                    do
                    {
                        Console.WriteLine("\n:::Customers Menu:::");
                        Console.WriteLine("1. Add Customer");
                        Console.WriteLine("2. Delete Customer");
                        Console.WriteLine("3. Update Customer");
                        Console.WriteLine("4. Search Customer");
                        Console.WriteLine("5. View Customer");
                        Console.WriteLine("0. Back to Main Menu");

                        Console.Write("Enter choice:");
                        customersMenuChoice = Convert.ToInt32(Console.ReadLine());
                switch(customersMenuChoice)
                {
                    case 1: CUstomersPresentation.Addustomer();break;
                }
                    } while (customersMenuChoice != 0);
                }
             public static void AccountsMenu()
                {
                    int accountsMenuChoice = -1;
                    do
                    {
                        Console.WriteLine("\n:::Accounts Menu:::");
                        Console.WriteLine("1. Add Account");
                        Console.WriteLine("2. Delete Account");
                        Console.WriteLine("3. Update Account");
                        Console.WriteLine("4. View Account");
                        Console.WriteLine("0. Back to Main Menu");
                        Console.Write("Enter choice:");
                        accountsMenuChoice = Convert.ToInt32(Console.ReadLine());
                    } while (accountsMenuChoice != 0);
                }
                public static void FundsTransferMenu()
                {
                    int fundsTransferMenuChoice = -1;
                    do
                    {
                        Console.WriteLine("\n:::Funds Transfer Menu:::");
                        Console.WriteLine("1. Add Funds Transfer");
                        Console.WriteLine("2. Delete Funds Transfer");
                        Console.WriteLine("3. Update Funds Transfer");
                        Console.WriteLine("4. View Funds Transfer");
                        Console.WriteLine("0. Back to Main Menu");
                        Console.Write("Enter choice:");
                        fundsTransferMenuChoice = Convert.ToInt32(Console.ReadLine());
                    } while (fundsTransferMenuChoice != 0);
                }
                public static void FundsTransferStatementMenu()
                {
                    int fundsTransferStatementMenuChoice = -1;
                    do
                    {
                        Console.WriteLine("\n:::Funds Transfer Statement Menu:::");
                        Console.WriteLine("1. View Funds Transfer Statement");
                        Console.WriteLine("0. Back to Main Menu");
                        Console.Write("Enter choice:");
                        fundsTransferStatementMenuChoice = Convert.ToInt32(Console.ReadLine());
                    } while (fundsTransferStatementMenuChoice != 0);
                }
                public static void AccountStatementMenu()
                {
                    int accountStatementMenuChoice = -1;
                    do
                    {
                        Console.WriteLine("\n:::Account Statement Menu:::");
                        Console.WriteLine("1. View Account Statement");
                        Console.WriteLine("0. Back to Main Menu");
                        Console.Write("Enter choice:");
                        accountStatementMenuChoice = Convert.ToInt32(Console.ReadLine());
                    } while (accountStatementMenuChoice != 0);
                }

            }
        

