using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace Common
{
    public class ServiceClient<T>
    {
        private readonly static HttpClient _client = new HttpClient();
        private const string _mediaType_JSON = "application/json";

        private static HttpClient GetHttpClient()
        {
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(_mediaType_JSON));
            return _client;
        }

        public Result<T> GetData(string url)
        {
            var client = GetHttpClient();

            var responseJSON = client.GetStringAsync(url).Result;

            var data = JsonConvert.DeserializeObject<Result<T>>(responseJSON);

            return data;
        }

        public Result<T> SearchData(string url, Search search)
        {
            var client = GetHttpClient();

            var searchJson = JsonConvert.SerializeObject(search);
            var buffer = System.Text.Encoding.UTF8.GetBytes(searchJson);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue(_mediaType_JSON);

            var response = client.PostAsync(url, byteContent).Result;
            var responseJSON = response.Content.ReadAsStringAsync().Result;
            var data = JsonConvert.DeserializeObject<Result<T>>(responseJSON);

            return data;
        }
    }
}
