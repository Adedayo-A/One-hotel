using HotelPremium.Models;
using HotelPremium.Models.DataAbstraction.Abstraction;
using HotelPremium.Models.DataAbstraction.Implementation.AdoNet;
using HotelPremium.Models.DataAbstraction.Implementation.FileImplementation;
using HotelPremium.Helpers;
using HotelPremium.Models.Poco_Classes;
using HotelPremium.Models.DataAbstraction.Implementation.EFCore;
using Microsoft.EntityFrameworkCore;

namespace HotelPremium
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            builder.Services.AddExternalServices();

            builder.Services.AddDbContext<HotelContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("HotelPremiumDbEf"));
            });

            var app = builder.Build();

            if(app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {

            }

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var context = services.GetRequiredService<HotelContext>();
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                DbInitializerEF.Initialize(context);
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