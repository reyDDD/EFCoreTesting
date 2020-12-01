using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Infrastructure.MyDataProvider0112
{
    public class ParserData0112
    {
        IDictionary<string, string> dictionary = new Dictionary<string, string>();


        public IDictionary<string, string> DataRead(Stream stream)
        {
            using var reader = new StreamReader(stream);
            while (reader.Peek() != -1)
            {
                string line = reader.ReadLine();
                (string key, string value) v = Sub(line);
                dictionary.Add(v.key, v.value);
            }
            return dictionary;
        }

       public (string key, string value) Sub(string line)
        {
            var key = line.Substring(0, line.IndexOf(':'));
            var value = line.Substring(line.IndexOf(':')+1);
            return (key, value);
        }
    }
}
