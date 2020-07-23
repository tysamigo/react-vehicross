using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PartsController : ControllerBase
    {
        private IWebHostEnvironment _env;
        public PartsController(IWebHostEnvironment env)
        {
            _env = env;
        } 

        [HttpGet]
        public string GetParts()
        {
            var partsFilePath = _env.ContentRootPath + "/Data/parts-list.json";
            string partsData = System.IO.File.ReadAllText(partsFilePath);

            return partsData;
        }
    }
}
