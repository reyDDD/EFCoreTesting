using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Services
{
    public class ComponentBasese : ComponentBase
    {
        [Parameter]
        public int CountName { get; set; } 

        [Inject]
        protected InjectServices List3 { get; set; }

        public int ReturnCount()
        {
            return CountName;
        }

        protected override void OnParametersSet()
        {
            CountName = List3.ReturnListFriends().Count();
        }
 

    }
}
