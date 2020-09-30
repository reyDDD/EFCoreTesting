using EFCoreTesting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Services
{
    public class NotNullModelService
    {
        private Context context;

        public NotNullModelService(Context context)
        {
            this.context = context;
        }

        public NotNullModel CreateStreet()
        {
            var street = new NotNullModel()
            {
                Street = "KHmelnitskogo"
            };
            return street;
        }

        public House ReturnHouseWithoutStreet()
        {
            var res = context.Houses.FirstOrDefault();
            return res;
        }

        public House Hhouse()
        {
            var res = new House { Home = "первый слева" };
            return res;
        }
    }
}
