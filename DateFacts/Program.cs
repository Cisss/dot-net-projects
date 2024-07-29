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

        using (HttpClient client = new HttpClient()) {
            try {
                HttpResponseMessage response = await client.GetAsync(url);
                if(response.IsSuccessStatusCode) {
                    string responseContent = await response.Content.ReadAsStringAsync();

                    Console.WriteLine(responseContent);
                }
                else {
                    Console.WriteLine($"Request failed: {response.StatusCode}");
                }
            } catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
