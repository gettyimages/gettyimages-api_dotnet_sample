using System;
using System.Diagnostics;
using System.Threading.Tasks;
using GettyImages.Api.Entity;
using Newtonsoft.Json;

namespace GettyImages.Api.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync(args).Wait(TimeSpan.FromSeconds(30));
        }

        static async Task MainAsync(string[] args)
        {
            var apiKey = args[0];
            var apiSecret = args[1];

            Debug.Assert(!string.IsNullOrEmpty(apiKey), "API Key must have a value");
            Debug.Assert(!string.IsNullOrEmpty(apiSecret), "API Secret must have a value");
            var client = ApiClient.GetApiClientWithClientCredentials(apiKey, apiSecret);
            var results = await client
                .SearchImagesCreative()
                .WithGraphicalStyle(GraphicalStyles.Photography)
                .WithPhrase("food")
                .WithSortOrder(SortOrder.MostPopular)
                .ExecuteAsync();
            Console.WriteLine(JsonConvert.SerializeObject(results, Formatting.Indented));
        }
    }
}
