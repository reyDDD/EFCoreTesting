using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using EFCoreTesting.GetDataAsConfig;
using EFCoreTesting.Infrastructure.MyDataProvidee1711;

namespace EFCoreTesting
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.AddJsonFile("forTest2811.json", optional: false, reloadOnChange: true);
                    config.AddJsonFile("forTest2411.json", optional: false, reloadOnChange: true);
                    config.AddJsonFile("my1611.json", optional: false, reloadOnChange: true);
                    config.AddJsonFile("myTestParam.json", optional: false, reloadOnChange: true);
                    config.AddJsonFile("two.json", optional: false, reloadOnChange: true); //подключаю еще один файл конфигурации, содержимое которого станет доступным из IConfiguration
                    config.AddMyFile1311("GetDataAsConfig\\dataFromConfig.txt", reloadOnChange: true);
                    config.AddMyFile1711("Infrastructure\\MyDataProvidee1711\\data1711.txt", reloadOnChange: true);
                })

                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>()
                    .UseSetting(WebHostDefaults.DetailedErrorsKey, "true");
                });
    }
}
