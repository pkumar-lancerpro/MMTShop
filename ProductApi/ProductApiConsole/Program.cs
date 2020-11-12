using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ProductApiConsole
{
    class Program
    {
        static HttpClient client = new HttpClient();

        const string FEATUREDPRODUCTSAPIPATH = "/api/products/featured";
        const string CATEGORIESAPIPATH = "/api/categories";
        const string PRODUCTSBYCATEGORYAPIPATH = "/api/products/bycategory";
        const string CATEGORYID = "1"; 

        static async Task Main(string[] args)
        {
            client.BaseAddress = new Uri("https://localhost:44332");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            Console.WriteLine("############# 1a. Featured Products ############# ");
            await MakeApiCall(FEATUREDPRODUCTSAPIPATH);

            Console.WriteLine("############# 1b. Available Categories ############# ");
            await MakeApiCall(CATEGORIESAPIPATH);

            Console.WriteLine($"############# 1c. Products By Category: {CATEGORYID} ############# ");
            await MakeApiCall($"{PRODUCTSBYCATEGORYAPIPATH}/{CATEGORYID}");
        }

        static async Task MakeApiCall(string apiPath)
        {
            string returnJson = null;
            HttpResponseMessage response = await client.GetAsync(apiPath);
            if (response.IsSuccessStatusCode)
            {
                returnJson = await response.Content.ReadAsStringAsync();
            }
            Console.WriteLine(returnJson);
        }
    }
}
