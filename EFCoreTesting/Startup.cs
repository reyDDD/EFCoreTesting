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
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.IO;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using EFCoreTesting.Infrastructure;
using EFCoreTesting.Areas.Two.Controllers;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.SqlServer;
using Microsoft.AspNetCore.ResponseCompression;
using System.IO.Compression;
using EFCoreTesting.Areas.Work.Controllers;
using EFCoreTesting.Infrastructure.Mediatr;
using EFCoreTesting.Models.WithParameterForDI;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.HttpsPolicy;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using EFCoreTesting.Models.Account;
using EFCoreTesting.Controllers.After2510;

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

            services.AddDbContext<Context2510>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection2")));
            services.AddScoped<WorkOne2Many>();

            services.AddDbContext<Context1011>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection2")));

            //services.Configure<Uzver>(Configuration.GetSection("TestSection2")); //считал параметры из конфигурационного файла
            services.AddOptions<Uzver>().Bind(Configuration.GetSection("TestSection3")).ValidateDataAnnotations(); //считал параметры из конфигурационного файла + выполнил проверку модели

            //две записи ниже равнозначны, но первую привязку данных невозможно проверить на валидность
             //services.Configure<Work1611cController.MySectionData>(Configuration.GetSection("FirstSection"));
            services.AddOptions<Work1611cController.MySectionData>()
                .Bind(Configuration.GetSection("FirstSection"))
                //.ValidateDataAnnotations()
                .Validate(work =>
                {
                    if (work.Age.Contains("Popovich"))
                    {
                        return false;
                    }
                    return true;
                });
            //конец двух равнозначных записей


            services.Configure<ForTestCongigOptions>(Configuration);
            services.Configure<Uzzer2>(Configuration);
            services.Configure<Uzzer>("Section2", Configuration.GetSection("TestSection2"));
            services.Configure<Uzzer>("Section3", Configuration.GetSection("TestSection3"));
            //одна из техник проверки параметров в файле конфигурации - выполняется в момент получения данных из файла конфига
            services.AddOptions<Uzzer>().Bind(Configuration.GetSection("TestSection3")).ValidateDataAnnotations().Validate(opt =>
            {
                if (opt.User == "Uzvar3")
                {
                    return false;
                }
                return true;
            }, "Значение Uzvar3 не подходит в файле конфига, нужно заменить");
            //вторая техника - пост-проверки именованных параметров ниже
            services.PostConfigure<Uzzer>("Section2", opt =>
            {
                if (opt.User == "Uzvar2")
                {
                    opt.User = "NeSvarilsya";
                }
            });

            services.AddDbContext<IdentyyDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("AspWithIdentityContextConnection")));

            services.AddIdentity<MyIdentityUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            })
            // services.AddDefaultIdentity<IdentityUser>()
            .AddEntityFrameworkStores<IdentyyDbContext>()
            .AddDefaultTokenProviders();


            // Add application services.
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();



            services.AddMvc(opt =>
            {
                opt.CacheProfiles.Add("Caching2", new CacheProfile() { Duration = 30 });
                opt.CacheProfiles.Add("NoCaching2", new CacheProfile()
                {
                    Location = ResponseCacheLocation.None,
                    NoStore = true
                }
                );

                //opt.OutputFormatters.RemoveType<StringOutputFormatter>(); //отключает форматирование стринга по умолчанию в text/plain
            });
            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Testing my personal API",
                    Description = "Here is descriptipn my test API",
                    TermsOfService = new Uri("https://site.com.ua"),
                    Contact = new OpenApiContact
                    {
                        Name = "Alex",
                        Email = "fd@mail.ru",
                        Url = new Uri("https://mysiteUrl.com")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Describe for licenses",
                        Url = new Uri("https://siteApiLicense.com")
                    }
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                opt.IncludeXmlComments(xmlPath);
            });

            services.AddDistributedMemoryCache();
            services.AddDistributedSqlServerCache(options =>
            {
                options.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DistCache;Integrated Security=True;";
                options.SchemaName = "dbo";
                options.TableName = "TestCache";
            });

            services.AddResponseCompression(options =>
            {
                options.Providers.Add<BrotliCompressionProvider>();
                options.Providers.Add<GzipCompressionProvider>();
            });
            services.Configure<GzipCompressionProviderOptions>(options =>
            {
                options.Level = CompressionLevel.Fastest;
            });
            services.Configure<BrotliCompressionProviderOptions>(options =>
            {
                options.Level = CompressionLevel.Fastest;
            });

            //services.AddControllersWithViews(options =>
            //{
            //    options.Conventions.Add(new RouteTokenTransformerConvention(new PreobrazovatelParametrov())); //выполняется преобразование названия имен в пути на основании соглашений
            //});

            services.AddControllers().AddXmlSerializerFormatters(); //подключил xml форматировщик

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
            services.AddSingleton<Work2210Notifier>();
            services.AddScoped<IWork2510Model, Work2510Model>();
            services.AddScoped<IWork2510ModelRepo2, Work2510ModelRepo2>();
            services.AddScoped<Context2510>();
            services.AddScoped<Work2510ModelRepo2>();
            services.AddSingleton<IService3110, Service3110>();
            services.AddSingleton<Cache0211>();
            //services.AddSingleton<IDistributedCache, MemoryDistributedCache>();
            services.AddSingleton<IDistributedCache, SqlServerCache>();
            services.AddSingleton<IService3110, Service3110>();
            services.AddScoped<Model1011>();
            services.AddSingleton<MyCache1011>();
            services.AddScoped<IModel1011, Model1011>();
            services.AddScoped<Service1611>();

            services.AddTransient<IMediator<EventForMediatorConcrete>, ConcreteMediator>();


            services.AddScoped<IDIyes, DIyes>(x =>
            {
                return ActivatorUtilities.CreateInstance<DIyes>(x, parameters: new ForT() { MyProperty = 6 });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyTestApi"));

            app.UseResponseCompression();


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
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute("origin", "origin/{controller}/{action}/{id?}",
                    defaults: new { area = "Origin" },
                    constraints: new { area = "Origin" });


                endpoints.MapControllerRoute("working", "w/{controller}/{action}/{id?}", defaults: new { area = "Work" }, constraints: new { area = "Work" });
                endpoints.MapAreaControllerRoute("firstArea", "Arey", "arr/{controller}/{action}/{id?}");
                endpoints.MapControllerRoute("twoArea", "twoArr/{controller}/{action}/{id?}",
                    defaults: new { Area = "Two" },
                    constraints: new { Area = "Two" });
                endpoints.MapAreaControllerRoute("distri", "Distribute", "cache/{controller}/{action}/{id?}");

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
                endpoints.MapFallbackToPage("/page2810/{paramas?}", "/_Host");
            });
        }
    }
}
