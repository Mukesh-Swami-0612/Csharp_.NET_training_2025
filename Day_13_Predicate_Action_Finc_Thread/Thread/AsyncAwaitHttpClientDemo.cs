using System;
using System.Net.Http;
using System.Threading.Tasks;

class AsyncAwaitHttpClientDemo
{
    // This class contains async methods
    public class ThreadExample1
    {
        // Async method that waits for 3 seconds
        public static async Task AsyncMethod()
        {
            Console.WriteLine("Task Started...");
            await Task.Delay(3000); // waits 3 seconds
            Console.WriteLine("Task completed after 3 sec...");
        }

        // Fetching data from a URL using HttpClient
        public async Task<string> FetchDataAsync(string url)
        {
            // HttpClient is used to send HTTP request and get response
            using (HttpClient client = new HttpClient())
            {
                string data = await client.GetStringAsync(url); // download response text
                return data;
            }
        }

        // This method calls FetchDataAsync + AsyncMethod
        public async Task CallMethod()
        {
            Console.WriteLine("Fetching Data...");

            // ✅ Best URL for testing (recommended)
            string result = await FetchDataAsync("https://jsonplaceholder.typicode.com/todos/1");

            // ⚠️ google.com may not always work due to restrictions / HTML response
            // string result = await FetchDataAsync("https://google.com");

            Console.WriteLine("Data Fetched:");
            Console.WriteLine(result);

            // Call another async method
            await AsyncMethod();
        }
    }

    // Main method must be async to use await
    public static async Task Main(string[] args)
    {
        ThreadExample1 obj = new ThreadExample1();

        // Calling async method
        await obj.CallMethod();

        Console.WriteLine("Program Finished");
    }
}
