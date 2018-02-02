using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace Common
{
    public class ServiceClient<T>
    {
        public Result<T> GetData(string url)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", "Test");

            var responseJSON = client.GetStringAsync(url).Result;
            var data = JsonConvert.DeserializeObject<Result<T>>(responseJSON);

            return data;
        }
    }
}
