using System;

namespace api.Models
{
    public class Maintenance
    {
        public DateTime Date { get; set; }
        public int DaysSince
        {
            get
            {
                // Get TimeSpan since service date
                TimeSpan timeSpanSince = DateTime.Now - Date;

                // Return the total number of days, round up to whole number
                return (int)Math.Round(timeSpanSince.TotalDays);
            }
        }
        public int Odometer { get; set; }
        public string ServicePerformed { get; set; }
        public string Location { get; set; }
        public string TotalCost { get; set; }
        public string Notes { get; set; }
    }
}