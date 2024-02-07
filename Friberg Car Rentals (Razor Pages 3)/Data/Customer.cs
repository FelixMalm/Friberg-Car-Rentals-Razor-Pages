using System.ComponentModel.DataAnnotations;

namespace Friberg_Car_Rentals__Razor_Pages_.Data
{
    public class Customer
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }
        
        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }
        
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }
        
        [Required(ErrorMessage = "Password is required")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long")]
        public string Password { get; set; }
        
        [Required(ErrorMessage = "Role is required")]
        public string Role { get; set; }
    }
}