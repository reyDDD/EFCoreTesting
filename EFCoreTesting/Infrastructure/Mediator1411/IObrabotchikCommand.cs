using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Infrastructure.Mediator1411
{
    public interface IObrabotchikCommand<VhodnjyArgument, VozvrachaemoeUvedomleniye>
    {
        IMediatorr<VhodnjyArgument, VozvrachaemoeUvedomleniye> Posrednik { get; }
        Task<VozvrachaemoeUvedomleniye> Handler(VhodnjyArgument vhodnjyArgument);
    }
}
