using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Models
{
    public class Model1511
    {
        private Context context;
        public Model1511(Context context)
        {
            this.context = context;
        }

        public User GetUser1(int age)
        {
            User user1 = context.Users.FirstOrDefault(u => u.Age >= age);
            return user1;
        }
        public User GetUser2(int age)
        {
            User user1 = context.Users.Where(u => u.Age >= age).FirstOrDefault();
            return user1;
        }

        public User GetSingleUser(int age)
        {
           return context.Users.SingleOrDefault(u => u.Age >= age);
        }
    }
}
