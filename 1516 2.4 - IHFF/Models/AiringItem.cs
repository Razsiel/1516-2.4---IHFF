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

        public int AiringId { get; set; }
        public string AiringText { get; set; }
    }
}