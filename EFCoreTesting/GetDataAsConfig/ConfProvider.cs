using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.GetDataAsConfig
{
    public class ConfProvider : FileConfigurationProvider
    {
        public ConfProvider(FileConfigSource source) : base(source)
        {
        }
        public override void Load(Stream stream)
        {
            var parser = new ParserDataFromFileTxt();
            Data = parser.Parse(stream);
        }
    }
}
