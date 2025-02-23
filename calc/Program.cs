using System;

namespace project.Functionality
{
    public class Calculator
    {
        public static void Start()
        {
            while (true)
            {
                if (!GetNumbers(out double num1, out double num2))
                {
                    continue;
                }

                if (!GetOperation(out string? operation))
                {
                    continue;
                }

                double? result = PerformOperation(num1, num2, operation);

                if (result.HasValue)
                {
                    Console.WriteLine($"Result: {result.Value}");
                }

                Console.WriteLine("\nEnter 'exit' to quit or press enter to continue.");
                string? exitCheck = Console.ReadLine();

                if (!string.IsNullOrEmpty(exitCheck) && exitCheck.Trim().ToLower() == "exit")
                {
                    Console.WriteLine("Exiting calculator...");
                    break;
                }
            }
        }

        private static bool GetNumbers(out double num1, out double num2)
        {
            Console.WriteLine("\nEnter the first number:");
            string? num1Input = Console.ReadLine();

            if (!double.TryParse(num1Input, out num1))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                num2 = 0;
                return false;
            }

            Console.WriteLine("Enter the second number:");
            string? num2Input = Console.ReadLine();

            if (!double.TryParse(num2Input, out num2))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                return false;
            }

            return true;
        }

        private static bool GetOperation(out string? operation)
        {
            Console.WriteLine("Enter the operation (+, -, *, :):");
            operation = Console.ReadLine();

            if (string.IsNullOrEmpty(operation))
            {
                Console.WriteLine("Invalid input. Please enter an operation.");
                return false;
            }

            return true;
        }

        private static double? PerformOperation(double num1, double num2, string? operation)
        {
            double? result = null;

            switch (operation)
            {
                case "+":
                    result = num1 + num2;
                    break;
                case "-":
                    result = num1 - num2;
                    break;
                case "*":
                    result = num1 * num2;
                    break;
                case ":":
                    result = num1 / num2;
                    break;
                default:
                    Console.WriteLine("Invalid operation. Please enter one of the valid operations (+, -, *, :).");
                    break;
            }

            return result;
        }

        static void Main(string[] args)
        {
            Start();
        }
    }
}