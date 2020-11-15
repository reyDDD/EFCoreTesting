using EFCoreTesting.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace XUnitTestProject1.After2610
{
    public class Model1511Tests
    {
        private DbContextOptions<Context> options;
        public Model1511Tests()
        {
            options = ConnOptionsForModel1511.GetOptions<Context>();
        }
        [Fact]
        public void TestEachOther()
        {
            using (var context = new Context(options))
            {
                ConnOptionsForModel1511.AddNewUserToInMemoryDataBase(context);
                var model = new Model1511(context);
                var res1 = model.GetUser1(10);
                var res2 = model.GetUser2(10);
                Assert.Equal(res1, res2);
            }
        }

        [Fact]
        public void ReturnSingleUser()
        {
            using (var context = new Context(options))
            {
                ConnOptionsForModel1511.AddNewUserToInMemoryDataBase(context);
                var model = new Model1511(context);
                var res = model.GetSingleUser(22);
                Assert.True(res != null);
            }
        }

        [Fact]
        public void NotSingleUser_ReturnException()
        {
            using (var context = new Context(options))
            {
                ConnOptionsForModel1511.AddNewUserToInMemoryDataBase(context);
                var model = new Model1511(context);
                
                Exception ex = Assert.Throws<InvalidOperationException>(() => model.GetSingleUser(5));
                    Assert.Equal("Sequence contains more than one element", ex.Message); 
            }
        }

        [Fact]
        public void SingleUser_ReturnMoreThenOne()
        {
            using (var context = new Context(options))
            {
                ConnOptionsForModel1511.AddNewUserToInMemoryDataBase(context);
                var model = new Model1511(context);
                var result = model.GetSingleUser(500);
                Assert.Null(result);
            }
        }

        [Fact]
        public void ListUser_SearchTerm()
        {
            using (var context = new Context(options))
            {
                ConnOptionsForModel1511.AddNewUserToInMemoryDataBase(context);
                var model = new Model1511(context);
                var result = model.GetUserSearchLastNameText("1511");
                Assert.True(result.Count == 2);
            }
        }

        [Fact]
        public void ListUser_StartsWithTerm()
        {
            using (var context = new Context(options))
            {
                ConnOptionsForModel1511.AddNewUserToInMemoryDataBase(context);
                var model = new Model1511(context);
                var result = model.GetUserStartsWithLastNameText("LastName");
                Assert.True(result.Count == 2);
                Assert.True(result[0].LastName == "LastName1511");
            }
        }

        [Fact]
        public void My()
        {
            var count = Convert.ToInt32(Console.ReadLine());
            Dictionary<string, string> dict = new Dictionary<string, string>();
            for (int i = 0; i < count; i++)
            {
                string namePhone = Console.ReadLine();
                var res = namePhone.Split(' ');
                dict.Add(res[0], res[1]);
            }

            for (int i = 0; i < count; i++)
            {
                var ish = Console.ReadLine();
                string res;
                if (dict.TryGetValue(ish, out res))
                {
                    Console.WriteLine($"{res}={dict[res]}");
                }
                else
                {
                    Console.WriteLine($"Not found");
                }
            }

        }
    }
}
