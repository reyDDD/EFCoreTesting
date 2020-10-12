using EFCoreTesting.Models;
using EFCoreTesting.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;


using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Net;

namespace XUnitTestProject1
{
    public class TestingMiddleware 
    {
 
        [Fact]
        public async Task TestForMiddlrware()
        {
            using var host = await new HostBuilder()
                .ConfigureWebHost(builder =>
                {
                    builder
                    .UseTestServer()
                    .ConfigureServices(services =>
                    {
                        services.AddDbContext<Context>(options => options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EFCoreTests;Trusted_Connection=True;MultipleActiveResultSets=True;App=EntityFramework;"));
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

                    })
                    .Configure(app =>
                    {
                        app.UseDeveloperExceptionPage();
                        app.UseResponseCaching();
                        app.UseStaticFiles();
                        app.UseStatusCodePages();
                        app.UseRouting();

                        app.UseEndpoints(endpoints =>
                        {
                            endpoints.MapControllerRoute("default", "{controller=One2Many}/{action=Index}/{id?}");
                            endpoints.MapDefaultControllerRoute();
                            endpoints.MapRazorPages();
                            endpoints.MapBlazorHub();
                            endpoints.MapFallbackToController("Blazor", "Home");
                            endpoints.MapFallbackToPage("/route/{param}", "/_Host");
                            endpoints.MapFallbackToPage("/work05a10/{param?}", "/_Host");
                        });
                    });
                })
                .StartAsync();


            var response = await host.GetTestClient().GetAsync("/Null");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
