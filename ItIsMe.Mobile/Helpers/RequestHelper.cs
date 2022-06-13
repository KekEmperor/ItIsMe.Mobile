using ItIsMe.Mobile.RequestModels.AssignStudentTest;
using Newtonsoft.Json;
using System.Net;
using System.Text;

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

        public static async Task<HttpStatusCode> Get(string requestUrl)
        {
            HttpResponseMessage httpResponse;
            using (HttpClient client = new HttpClient())
            {
                httpResponse = await client.GetAsync(URL + requestUrl);
            }

            return httpResponse.StatusCode;
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

        public static TResponse Post<TResponse>(string requestUrl)
        {
            HttpResponseMessage httpResponse;
            using (HttpClient client = new HttpClient())
            {
                httpResponse = client.PostAsync(URL + requestUrl, new StringContent("", Encoding.UTF8, "application/json")).Result;
            }

            var stringResponse = httpResponse.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<TResponse>(stringResponse);
        }

        public static HttpStatusCode PostTest<TRequest>(TRequest model, string requestUrl) where TRequest : ITestRequest
        {
            var data = new StringContent(model.GetString(), Encoding.UTF8, "application/json");

            HttpResponseMessage httpResponse;
            using (HttpClient client = new HttpClient())
            {
                httpResponse = client.PostAsync(URL + requestUrl, data).Result;
            }

            return httpResponse.StatusCode;
        }

        public static async Task<HttpStatusCode> PostImage(FileResult fileResult, string testId)
        {
            using Stream sourceStream = await fileResult.OpenReadAsync();
            using HttpClient httpClient = new HttpClient();

            MultipartFormDataContent form = new MultipartFormDataContent();

            var image = new StreamContent(sourceStream);

            form.Add(image, "file", fileResult.FileName);

            var response = await httpClient.PostAsync(URL + $"assignedStudentTests/upload?assignedStudentTestId={testId}", form);

            return response.StatusCode;
        }
    }
}
