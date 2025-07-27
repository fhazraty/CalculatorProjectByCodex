using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        // Regular expression to parse simple expressions like 10 + 5 or 20*3
        var regex = new Regex(@"^\s*(?<left>-?\d+(\.\d+)?)\s*(?<op>[+\-*/])\s*(?<right>-?\d+(\.\d+)?)\s*$");
        while (true)
        {
            Console.Write("Enter expression (e.g., 10 + 5): ");
            var input = Console.ReadLine();
            if (input == null)
            {
                Console.WriteLine("Invalid input.");
                continue;
            }
            var match = regex.Match(input);
            if (!match.Success)
            {
                Console.WriteLine("Invalid expression. Use format like '10 + 5'.");
                continue;
            }

            double left = double.Parse(match.Groups["left"].Value);
            double right = double.Parse(match.Groups["right"].Value);
            string op = match.Groups["op"].Value;

            try
            {
                double result;
                switch (op)
                {
                    case "+":
                        result = left + right;
                        break;
                    case "-":
                        result = left - right;
                        break;
                    case "*":
                        result = left * right;
                        break;
                    case "/":
                        if (right == 0)
                            throw new DivideByZeroException();
                        result = left / right;
                        break;
                    default:
                        Console.WriteLine("Unsupported operator.");
                        continue;
                }
                Console.WriteLine($"Result: {result}");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Cannot divide by zero.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
