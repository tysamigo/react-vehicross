using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using api.Models;
using System.Text.Json;

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
        public ActionResult<List<Part>> GetParts()
        {
            return LoadPartsData();
        }

        [HttpGet("search/{term}")]
        public ActionResult<List<Part>> SearchParts(string term)
        {
            string lowerTerm = term.ToLower();

            // Deserialize JSON data to C# objects for searchability
            List<Part> partsList = LoadPartsData();

            // Search list of part objects for objects whos part name contains the search term
            List<Part> matchingParts = partsList.Where((part) => 
            {
                string lowerPartName = part.PartName.ToLower();
                return lowerPartName.Contains(lowerTerm);
            }).ToList();

            return matchingParts;
        }

        private List<Part> LoadPartsData()
        {
            var partsFilePath = _env.ContentRootPath + "/Data/parts-list.json";
            string partsData = System.IO.File.ReadAllText(partsFilePath);

            return JsonSerializer.Deserialize<List<Part>>(partsData);
        }
    }
}
