namespace HotelPremium.Models.Poco_Classes
{
    public class Hotel
    {
        public int HotelId { get; set; }
        public string Name { get; set; }
        public string LongDescription { get; set; }
        public string ShortDescription { get; set; }
        public string Address { get; set; }
        public decimal AveragePricePerRoom { get; set; }
        public string ImageUrl { get; set; }
        public bool HotelOfTheMonth { get; set; }
        public bool isFullyBooked { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
