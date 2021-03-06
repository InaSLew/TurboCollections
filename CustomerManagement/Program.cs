using System;
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
                var isInputValid = ValidateMenuInput(input);
                while (!isInputValid)
                {
                    Console.WriteLine("Invalid input :)");
                    input = Console.ReadLine();
                    isInputValid = ValidateMenuInput(input);
                }

                switch (input)
                {
                    case "1":
                        CreateCustomer(ref list);
                        break;
                    case "2":
                        RemoveByName(ref list);
                        break;
                    case "3":
                        RemoveByIndex(ref list);
                        break;
                    case "4":
                        ShowAllCustomers(ref list);
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

        private static void CreateCustomer(ref TurboList<Customer> list)
        {
            var isValid = false;
            Console.WriteLine("What is the the Customer's name?");
            var input = Console.ReadLine();
            isValid = ValidateName(input);
            while (!isValid)
            {
                Console.WriteLine("Input invalid :)");
                input = Console.ReadLine();
                isValid = ValidateName(input);
            }
            var newCustomer = new Customer(input);
            list.Add(newCustomer);
        }

        private static bool ValidateName(string input) => !string.IsNullOrEmpty(input) && !string.IsNullOrWhiteSpace(input);

        private static void RemoveByName(ref TurboList<Customer> list)
        {
            var isValid = false;
            Console.WriteLine("What is the the Customer's name?");
            var input = Console.ReadLine();
            isValid = ValidateName(input);
            while (!isValid)
            {
                Console.WriteLine("Input invalid :)");
                input = Console.ReadLine();
                isValid = ValidateName(input);
            }
            foreach (var item in list)
            {
                if (item.Name == input) list.Remove(item);
            }
        }
        
        private static void RemoveByIndex(ref TurboList<Customer> list)
        {
            var isValid = false;
            Console.WriteLine("What is the the Customer's name?");
            var input = Console.ReadLine();
            isValid = ValidateName(input);
            while (!isValid)
            {
                Console.WriteLine("Input invalid :)");
                input = Console.ReadLine();
                isValid = ValidateName(input);
            }
            list.RemoveAt(Convert.ToInt32(input));
        }

        private static void ShowAllCustomers(ref TurboList<Customer> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"{i}: {list.Get(i).Name}");
            }
        }

        private static bool ValidateMenuInput(string? input)
            => !string.IsNullOrEmpty(input) && input is ("1" or "2" or "3" or "4" or "q" or "Q");
    }
}
