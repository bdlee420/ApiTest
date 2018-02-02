using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;

namespace ApiTest.Controllers
{
    [Route("v1/[controller]")]
    public class AssetsController : Controller
    {
        // GET All Assets
        [HttpGet]
        public Result<List<Asset>> Get()
        {
            var assetData = GetData();

            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", "Test");

            var fundData = client.GetStringAsync($"{Constants.FundAPIUrl}/v1/funds").Result;

            var res = new Result<List<Asset>>()
            {
                Data = assetData,
                Status = "success",
                Message = String.Empty
            };

            return res;
        }

        // GET All Assets
        [HttpGet("ids")]
        public Result<List<int>> GetIds()
        {
            var res = new Result<List<int>>()
            {
                Data = GetData().Select(d => d.Id).ToList(),
                Status = "success",
                Message = String.Empty
            };

            return res;
        }

        // GET Asset by Id
        [HttpGet("{id}", Order = 0)]
        public Result<Asset> Get(int id)
        {
            var res = new Result<Asset>()
            {
                Data = GetData().First(a => a.Id == id),
                Status = "success",
                Message = String.Empty
            };

            return res;
        }

        // SEARCH assets, returns List
        [HttpGet("page/{pageId}/pagesize/{pageSize}/searchstring/{searchString}/sortcolumn/{sortColumn}/isdescending/{isDescending}", Order = 1)]
        public Result<List<Asset>> Get(int pageId, int pageSize, string searchString, string sortColumn, bool isDescending)
        {
            var search = new Search(); //build search
            var data = GetData(search);

            var res = new Result<List<Asset>>()
            {
                Data = data,
                Status = "success",
                Message = String.Empty
            };

            return res;
        }

        // SEARCH assets, returns Asset List
        [HttpPost("search")]
        public Result<List<Asset>> Post([FromBody]Search search)
        {
            var assets = new List<Asset>();
            var data = GetData(search);

            //Limit the amout of data being passed back as the Asset object could have lots of properties
            if (search.PropertiesCategory == PropertiesCategory.Default)
            {
                assets = data.Select(d => new Asset() { Id = d.Id, Name = d.Name }).ToList();
            }

            var res = new Result<List<Asset>>()
            {
                Data = data,
                Status = "success",
                Message = String.Empty
            };

            return res;
        }

        // SEARCH assets, returns Int List
        [HttpPost("search/id")]
        public Result<List<int>> PostGetId([FromBody]Search search)
        {
            var assets = new List<Asset>();
            var data = GetData(search).Select(d => d.Id).ToList();

            var res = new Result<List<int>>()
            {
                Data = data,
                Status = "success",
                Message = String.Empty
            };

            return res;
        }

        // SEARCH assets, returns Name List
        [HttpPost("search/name")]
        public Result<List<string>> PostGetName([FromBody]Search search)
        {
            var assets = new List<Asset>();
            var data = GetData(search).Select(d => d.Name).ToList(); ;

            var res = new Result<List<string>>()
            {
                Data = data,
                Status = "success",
                Message = String.Empty
            };

            return res;
        }

        // SEARCH assets, returns List
        [HttpPost("search/count")]
        public Result<int> PostGetCount([FromBody]Search search)
        {
            var data = GetData(search);
            var res = new Result<int>()
            {
                Data = data.Count(),
                Status = "success",
                Message = String.Empty
            };

            return res;
        }

        private List<Asset> GetData()
        {
            var assets = new List<Asset>()
            {
                new Asset() { Id = 1, Name = "Asset 1", Description = "Test Description" },
                new Asset() { Id = 2, Name = "Asset 2" },
                new Asset() { Id = 3, Name = "Asset 3" },
            };
            return assets;
        }

        private List<Asset> GetData(Search search)
        {
            var assets = GetData();
            //DO SOME FILTERING
            return assets;
        }
    }

    public class Asset
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

}
