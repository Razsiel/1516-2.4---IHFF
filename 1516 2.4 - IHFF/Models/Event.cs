using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IHFF.Models
{
    [Table("Event")]
    public abstract class Event
    {
        public int EventId { get; set; }
        public DateTime Date { get; set; }
        public int LocationId { get; set; }
        public string ExtraInfo { get; set; }
    }
}