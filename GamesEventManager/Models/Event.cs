using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ServiceStack.DataAnnotations;

namespace GamesEventManager.Models
{
    public class Event
    {
        [AutoIncrement]
        public int Id { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }
       [System.ComponentModel.DataAnnotations.Required]
        public string Venue { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public string Address { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        [Display(Name = "Date")]
        public DateTime EventDateTime { get; set; }
        [Display(Name = "Website")]
        public string EventWebsite { get; set; }
    }
}