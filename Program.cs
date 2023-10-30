using HotelPremium.Models.DataAbstraction.Abstraction;
using HotelPremium.Models.DataAbstraction.Implementation;

namespace HotelPremium
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<IUserFavoriteHotelsRepo, HotelRepository>();

            builder.Services.AddScoped<IHotelRepository, HotelRepository>();

            builder.Services.AddScoped<IAuthentication, UserRepository>();


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
                pattern: "{controller=User}/{action=Login}");

            app.Run();
        }
    }
}