namespace WriteFiles;

class Program
{
    static void Main(string[] args)
    {
        string filePath = "file.txt";
        using(StreamWriter writer = new StreamWriter(filePath)) {
            writer.Write("Hello World\nhooi");
            writer.WriteLine("Something cool");
            writer.WriteLine("Something even cooler");
            writer.WriteLine("the coolest");
            writer.Write("Hello World\nhooi\n");

        }
        Console.WriteLine("Created new file");
    }
}
