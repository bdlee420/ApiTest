﻿using System;
using System.Collections.Generic;
using System.Linq;
using Common;
using Microsoft.AspNetCore.Mvc;

namespace ApiTest.Controllers
{
    [Route("v1/[controller]")]
    public class AssetsController : Controller
    {
        // GET All Assets
        [HttpGet]
        //URL: http://localhost:61301/v1/assets
        public Result<List<Asset>> Get()
        {
            var assetData = GetData();

            var data = ServiceClient<List<Fund>>.GetData($"{Constants.FundAPIUrl}/v1/funds");

            var res = new Result<List<Asset>>()
            {
                Data = assetData,
                Status = "success",
                Message = String.Empty
            };

            return res;
        }

        // GET All Assets
        // URL: http://localhost:61301/v1/assets/ids
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
        // URL: http://localhost:61301/v1/assets/1
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
        // NOTES: Probably will not use long URLs like this.  POST is fine are easier to make changes to
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
        // URL: http://localhost:61301/v1/assets/search
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
        // URL: http://localhost:61301/v1/assets/search/id
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
        // URL: http://localhost:61301/v1/assets/search/name
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
        // URL: http://localhost:61301/v1/assets/search/count
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
            IEnumerable<Asset> res = null;

            if (search.Filter != null && !String.IsNullOrEmpty(search.Filter.SearchString))
                res = assets.Where(a => a.Name.Contains(search.Filter.SearchString, StringComparison.OrdinalIgnoreCase));

            return res?.ToList() ?? assets;
        }
    }

    public class Asset
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class Fund
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

}
