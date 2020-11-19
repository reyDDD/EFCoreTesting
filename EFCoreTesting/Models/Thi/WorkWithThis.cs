﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Models.Thi
{
    public class WorkWithThis
    {
        public string Work()
        {
            ThisBase bases = new ThisBase();
            var res = bases.GetStringFromBase().SetStringFrombase("от родителя для родителя ").AddFromChild("от ребенка для родителя").Template;
            return res;
        }

        public string Work2()
        {
            ThisBase bases = new ThisBase();
            var res = bases.GetStringFromBase().SetNullFrombase()?.AddFromChild("от ребенка для родителя").Template;
            return res;
        }

        public string NameOfWork(string paramName)
        {
            return $"Переменная с именем {nameof(paramName)} содержит значение: {paramName}";
        }


        public IEnumerable<char> AlphabetSubset3(char start, char end)
        {
            if (start < 'a' || start > 'z')
                throw new ArgumentOutOfRangeException(paramName: nameof(start), message: "start must be a letter");
            if (end < 'a' || end > 'z')
                throw new ArgumentOutOfRangeException(paramName: nameof(end), message: "end must be a letter");

            if (end <= start)
                throw new ArgumentException($"{nameof(end)} must be greater than {nameof(start)}");

            IEnumerable<char> result = alphabetSubsetImplementation();
            return result;

            IEnumerable<char> alphabetSubsetImplementation()
            {
                for (var c = start; c < end; c++)
                    yield return c;
            }
        }

        public IEnumerable<int> MylocalFunctionsTest(int number)
        {
            if (number <= 0) throw new ArgumentException();
            else
            {
                return Worka();
                IEnumerable<int> Worka()
                {
                    for (int i = 0; i < number; i++)
                    {
                        yield return i;
                    }
                }
            }
        }
    }
}
