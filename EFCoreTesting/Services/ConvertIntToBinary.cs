using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Services
{
    public class ConvertIntToBinary
    {

        public BitArray Convert(int x)
        {
            int[] num = new int[1];
            num[0] = x;
            BitArray res = new BitArray(num);
            return res;
        }

        public int SummOne(BitArray array)
        {
            int count = 0;
            int work = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i])
                {
                    work += 1;
                }
                else
                {
                    if(work>count)
                    {
                        count = work;
                    }
                    work = 0;
                }
            }
            return count;
        }
    }
}
