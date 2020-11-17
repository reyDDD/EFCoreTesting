using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Infrastructure.MyDataProvidee1711
{
    public class ParseData
    {
        IDictionary<string, string> dict;

        public ParseData()
        {
            dict = new Dictionary<string, string>();
        }

        public IDictionary<string, string> Parse(Stream stream)
        {
            dict.Clear();

            using (var reader = new StreamReader(stream))
            {
                string line = default;
                while ((line = reader.ReadLine()) != null)
                {
                    (string key, string val) keyValPair = default;
                    try
                    {
                        keyValPair = Sub(line);
                        dict.Add(keyValPair.key, keyValPair.val);
                    }
                    catch (ArgumentNullException)
                    { 
                    }
                } 
            }

            return dict;
        }

        public (string key, string val) Sub(string line)
        {
            int indSovpal = line.IndexOf('^');
            if (indSovpal == -1)
            {
                throw new ArgumentNullException();
            }
            string key = line.Substring(0, indSovpal);
            string val = line.Substring(indSovpal + 1);
            return (key, val);
        }
    }
}
