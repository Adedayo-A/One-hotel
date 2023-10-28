namespace HotelPremium.Models.Poco_Classes
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Hotel> Hotels { get; set;}
    }
}
