using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PortuRestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubscribersController : ControllerBase
    {

        public Uri baseAddress = new Uri("https://api2.ecomailapp.cz/");
        public string API_KEY = "618128f2d46d3618128f2d46d5";

        [HttpGet]
        public async Task<string> Get()
        {
            using (var httpClient = new HttpClient { BaseAddress = baseAddress })
            {

                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("key", API_KEY);

                using (var response = await httpClient.GetAsync("lists/" + "1" + "/subscribers"))
                {

                    string responseData = await response.Content.ReadAsStringAsync();
                    return responseData;
                }
            }

        }

        [HttpPost]
        public async Task<string> Post(Subscriber subscriber)
        {
            using (var httpClient = new HttpClient { BaseAddress = baseAddress })
            {
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("key", API_KEY);

                using (var content = new StringContent("{  \"subscriber_data\": {    \"name\": " + subscriber.name + ",    \"surname\": " + subscriber.surname + ", \"city\": " + subscriber.city + ",    \"street\": " + subscriber.street + ",    \"zip\": " + subscriber.zip + ",    \"country\": " + subscriber.country, System.Text.Encoding.Default, "application/json"))
                {
                    using (var response = await httpClient.PostAsync("lists/" + "1" + "/subscribe", content))
                    {
                        string responseData = await response.Content.ReadAsStringAsync();
                        return responseData;
                    }
                }
            }

        }

        [HttpPut]
        public async Task<string> Put()
        {
            using (var httpClient = new HttpClient { BaseAddress = baseAddress })
            {
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("key", API_KEY);

                using (var content = new StringContent("{  \"email\": \"jan@novak.cz\",  \"subscriber_data\": {    \"name\": \"Foo\",    \"surname\": \"Bar\"  }}", System.Text.Encoding.Default, "application/json"))
                {
                    using (var response = await httpClient.PutAsync("lists/" + "1" + "/update-subscriber", content))
                    {
                        string responseData = await response.Content.ReadAsStringAsync();
                        return responseData;
                    }
                }
            }
        }

        [HttpDelete]
        public async Task<string> Delete(string email)
        {
            using (var httpClient = new HttpClient { BaseAddress = baseAddress })
            {
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("key", API_KEY);

                using (var response = await httpClient.DeleteAsync("subscribers/" + email + "/delete"))
                {
                    string responseData = await response.Content.ReadAsStringAsync();
                    return responseData;
                }
            }

        }
    }
}
