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
using api.Converters;

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
        public ActionResult<List<Maintenance>> GetMaintenance()
        {
            string maintenanceData = LoadMaintenanceData();

            // Deserialize JSON data to C# objects for calculations, use custom date converter for MM/DD/YYYY format
            JsonSerializerOptions serializerOptions = new JsonSerializerOptions();
            serializerOptions.Converters.Insert(0, new DateConverter());

            List<Maintenance> maintenanceList = JsonSerializer.Deserialize<List<Maintenance>>(maintenanceData, serializerOptions);

            return maintenanceList;
        }

        private string LoadMaintenanceData()
        {
            var maintenanceFilePath = _env.ContentRootPath + "/Data/maintenance.json";
            string maintenanceData = System.IO.File.ReadAllText(maintenanceFilePath);

            return maintenanceData;
        }
    }
}
