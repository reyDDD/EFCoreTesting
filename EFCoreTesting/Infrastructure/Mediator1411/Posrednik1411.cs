using EFCoreTesting.Areas.Two.Controllers;
using EFCoreTesting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Infrastructure.Mediator1411
{
    public class Posrednik1411 : IMediatorr<Uzver, string>
    {
        private Work2510ModelRepo2 repo;

        public Posrednik1411(Work2510ModelRepo2 repo)
        {
            this.repo = repo;
        }
        public async Task<string> Operation(Uzver zver)
        {
            await repo.AddUserAsync(new User { Age = Convert.ToInt32( zver.Age), LastName = zver.User });
            return zver.Age + zver.User;
        }
    }
}
