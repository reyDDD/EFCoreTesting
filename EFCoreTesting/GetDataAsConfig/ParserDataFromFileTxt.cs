using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.GetDataAsConfig
{
    public class ParserDataFromFileTxt
    {
        private IDictionary<string, string> dict;
        public ParserDataFromFileTxt()
        {
            dict = new Dictionary<string, string>();
        }

        public IDictionary<string, string> Parse (Stream stream)
        {
            using(var reader = new StreamReader(stream))
            {
                var line = reader.ReadLine();
                if (line !=null)
                {
                    var res = line.Split(';');
                    dict.Add(res[0], res[1]);
                }
            }
            return dict;
        }
    }
}
