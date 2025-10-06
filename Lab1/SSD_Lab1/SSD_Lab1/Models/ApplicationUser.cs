using Microsoft.AspNetCore.Identity;

namespace SSD_Lab1.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }   
        public string LastName { get; set; }    
        public string? City { get; set; }       
        public string? PhoneNumber { get; set; } 
    }
}
