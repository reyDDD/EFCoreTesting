using EFCoreTesting.Areas.Two.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Infrastructure.Mediator1411
{
   public interface IMediatorr<VhodnjyArgument, VozvrashaemiyType>
    {
        Task<VozvrashaemiyType> Operation(VhodnjyArgument argument);
    }
}
