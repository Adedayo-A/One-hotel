using HotelPremium.Models;
using HotelPremium.Models.DataAbstraction.Abstraction;
using HotelPremium.Models.DataAbstraction.Implementation.AdoNet;
using HotelPremium.Models.DataAbstraction.Implementation.FileImplementation;

namespace HotelPremium
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<IUserFavoriteHotelsRepo, AdoNetHotelRepository>();

            builder.Services.AddScoped<IHotelRepository, AdoNetHotelRepository>();

            builder.Services.AddScoped<IAuthentication, UserRepository>();

            builder.Services.AddScoped<ICategory, CategoryRepository>();


            var app = builder.Build();

            if(app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

           // app.MapDefaultControllerRoute();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(name: "default",
                pattern: "{controller=User}/{action=Login}/{id?}");


            //Seeding.SeedData(); //File JSON
            SeedDataADONET.SeedData(builder.Configuration);

            app.Run();
        }
    }
}