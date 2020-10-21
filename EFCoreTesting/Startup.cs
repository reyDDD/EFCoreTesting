using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using EFCoreTesting.Models;
using EFCoreTesting.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;


namespace EFCoreTesting
{
    public class Startup
    {
        public IConfiguration Configuration { get; }


        public Startup(IConfiguration config)
        {
            Configuration = config;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<Context>(options => options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));
            services.AddDbContext<Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection2")));
 
            services.AddScoped<WorkOne2Many>();


            services.AddMvc(opt =>
            {
                opt.CacheProfiles.Add("Caching2", new CacheProfile() { Duration = 30 });
                opt.CacheProfiles.Add("NoCaching2", new CacheProfile()
                {
                    Location = ResponseCacheLocation.None,
                    NoStore = true
                }
                );
            });

            //services.AddControllersWithViews().AddRazorRuntimeCompilation();
            //services.AddRazorPages().AddRazorRuntimeCompilation();
            services.AddServerSideBlazor();
            services.AddResponseCaching();

            services.AddScoped<InjectService>();
            services.AddScoped<InjectService2>();
            services.AddScoped<InjectServices>();
            services.AddScoped<One2Many>();
            services.AddScoped<NotifyService>();
            services.AddScoped<ICartRepository, CartRepositoryInMemory>();
            services.AddSingleton<Notifiyer>();
            services.AddScoped<WorkRelation>();
            services.AddScoped<Work2809>();
            services.AddScoped<Vozvrat2909>();
            services.AddScoped<ServiceWithAnalogDBContext>();
            services.AddScoped<NotNullModelService>();
            services.AddScoped<INotNullModelService, NotNullModelService>();
            services.AddScoped<ReturnDateSevice>();
            services.AddScoped<ComponentBasese>();
            services.AddScoped<IWork2809, Work2809>();
            services.AddScoped<Iintegra, Integra>();
            services.AddScoped<IVozvrat2909, Vozvrat2909>();
            services.AddScoped<Work1810Service>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            //настройка русской локализации
            var defaultCulture = new CultureInfo("ru-RU");
            var localizationOptions = new RequestLocalizationOptions()
            {
                DefaultRequestCulture = new RequestCulture(defaultCulture),
                SupportedCultures = new List<CultureInfo> { defaultCulture },
                SupportedUICultures = new List<CultureInfo> { defaultCulture }
            };
            app.UseRequestLocalization(localizationOptions);


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseResponseCaching();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseStatusCodePages();
            app.UseRouting();



            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllers();
                endpoints.MapControllerRoute("Default", pattern: "vpered/valim", defaults: new { controller = "NotNull", action = "Index24" });
                endpoints.MapControllerRoute("Default", pattern: "vpered/{*article}", defaults: new { controller = "Null", action = "Index" });
                endpoints.MapControllerRoute("Default", "{controller=one2many}/{action=Index}/{id?}");
                endpoints.MapDefaultControllerRoute();
                endpoints.MapRazorPages();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToController("Blazor", "Home");
                endpoints.MapFallbackToPage("/route/{param}", "/_Host");
                // endpoints.MapFallbackToPage("/_Host");
                endpoints.MapFallbackToPage("/work05a10/{param?}", "/_Host");
                endpoints.MapFallbackToPage("/work1310/{param?}", "/_Host");

            });
        }
    }
}
