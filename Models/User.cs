using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace WeddingPlannerRadhin
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "First Name must be 8 characters or longer!")]
        public string FirstName { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Last Name must be 8 characters or longer!")]
        public string LastName { get; set; }
        [EmailAddress] // Must Be in email address form
        [Required]
        [MinLength(2, ErrorMessage = "Email must be 8 characters or longer!")]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required]
        [MinLength(8, ErrorMessage = "Password must be 8 characters or longer!")]
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        // Will not be mapped to your users table!
        [NotMapped]
        [Required]
        [Compare("Password")]
        [DataType(DataType.Password)]
        [MinLength(2, ErrorMessage = "Password must be 8 characters or longer!")]
        public string Confirm { get; set; }
        public List<RSVP> listOfReservations { get; set; }
    }
}
