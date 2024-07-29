namespace Cat_facts;

class Program
{
    static async Task Main(string[] args)
    {
        string url = "https://catfact.ninja/fact";
        // string url = "https://official-joke-api.appspot.com/random_joke";

        Console.Write("Enter 'y' to get a random catfact");
        string input = Console.ReadLine();

        if(input == "y") {
            using(HttpClient client = new HttpClient()) {
                try {
                    HttpResponseMessage response = await client.GetAsync(url);

                    if ( response.IsSuccessStatusCode)
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();
                        Console.WriteLine(responseContent);
                    }
                    else {
                        Console.WriteLine($"The request was not succesful. {response.StatusCode}");
                    }
                }
                catch (Exception ex) {
                    Console.WriteLine(ex.ToString());
                }

            }

        }
    }
}
