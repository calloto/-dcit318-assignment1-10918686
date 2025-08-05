using System;

namespace Grade_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Grade Calculator ===");
            Console.WriteLine("Enter a numerical grade between 0 and 100 to get the corresponding letter grade.");
            Console.WriteLine();

            while (true)
            {
                Console.Write("Enter numerical grade (0-100): ");
                string? input = Console.ReadLine();

                // Check if user wants to exit
                if (string.IsNullOrWhiteSpace(input) || input.ToLower() == "exit" || input.ToLower() == "quit")
                {
                    Console.WriteLine("Thank you for using Grade Calculator!");
                    break;
                }

                // Try to parse the input as a number
                if (double.TryParse(input, out double grade))
                {
                    // Validate the grade range
                    if (grade >= 0 && grade <= 100)
                    {
                        string letterGrade = GetLetterGrade(grade);
                        Console.WriteLine($"Grade: {grade} -> Letter Grade: {letterGrade}");
                    }
                    else
                    {
                        Console.WriteLine("Error: Grade must be between 0 and 100.");
                    }
                }
                else
                {
                    Console.WriteLine("Error: Please enter a valid number.");
                }

                Console.WriteLine();
            }
        }

        static string GetLetterGrade(double grade)
        {
            if (grade >= 90)
                return "A";
            else if (grade >= 80)
                return "B";
            else if (grade >= 70)
                return "C";
            else if (grade >= 60)
                return "D";
            else
                return "F";
        }
    }
}
