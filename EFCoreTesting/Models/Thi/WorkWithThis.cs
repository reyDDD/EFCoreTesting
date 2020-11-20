using EFCoreTesting.Areas.Two.Controllers;
using EFCoreTesting.Areas.Work.Controllers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Models.Thi
{
    public class WorkWithThis
    {
        public readonly string MyProperty = "ff";
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

        public object WorkWithSwitch()
        {
            List<object> vs = new List<object>();
            vs.Add(new User { AddressId = 3, Age = 44, FirstName = "dsd", LastName = "df", IsMale = true, BirthDay = DateTime.Now });
            vs.Add(null);
            vs.Add(3);
            foreach (var item in vs)
            {
                switch (item)
                {
                    case int n when n > 0:
                        Debug.WriteLine("dsd");
                        break;
                    case null:
                        Debug.WriteLine("nulll");
                        break;
                    case User ussr:
                        Debug.WriteLine(ussr.FirstName);
                        break;
                    case int n when n == 0:
                        return new Uzver();
                }
            }
            return null;
        }

        public User YetSwich(object user) => user switch
            {
                User => new User { Address = ((User)user).Address },
                string => new User { Address = ((User)user).Address },
                int => new User { Address = ((User)user).Address },
                _ => throw new NotImplementedException()
            };

        public Uzzer ShablonSwich(User user) {

            return user switch
            {
                { LastName: "Иванов" } => new Uzzer { Name = "Namasa" }, //не работает для простых типов типа стринг, актуально только для сложных типов
                _ => throw new NotImplementedException()
            };
        }

        public Uzzer ShablonSwich(string user) //работает с кортежами с любым количество элементов
        {

            return (user) switch
            {
                ("Иванов") => new Uzzer { Name = user },
                _ => throw new NotImplementedException()
            };
        }

        public Uzzer ShablonPositionniy(Uzzer usera)
        {
            return usera switch
            {
                var (name, user, agesec) when name == "Ivanov" && user == "Petrovach" => new Uzzer { Name = user },
                _ => throw new NotImplementedException()
            };
        }
    }
 }
