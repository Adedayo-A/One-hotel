using HotelPremium.Models.Poco_Classes;
using Microsoft.EntityFrameworkCore;

namespace HotelPremium.Models.DataAbstraction.Implementation.EFCore
{
    public class HotelContext : DbContext
    {
        public HotelContext(DbContextOptions<HotelContext> options) : base(options) { }
        
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
