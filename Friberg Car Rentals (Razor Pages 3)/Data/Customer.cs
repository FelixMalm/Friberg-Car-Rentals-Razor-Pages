using System.ComponentModel.DataAnnotations;

namespace Friberg_Car_Rentals__Razor_Pages_.Data
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
    }
}
