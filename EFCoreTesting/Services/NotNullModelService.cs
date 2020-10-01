using EFCoreTesting.Models;
using Microsoft.EntityFrameworkCore;
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


        public NotNullModel ReturnNotNullModelWithHose(NotNullModel street)
        {
            var res2 = context.NotNullModels.Where(i => i.Id == street.Id).Include(i => i.House).First();
            return res2;
        }



        public NotNullModel AddHouseToStreet(NotNullModel street, bool isTrue)
        {
            NotNullModel res = default;

            if (isTrue)
            {
                res = context.NotNullModels.Add(street).Entity;
            }
            else
            {
                var start = context.NotNullModels.Where(i => i.Street == street.Street).FirstOrDefault();
                start.House = new List<House>();
                start.House = street.House;
                res = context.NotNullModels.Update(start).Entity;
            }
            context.SaveChanges();
            //var res2 = context.NotNullModels.Where(i => i.Id == res.Id).Include(i => i.House).First();
            return res;
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
