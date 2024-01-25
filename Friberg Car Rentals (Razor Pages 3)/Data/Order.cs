namespace Friberg_Car_Rentals__Razor_Pages_.Data
{
    public class Order
    {
        public int Id { get; set; }
        public Car Car { get; set; }
        public Customer Customer { get; set; }
    }
}
