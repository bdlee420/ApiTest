using System.Collections.Generic;
using Common;
using Microsoft.AspNetCore.Mvc;

namespace Website.Controllers
{
    [Route("api/[controller]")]
    public class AssetController : Controller
    {
        [HttpGet("[action]")]
        public IEnumerable<Asset> GetAssetData()
        {
            var response = new ServiceClient<List<Asset>>().GetData($"{Constants.AssetAPIUrl}/v1/assets");

            return response.Data;
        }

        public class Asset
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
        }
    }
}
