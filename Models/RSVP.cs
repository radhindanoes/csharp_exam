using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace WeddingPlannerRadhin
//RSVP links weddings to users (guests)
{
    public class RSVP
    {
        [Key]
        public int RSVPId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int WeddingId { get; set; }
        public Wedding Wedding { get; set; }
    }
}