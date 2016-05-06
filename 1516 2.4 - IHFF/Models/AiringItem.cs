using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IHFF.Models
{
    public class AiringItem
    {
        public AiringItem() { }

        public AiringItem(int airingId, string airingText)
        {
            this.AiringId = airingId;
            this.AiringText = airingText;

        }

        public AiringItem(int airingId, string locationName, string locationRoom, TimeSpan startTime, 
            TimeSpan endTime, string dayOfWeek, int amountOfTickets, decimal price)
        {
            this.AiringId = airingId;
            this.LocationName = locationName;
            this.LocationRoom = locationRoom;
            this.StartTime = startTime;
            this.EndTime = endTime;
            this.DayOfWeek = dayOfWeek;
            this.amountOfTickets = amountOfTickets;
            this.Price = price;
        }

        public int AiringId { get; set; }
        public string AiringText { get; set; }
        public string LocationName { get; set; }
        public string LocationRoom { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string DayOfWeek { get; set; }
        public int amountOfTickets { get; set; }
        public decimal Price { get; set; }
    }
}