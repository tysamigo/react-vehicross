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
    public class MaintenanceController : ControllerBase
    {
        private IWebHostEnvironment _env;
        public MaintenanceController(IWebHostEnvironment env)
        {
            _env = env;
        } 

        [HttpGet]
        public string GetMaintenance()
        {
            var maintenanceFilePath = _env.ContentRootPath + "/Data/maintenance.json";
            string maintenanceData = System.IO.File.ReadAllText(maintenanceFilePath);

            return maintenanceData;
        }
    }
}
