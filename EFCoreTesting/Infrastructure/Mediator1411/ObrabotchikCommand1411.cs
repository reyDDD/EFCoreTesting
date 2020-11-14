using EFCoreTesting.Areas.Two.Controllers;
using EFCoreTesting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Infrastructure.Mediator1411
{
    public class ObrabotchikCommand1411 : IObrabotchikCommand<Uzver, string>
    {
        public IMediatorr<Uzver, string> Posrednik { get; }
        public ObrabotchikCommand1411(Posrednik1411 posrednik)
        {
            this.Posrednik = posrednik;
        }
        public async Task<string> Handler(Uzver parameter)
        {
            return await Posrednik.Operation(parameter);
        }
    }
}
