using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Services
{
    public class ComponentBase : IComponent
    {
        [Parameter]
        public int CountName { get; set; } 

        [Inject]
        protected InjectServices List3 { get; set; }

        public int ReturnCount()
        {
            return CountName;
        }

        public void Attach(RenderHandle renderHandle)
        {
            throw new NotImplementedException();
        }

        public Task SetParametersAsync(ParameterView parameters)
        {
            CountName = List3.ReturnListFriends().Count();
            return Task.CompletedTask;
        }
    }
}
