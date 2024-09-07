using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Less36
{
    public delegate int ArithmeticOperation(int a, int b);

    public class Calculator
    {

        public int Add(int a, int b)
        {
            return a + b;
        }


        public int Subtract(int a, int b)
        {
            return a - b;
        }


        public int Multiply(int a, int b)
        {
            return a * b;
        }

        public int Divide(int a, int b)
        {
            if (b != 0)
                return a / b;
            else
                throw new ArgumentException("Cannot divide by zero.");
        }
    }

    //2nd task
    public delegate void StringFormatDelegate(string input);

    //3rd task
    public delegate double TemperatureConversionDelegate(double temperature);

    internal class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();

            ArithmeticOperation operation;

            while (true)
            {
                Console.WriteLine("Choose an operation:");
                Console.WriteLine("1. Addition");
                Console.WriteLine("2. Subtraction");
                Console.WriteLine("3. Multiplication");
                Console.WriteLine("4. Division");
                Console.WriteLine("5. Exit");

                Console.Write("Enter your choice (1-5): ");
                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 5)
                {
                    Console.WriteLine("Invalid. Please enter a number between 1 and 5.");
                    continue;
                }

                if (choice == 5)
                {
                    Console.WriteLine("Exiting the program.");
                    break;
                }

                switch (choice)
                {
                    case 1:
                        operation = calculator.Add;
                        break;
                    case 2:
                        operation = calculator.Subtract;
                        break;
                    case 3:
                        operation = calculator.Multiply;
                        break;
                    case 4:
                        operation = calculator.Divide;
                        break;
                    default:
                        throw new InvalidOperationException("Something weird happened");
                }
                Console.Write("Enter the first number: ");
                int num1 = int.Parse(Console.ReadLine());

                Console.Write("Enter the second number: ");
                int num2 = int.Parse(Console.ReadLine());

                try
                {
                    int result = operation(num1, num2);
                    Console.WriteLine("Result: " + result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }

            //2nd task
            StringFormatDelegate formatDelegate = input =>
            {
                Console.WriteLine("Uppercase: " + input.ToUpper());
            };

            formatDelegate += input =>
            {
                Console.WriteLine("Lowercase: " + input.ToLower());
            };

            formatDelegate += input =>
            {
                char[] charArray = input.ToCharArray();
                Array.Reverse(charArray);
                Console.WriteLine("Reversed: " + new string(charArray));
            };

            formatDelegate("Christa is cute");

            //3rd task
            TemperatureConversionDelegate conversionDelegate;

            while (true)
            {
                Console.WriteLine("Select a conversion:");
                Console.WriteLine("1. Celsius to Fahrenheit");
                Console.WriteLine("2. Fahrenheit to Celsius");
                Console.WriteLine("3. Exit");

                Console.Write("Enter your choice (1-3): ");
                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 3)
                {
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 3.");
                    continue;
                }

                if (choice == 3)
                {
                    Console.WriteLine("Exiting the program.");
                    break;
                }

                double temperature;

                Console.Write("Enter the temperature to convert: ");
                if (!double.TryParse(Console.ReadLine(), out temperature))
                {
                    Console.WriteLine("That can't be the temperature if you're alive. Enter a valid one troll.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        conversionDelegate = ConvertCelsiusToFahrenheit;
                        break;
                    case 2:
                        conversionDelegate = ConvertFahrenheitToCelsius;
                        break;
                    default:
                        throw new InvalidOperationException("Unexpected case.");
                }

                double convertedTemperature = conversionDelegate(temperature);
                Console.WriteLine($"Converted temperature: {convertedTemperature}");

                Console.WriteLine();
            }


            Console.ReadLine();
        }

        static double ConvertCelsiusToFahrenheit(double celsius)
        {
            return (celsius * 9 / 5) + 32;
        }

        static double ConvertFahrenheitToCelsius(double fahrenheit)
        {
            return (fahrenheit - 32) * 5 / 9;
        }

    }
}