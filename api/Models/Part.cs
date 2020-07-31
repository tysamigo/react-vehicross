using System.Text.Json.Serialization;

namespace api.Models
{
    public class Part
    {
        [JsonPropertyName("Part")]
        public string PartName { get; set; }

        public string PartNumber { get; set; }

        public string Manufacturer { get; set; }

        public string Supplier { get; set; }

        public string Warranty { get; set; }

        public int Quantity { get; set; }

        [JsonPropertyName("Unit Price")]
        public decimal UnitPrice { get; set; }

        public string Notes { get; set; }
    }
}