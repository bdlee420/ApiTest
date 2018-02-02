using System.Collections.Generic;
using Common;
using Microsoft.AspNetCore.Mvc;

namespace Website.Controllers
{
    [Route("api/[controller]")]
    public class FundController : Controller
    {        
        [HttpGet("[action]")]
        public IEnumerable<Fund> GetFundData()
        {
            var response = new ServiceClient<List<Fund>>().GetData($"{Constants.FundAPIUrl}/v1/funds");

            return response.Data;
        }       

        public class Fund
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
        }
    }
}
