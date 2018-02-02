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

        public Result<T> SearchData(string url, Search search)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", "Test");

            var searchJson = JsonConvert.SerializeObject(search);
            var buffer = System.Text.Encoding.UTF8.GetBytes(searchJson);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = client.PostAsync(url, byteContent).Result;
            var responseJSON = response.Content.ReadAsStringAsync().Result;
            var data = JsonConvert.DeserializeObject<Result<T>>(responseJSON);

            return data;
        }
    }
}
