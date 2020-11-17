using EFCoreTesting.Infrastructure.MyDataProvidee1711;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EFCoreTesting.Infrastructure.MyDataProvidee1711
{
    public class InformationConfigProvider : FileConfigurationProvider
    {
        public InformationConfigProvider(FileConfigurationSource source) : base(source)
        {

        }
        public override void Load(Stream stream)
        {
            var parser = new ParseData();
            Data = parser.Parse(stream);
        }
    }
}
