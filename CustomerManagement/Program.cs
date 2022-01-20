using System;
using System.Net.Mime;
using TurboCollections;

namespace CustomerManagement
{
    class Program
    {
        static void Main()
        {
            var isDone = false;
            var list = new TurboList<Customer>();
            while (!isDone)
            {
                PrintInstructions();
                var input = Console.ReadLine();
                var isInputValid = ValidateInput(input);
                while (!isInputValid)
                {
                    Console.WriteLine("Invalid input :)");
                    input = Console.ReadLine();
                    isInputValid = ValidateInput(input);
                }

                switch (input)
                {
                    case "1":
                        CreateCustomer();
                        break;
                    case "2":
                        RemoveByName();
                        break;
                    case "3":
                        RemoveByIndex();
                        break;
                    case "4":
                        ShowAllCustomers();
                        break;
                    default:
                        isDone = true;
                        break;
                }
            }
            
        }

        private static void PrintInstructions()
        {
            Console.WriteLine("Choose one option:");
            Console.WriteLine("(1) Add a Customer");
            Console.WriteLine("(2) Remove a Customer by name");
            Console.WriteLine("(3) Remove a Customer by index");
            Console.WriteLine("(4) Display all Customers");
            Console.WriteLine("q/Q to quit application...");
            Console.WriteLine();
        }

        private static void CreateCustomer()
        {
            Console.WriteLine("CreateCustomer");
        }
        
        private static void RemoveByName()
        {
            Console.WriteLine("RemoveByName");
        }
        
        private static void RemoveByIndex()
        {
            Console.WriteLine("RemoveByIndex");
        }
        
        private static void ShowAllCustomers()
        {
            Console.WriteLine("ShowAllCustomers");
        }

        private static bool ValidateInput(string? input)
            => !string.IsNullOrEmpty(input) && input is ("1" or "2" or "3" or "4" or "q" or "Q");
    }
}
