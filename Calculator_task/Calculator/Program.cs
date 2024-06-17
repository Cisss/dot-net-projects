using System;
using System.Reflection;

public class Calculator
{
    public static void Main(string[] args)
    {
        char operation;
        float first, second;

        while (true) {
        try
        {
            Console.WriteLine("Enter an operation (+, -, /, *): ");
            operation = Console.ReadLine()[0];
            Console.WriteLine(operation);
            if("+-*/".Contains(operation))
            break;
        }
        catch {}
            Console.WriteLine("Error: Input must be equal to: +, -, /, *");

        }

        while (true) {
            try {
                Console.WriteLine("Enter first number (f.i.: 44 / 5 / 60 / 7.7): ");
                first = float.Parse(Console.ReadLine());
                break;
            }
            catch {
                Console.WriteLine("Error: Enter a valid float number.");
            }
        }

        while (true) {
            try {
                Console.WriteLine("Enter Second number (f.i.: 44 / 5.78 / 60 / 7.7): ");
                second = float.Parse(Console.ReadLine());
                break;
            } catch {
                Console.WriteLine("Error: Enter a valid float number.");
            }
        }

        float result = 0;
        if (operation == '+') {
            result = first + second;
        } else if (operation == '-') {
            result = first - second;
        } else if (operation == '*') {
            result = first * second;
        } else if (operation == '/') {
            result = first / second;
        }

        Console.WriteLine($"The result of '{first} {operation} {second}' is: {result}");

    }
}
