namespace Cat_facts;

class Program
{
    static async Task Main(string[] args)
    {
        // string url = "https://catfact.ninja/fact";
        string url = "https://official-joke-api.appspot.com/random_joke";

        Console.Write("Enter 'y' to get a random catfact");
        string input = Console.ReadLine();

        if(input == "y") {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            string responseContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseContent);
        }
    }
}
