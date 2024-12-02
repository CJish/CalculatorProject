using System.Text.RegularExpressions;
using CalculatorLibrary;

namespace CalculatorProject

    // virtual keyword for a class function allows a child class to keep the function as-is or modify the function.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool endApp = false;
            // Display title as the C# console calculator app.
            Console.WriteLine("Console Calculator in C#\r");
            Console.WriteLine("--------------------------");

            Calculator calculator = new Calculator();

            while (!endApp)
            {
                // Declare variables and set to empty.
                // Use nullable types (with ?) to match type of System.Console.Readline
                string? numInput1 = ""; // string? means that it can be null; different from empty in that a null value does not have a memory address allotted to it.
                string? numInput2 = "";
                double result = 0;

                // Ask the user to type the first number.
                Console.WriteLine("Type a number, and then press Enter: ");
                numInput1 = Console.ReadLine();

                double cleanNum1 = 0;
                while(!double.TryParse(numInput1, out cleanNum1))
                {
                    // handling incorrect user input by refusing to accept the input and telling the user about it
                    Console.WriteLine("This is not a valid input. Please enter a numeric value: ");
                    numInput1 = Console.ReadLine();
                }

                // Ask the user to type the second number. This time, if there's an error, we don't tell them about it, we just prompt them for the number again
                Console.WriteLine("Type another number, and the press Enter: ");
                numInput2 = Console.ReadLine();

                double cleanNum2 = 0;
                while (!double.TryParse(numInput2, out cleanNum2))
                {
                    Console.Write("Type another number, and then press Enter: ");
                    numInput2 = Console.ReadLine();
                }

                // Ask the user to choose an operator.
                Console.WriteLine("Choose an operator from the following list: ");
                Console.WriteLine("\ta - Add");
                Console.WriteLine("\ts - Subtract");
                Console.WriteLine("\tm - Multiply");
                Console.WriteLine("\td - Divide");
                // added in step 3
                Console.WriteLine("\tp - to raise the first number to the power of the second numer");
                Console.WriteLine("Your option?");

                string? op = Console.ReadLine();

                // Validate input is not null, and matches the pattern
                if (op == null || ! Regex.IsMatch(op, "[a|s|m|d|p]"))
                {
                    // tells the user they didn't enter a or s or m or d and bails on the program, pushing it to the end where the try again dialogue is presented
                    Console.WriteLine("Error: Unrecognized Input.");
                } else
                {
                    try
                    {
                        result = calculator.DoOperation(cleanNum1, cleanNum2, op);
                        // if, somehow, we get a NaN as a result, this will be displayed
                        if (double.IsNaN(result))
                        {
                            Console.WriteLine("This operation will result in a mathermatical error.\n");
                        }
                        else Console.WriteLine("Your result: {0:0.##}\n", result);
                    }
                    catch (Exception e)
                    // This is the error that is presented if we try to divide by zero, for example
                    {
                        Console.WriteLine("Oh no! An exception occurred trying to do the math.\n - Details: " + e.Message);
                    }
                }
                Console.WriteLine("--------------------------\n");

                // Wait for the user to respond before closing.
                Console.WriteLine("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
                if (Console.ReadLine() == "n") endApp = true;

                Console.WriteLine("\n"); // Friendly linespacing
            }

            // call to close the JSON writer before return
            calculator.Finish();

            return;
        }
    }
}
