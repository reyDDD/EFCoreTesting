using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Models
{
    public class Work2510ModelRepo2
    {
        private Context2510 context2510;
        public Work2510ModelRepo2(Context2510 context2510)
        {
            this.context2510 = context2510;
        }

        public async Task<User> GetUser(long id)
        {
            return await context2510.Users.Include(m => m.Address).Where(m => m.Id == id).FirstOrDefaultAsync();
        }
    }
}
