using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ExamTaskBookReservation.Models.Domain;
using Microsoft.AspNetCore.Identity;

namespace ExamTaskBookReservation.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the ApplicaitonUser class
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(50)]
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [MaxLength(50)]
        [Required]
        public string LastName { get; set; } = string.Empty;
        public ICollection<Book>? LikedBooks { get; set; }
    }
}
