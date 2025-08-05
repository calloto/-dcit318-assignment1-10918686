using System;

namespace TicketPriceCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Movie Theater Ticket Price Calculator ===");
            Console.WriteLine("Calculate ticket prices based on age:");
            Console.WriteLine("- Regular price: GHC 10");
            Console.WriteLine("- Senior citizens (65+) and children (12 and below): GHC 7");
            Console.WriteLine();

            while (true)
            {
                Console.Write("Enter your age (or type 'exit' to quit): ");
                string? input = Console.ReadLine();

                // Check i f user wants to exit
                if (string.IsNullOrWhiteSpace(input) || input.ToLower() == "exit" || input.ToLower() == "quit")
                {
                    Console.WriteLine("Thank you for using Ticket Price Calculator!");
                    break;
                }

                // Try to parse the input as a number
                if (int.TryParse(input, out int age))
                {
                    // Validate the age range
                    if (age >= 0 && age <= 120)
                    {
                        decimal ticketPrice = CalculateTicketPrice(age);
                        string customerType = GetCustomerType(age);
                        
                        Console.WriteLine($"Age: {age} ({customerType})");
                        Console.WriteLine($"Ticket Price: GHC {ticketPrice}");
                    }
                    else
                    {
                        Console.WriteLine("Error: Please enter a valid age between 0 and 120.");
                    }
                }
                else
                {
                    Console.WriteLine("Error: Please enter a valid number for age.");
                }

                Console.WriteLine();
            }
        }

        static decimal CalculateTicketPrice(int age)
        {
            // Senior citizens (65 and above) and children (12 and below) get discounted price
            if (age >= 65 || age <= 12)
            {
                return 7.0m; // Discounted price
            }
            else
            {
                return 10.0m; // Regular price
            }
        }

        static string GetCustomerType(int age)
        {
            if (age >= 65)
                return "Senior Citizen";
            else if (age <= 12)
                return "Child";
            else
                return "Adult";
        }
    }
}
