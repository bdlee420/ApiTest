using System.Collections.Generic;
using Common;
using Microsoft.AspNetCore.Mvc;
using Website.Models;

namespace Website.Controllers
{
    [Route("api/[controller]")]
    public class FundController : Controller
    {        
        [HttpGet("[action]")]
        public IEnumerable<Fund> GetFundData()
        {
            var response = ServiceClient<List<Fund>>.GetData($"{Constants.FundAPIUrl}/v1/funds");

            return response.Data;
        }      

    }
}
