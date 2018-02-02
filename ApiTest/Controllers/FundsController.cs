using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiTest.Controllers
{
    [Route("v1/[controller]")]
    public class FundsController : BaseController
    {
        // GET All Funds
        [HttpGet]
        public Result<List<Fund>> Get()
        {
            var res = new Result<List<Fund>>()
            {
                Data = GetData(),
                Status = "success",
                Message = String.Empty
            };

            return res;
        }

        private List<Fund> GetData()
        {
            var fund = new List<Fund>()
            {
                new Fund() { Id = 1, Name = "Fund 1", Description = "Test Description" },
                new Fund() { Id = 2, Name = "Fund 2" },
                new Fund() { Id = 3, Name = "Fund 3" },
            };
            return fund;
        }
    }

    public class Fund
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}