using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheConference.Models
{
    public class SpeakerEvent
    {
        public long Id { get; set; }
        public int TotalTickets { get; set; }
        public int RemainingTickets { get; set; }
        public string Speaker { get; set; }
        public string Description { get; set; }
        
    }
}
