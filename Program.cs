using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace webOdev3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureServices(services =>
                    {
                        // Session i�in gerekli yap�land�rmalar
                        services.AddDistributedMemoryCache();  // Bellek i�i cache kullan�lacak
                        services.AddSession(options =>
                        {
                            options.IdleTimeout = TimeSpan.FromMinutes(30); // Session s�resi
                            options.Cookie.HttpOnly = true;  // Cookie'yi sadece HTTP istekleri i�in eri�ilebilir yap
                            options.Cookie.IsEssential = true;  // Cookie'nin temel olmas� gerekti�ini belirt
                        });

                        services.AddControllersWithViews();  // MVC ile controller ve view ekleniyor
                    });

                    webBuilder.Configure(app =>
                    {
                        // Statik dosyalar�n sunulmas� (CSS, JS, vb.)
                        app.UseStaticFiles();

                        // Session middleware'ini ekleyin
                        app.UseSession();

                        // Routing
                        app.UseRouting();

                        // Authorization middleware'ini ekleyin
                        app.UseAuthorization();

                        // Endpoint yap�land�rmas�
                        app.UseEndpoints(endpoints =>
                        {
                            endpoints.MapControllerRoute(
                                name: "default",
                                pattern: "{controller=Home}/{action=Index}/{id?}");
                        });
                    });
                });
    }
}
