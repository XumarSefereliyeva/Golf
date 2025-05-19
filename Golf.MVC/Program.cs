using Golf.BL.Services;
using Golf.DAL.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Golf.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();


            builder.Services.AddScoped<AppDbContext>();
            builder.Services.AddScoped<GolfPrService>();
            
            builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("default")));

            var app = builder.Build();

            app.UseStaticFiles();

            app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=GolfPr}/{action=Index}/{id?}"
             );

            app.MapControllerRoute(  
                name:"Default",
                pattern:"{Controller=Home}/{Action=Index}"
                );

            app.Run();
        }
    }
}
