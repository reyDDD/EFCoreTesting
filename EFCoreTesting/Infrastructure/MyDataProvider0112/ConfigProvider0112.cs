using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Infrastructure.MyDataProvider0112
{
    public class ConfigProvider0112 : FileConfigurationProvider
    {
        public ConfigProvider0112(FileConfigurationSource source) : base(source)
        {

        }

        public override void Load(Stream stream)
        {
            var parser = new ParserData0112();
            Data = parser.DataRead(stream);
        }
    }
}
