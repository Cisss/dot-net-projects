namespace Asynchronous_programming;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine(">> Begin");
        Task<int> taskOne = Delay("Eating", 5000);
        Task<int> taskTwo = Delay("Sleeping", 3000);

        int result = await taskOne;
        await taskTwo;

        Console.WriteLine($"Result: {result}");
        Console.WriteLine(">> End");
    }

    static async Task<int> Delay(string taskName, int delayDuration) {

        Console.WriteLine($"{taskName} started");
        await Task.Delay(delayDuration);
        Console.WriteLine($"{taskName} completed");

        return 1;
    }
}
