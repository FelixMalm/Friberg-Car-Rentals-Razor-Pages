using System.ComponentModel.DataAnnotations;

namespace Friberg_Car_Rentals__Razor_Pages_.Data
{
    public class Car
    {
        public Car()
        {
            
        }
        public int Id { get; set; }

        [Required]
        public string Model { get; set; }
        [Required]
        public int Price { get; set; }
        public string? Picture { get; set; }
    }
}
