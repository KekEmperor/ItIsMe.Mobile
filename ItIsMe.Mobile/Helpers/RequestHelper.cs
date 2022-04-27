using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ItIsMe.Mobile.Helpers
{
    public static class RequestHelper
    {
        private const string URL = "http://myit-service-lb-23246224.eu-west-1.elb.amazonaws.com/api/";

        public static async Task<TResponse> Get<TResponse>(string requestUrl)
        {
            HttpResponseMessage httpResponse;
            using (HttpClient client = new HttpClient())
            {
                httpResponse = await client.GetAsync(URL + requestUrl);
            }

            var stringResponse = await httpResponse.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<TResponse>(stringResponse);
        }

        public static async Task<TResponse> Post<TRequest, TResponse>(TRequest model, string requestUrl)
        {
            var jsonRequest = JsonConvert.SerializeObject(model);
            var data = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            HttpResponseMessage httpResponse;
            using (HttpClient client = new HttpClient())
            {
                httpResponse = await client.PostAsync(URL + requestUrl, data);
            }

            var stringResponse = await httpResponse.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<TResponse>(stringResponse);
        }
    }
}
