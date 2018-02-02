using System.Collections.Generic;
using Common;
using Microsoft.AspNetCore.Mvc;
using Website.Models;

namespace Website.Controllers
{
    [Route("api/[controller]")]
    public class AssetController : Controller
    {
        [HttpGet("[action]")]
        public IEnumerable<Asset> GetAssetData()
        {
            var assetData = new ServiceClient<List<Asset>>().GetData($"{Constants.AssetAPIUrl}/v1/assets");

            var fundData = new ServiceClient<List<Fund>>().GetData($"{Constants.FundAPIUrl}/v1/funds");

            return assetData.Data;
        }

        [HttpGet("[action]")]
        public IEnumerable<Asset> SearchAssetData()
        {
            var search = new Search();

            var assetData = new ServiceClient<List<Asset>>().SearchData($"{Constants.AssetAPIUrl}/v1/assets/search", search);

            return assetData.Data;
        }
    }
}
