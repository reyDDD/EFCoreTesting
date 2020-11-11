using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Models
{

    public interface IModel1011
    {
        void AddAddressWithUser(User user);
    }
    public class Model1011 : IModel1011
    {
        private Context context;

        public Model1011(Context context)
        {
            this.context = context;
        }

        //может, эта хуйня и работает, но я способа проверить не нашел. 
        public void AddAddressWithUser(User user)
        {
            var strategy = context.Database.CreateExecutionStrategy();

            context.Entry(user.Address).State = EntityState.Added;
            user.AddressId = 0;
            context.Users.Add(user);

            strategy.ExecuteInTransaction(context,
                operation: cont =>
                {
                    cont.SaveChanges(acceptAllChangesOnSuccess: false);
                },
                verifySucceeded: contex => true);
            // verifySucceeded: contex => contex.Addresses.AsNoTracking().Any(a => a.Id == user.Address.Id) && contex.Users.AsNoTracking().Any(u => u.Id == 11111));
            context.ChangeTracker.AcceptAllChanges();
        }
    }
}
