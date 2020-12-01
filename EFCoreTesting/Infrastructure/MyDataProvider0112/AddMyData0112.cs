using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Infrastructure.MyDataProvider0112
{
    public static class AddMyData0112
    {
        public static IConfigurationBuilder AddMyFile0112(this IConfigurationBuilder builder, string path, bool reloadOnChange)
        {
            return AddMyFile0112(builder, path, reloadOnChange, null, false);
        }

        public static IConfigurationBuilder AddMyFile0112(this IConfigurationBuilder builder, string path, bool reloadOnChange, IFileProvider provider, bool optional)
        {
            // guard clauses
            if (builder == null) throw new ArgumentNullException(nameof(builder));

            if (string.IsNullOrEmpty(path)) throw new ArgumentException("Адрес файла обязателен", nameof(path));

            // ensure provider is configured
            if (provider == null)
            {
                if (Path.IsPathRooted(path))
                {
                    provider = new PhysicalFileProvider(Path.GetDirectoryName(path));
                    path = Path.GetFileName(path);
                }
            }

            // create the configuration source
            var source = new ConfigSource0112
            {
                FileProvider = provider,
                Path = path,
                Optional = optional,
                ReloadOnChange = reloadOnChange
            };

            // add the source to the builder            
            builder.Add(source);
            return builder;
        }
    }
}
