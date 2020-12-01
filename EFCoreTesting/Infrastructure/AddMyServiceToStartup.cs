using EFCoreTesting.Infrastructure.DIWithParam;
using EFCoreTesting.Infrastructure.Mediator1711;
using EFCoreTesting.Infrastructure.Mediatr;
using EFCoreTesting.Models;
using EFCoreTesting.Models.WithParameterForDI;
using EFCoreTesting.Models.WithParamForDI;
using EFCoreTesting.Pages.After2111;
using EFCoreTesting.Pages.Mediator;
using EFCoreTesting.Services;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.SqlServer;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Infrastructure
{
    public static class AddMyServiceToStartup
    {
        public static void AddMyServiceInStartup(this IServiceCollection services)
        {
            services.AddSingleton<Service2511>();
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
            services.AddScoped<IObbrabotchik<StartClass, EndClass>, Obrabotchik1711>();
            services.AddScoped<IMedi<StartClass>, RealMediator1711>();
            services.AddScoped<IMedi, Medi>();

            services.AddScoped<IDIyes, DIyes>(x =>
            {
                return ActivatorUtilities.CreateInstance<DIyes>(x, parameters: new ForT() { MyProperty = 6 });
            });
            services.AddScoped<ClassForDI1711>(provider => ActivatorUtilities.CreateInstance<ClassForDI1711>(provider, parameters: 44));

            services.AddScoped<IOru, Oru>(services =>
            {
                return ActivatorUtilities.CreateInstance<Oru>(services, parameters:  new object[] { 1, "text" });
            });
        }
    }
}
