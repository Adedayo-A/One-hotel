using HotelPremium.Models.DataAbstraction.Abstraction;
using HotelPremium.Models.DataAbstraction.Implementation.AdoNet;
using HotelPremium.Models.DataAbstraction.Implementation.FileImplementation;

namespace HotelPremium.Helpers
{
    public static class Extensions
    {
        public static void AddExternalServices(this IServiceCollection services)
        {
            services.AddScoped<IUserFavoriteHotelsRepo, AdoNetHotelRepository>();
            services.AddScoped<IHotelRepository, AdoNetHotelRepository>();
            services.AddScoped<IAuthentication, AdoNetUserRepository>();
            services.AddScoped<ICategory, CategoryRepository>();
        }
    }
}
