namespace HotelPremium.Models.Poco_Classes
{
    public class Hotel
    {
        public Hotel()
        {
            Category = new Category();
        }

        public int HotelId { get; set; }
        public string Name { get; set; }
        public string LongDescription { get; set; }
        public string ShortDescription { get; set; }
        public string Address { get; set; }
        public decimal AveragePricePerRoom { get; set; }
        public string ImageUrl { get; set; }
        public bool HotelOfTheMonth { get; set; }
        public bool IsFullyBooked { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }

    //Many to Many relationships

    //HotelCategoriesId, hotelid, categoryId
    //    1               1           2
    //    2               1           4
    //    3               1           3
    //    4               2           2
    //    5               5           1
    //    6               500         2
    //public class HotelCategories
    //{
    //    public int HotelCategoriesId { get; set; }
    //    public Hotel Hotels { get; set; }
    //    public int HotelId { get; set; }
    //    public int CategoryId { get; set; }
    //    public Category Category { get; set; }
    //}
}
