namespace DateFacts;

class Program
{
    static async Task Main(string[] args)
    {
        string month;
        while (true) {
            Console.WriteLine("Enter a month (number 1-12):");
            month = Console.ReadLine();
            int number = int.Parse(month);
            if (number <= 12) {
                break;
            }

            Console.WriteLine("try again");
        }

        string day;
        while (true) {
            Console.WriteLine("Enter a day of the month (number 1-31):");
            day = Console.ReadLine();
            int number = int.Parse(day);
            if (number <= 31) {
                break;
            }

            Console.WriteLine("try again");
        }

        string url = $"http://numbersapi.com/{month}/{day}/date";

        HttpClient client = new HttpClient();
        HttpResponseMessage response = await client.GetAsync(url);
        string responseContent = await response.Content.ReadAsStringAsync();

        Console.WriteLine(responseContent);
    }
}
