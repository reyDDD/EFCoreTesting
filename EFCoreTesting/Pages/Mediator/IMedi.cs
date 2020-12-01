using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreTesting.Pages.Mediator
{
    public interface IMedi
    {
        public Colleque Colleque1 { get; set; }
        public Colleque Colleque2 { get; set; }
        public void Send(string msg, IColleque colleque);
    }


    public interface IColleque
    {
        public string MyProperty { get; set; }
        public void Send(string msg);
        public string Notify(string msg);
    }


    public class Medi : IMedi
    {
        public Colleque Colleque1 { get; set; }
        public Colleque Colleque2 { get; set; }

        public void Send(string msg, IColleque colleque)
        {
            if (Colleque1 == colleque)
            {
                Colleque2.Notify(msg);
            }
            else
            {
                Colleque1.Notify(msg);
            }
        }
    }

    public class Colleque : IColleque
    {
        public string MyProperty { get; set; }
        private IMedi _mediator;
        public Colleque(IMedi mediator) => _mediator = mediator;
        public string Notify(string msg) => MyProperty = msg;

        public void Send(string msg) => _mediator.Send(msg, this);
    }
}
