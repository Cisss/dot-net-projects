namespace ReadFiles;

class Read
{
    static void Main(string[] args)
    {
        string text = File.ReadAllText("SomeText.txt");
        Console.WriteLine($"{text}\n");
        string[] text2 = File.ReadAllLines("numbers.txt");
        int sum = 0;

        foreach (string item in text2){
            sum += int.Parse(item);
        }

        Console.WriteLine($"Sum of numbers in file is: {sum}\n");

        //1. taking input from the user
        Console.WriteLine("Enter a student Name:");
        string studentName = Console.ReadLine();
        //2. Search the student in the file
        // -- open
        // read until the name
        string filePath = "grades.txt";
        using (StreamReader reader = new StreamReader(filePath)){
            string line = "";

            while ((line = reader.ReadLine()) != null) {
            //3. Display Student info in the console
                if (line == studentName) {
                    Console.WriteLine(reader.ReadLine());
                    Console.WriteLine(reader.ReadLine());
                    Console.WriteLine(reader.ReadLine());
                    break;
                }
            }
            if (line == null) {
                Console.WriteLine("Student doesn't exist in this file");
            }
        }
    }
}
