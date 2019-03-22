using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace WeddingPlannerRadhin
//Weddings can have many users(aka guest)
{
    public class Wedding
    {
        [Key]
        public int WeddingId { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Name must be 2 characters or longer!")]
        public string Bride { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Name must be 2 characters or longer!")]
        public string Groom { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public DateTime time {get;set;}
        [Required]
        public int duration {get;set;}
        [Required]
        public string durationunit {get;set;}
        [Required]
        [MinLength(2, ErrorMessage = "Must input an address")]
        public string Address { get; set; }

        public int UserId {get; set; } // You need this to pass in whe you add a wedding because the user id will be assigned to the wedding id
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public List<RSVP> listOfGuests { get; set; }
        public User User { get; set; }
    }
}
