using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Models.After3011
{
    public class Model3011
    {
        public IEnumerable<string> GetList()
        {
            IEnumerable<string> res;
            try
            {
                res = LocalFunction();
            }
            catch(Exception ex)
            {
                res = new List<string>();
                throw new Exception("работает");
            }
            return res;

            IEnumerable<string> LocalFunction()
            {
                for (int i = 0; i < 5; i++)
                {
                    if (i == 4)
                    {
                        throw new Exception("а не тут то было");
                    }
                    yield return $"{i}";
                }
            }
        }
    }
}
