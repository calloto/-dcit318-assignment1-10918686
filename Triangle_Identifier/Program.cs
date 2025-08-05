using System;

namespace TriangleTypeIdentifier
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Triangle Type Identifier ===");
            Console.WriteLine("Enter the lengths of the three sides of a triangle.");
            Console.WriteLine();

            while (true)
            {
                double[] sides = new double[3];
                bool validInput = true;

                for (int i = 0; i < 3; i++)
                {
                    Console.Write($"Enter length of side {i + 1} (or type 'exit' to quit): ");
                    string? input = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(input) || input.ToLower() == "exit" || input.ToLower() == "quit")
                    {
                        Console.WriteLine("Thank you for using Triangle Type Identifier!");
                        return;
                    }

                    if (!double.TryParse(input, out double side) || side <= 0)
                    {
                        Console.WriteLine("Error: Please enter a valid positive number for the side length.");
                        validInput = false;
                        break;
                    }
                    sides[i] = side;
                }

                if (!validInput)
                {
                    Console.WriteLine();
                    continue;
                }

                // Check for triangle validity (triangle inequality theorem)
                if (!IsValidTriangle(sides[0], sides[1], sides[2]))
                {
                    Console.WriteLine("Error: The entered sides do not form a valid triangle.");
                    Console.WriteLine();
                    continue;
                }

                string triangleType = GetTriangleType(sides[0], sides[1], sides[2]);
                Console.WriteLine($"Triangle Type: {triangleType}");
                Console.WriteLine();
            }
        }

        static bool IsValidTriangle(double a, double b, double c)
        {
            // Triangle inequality theorem
            return (a + b > c) && (a + c > b) && (b + c > a);
        }

        static string GetTriangleType(double a, double b, double c)
        {
            if (a == b && b == c)
                return "Equilateral";
            else if (a == b || b == c || a == c)
                return "Isosceles";
            else
                return "Scalene";
        }
    }
}
