namespace FileBasedCalculator;

class Program
{
    static void Main(string[] args)
    {
        string filePath = "file.txt";
        string filePath1 = "1.txt";
        string filePath2 = "2.txt";

        string[] file1 = File.ReadAllLines(filePath1);
        string[] file2 = File.ReadAllLines(filePath2);

        char operation;

        while (true) {
            Console.Write("Enter an operation (+, -, /, *): ");
            if (char.TryParse(Console.ReadLine(), out operation) && "+-*/".Contains(operation))
                break;

            Console.WriteLine("invalid operation");
        }

        float result = 0;
        using(StreamWriter writer = new StreamWriter(filePath)) {

            for(int i = 0; i < file1.Length; i++) {
                float num1 = float.Parse(file1[i]);
                float num2 = float.Parse(file2[i]);

                if (operation == '+')
                    result = num1 + num2;
                else if (operation == '-')
                    result = num1 - num2;
                else if (operation == '*')
                    result = num1 * num2;
                else if (operation == '/')
                    if (num1 == 0 | num2 == 0)
                        result = 0;
                    else
                        result = num1 / num2;

                writer.WriteLine(result);
            }

        }
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"File: {filePath} with the numbers[1] out 1.txt {operation} numbers[1] out 2.txt is created!");
    }
}
