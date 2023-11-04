namespace HotelPremium.Models.Poco_Classes
{
    public class GetSingleHotelVM
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
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
    }
}
