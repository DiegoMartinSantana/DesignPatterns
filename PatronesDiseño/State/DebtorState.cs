using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronesDiseño.State
{
    public class DebtorState : IState
    {
        public void Action(CustomerContext context, decimal amount)
        {
            Console.WriteLine("no puede comprar, esta en estado deudor");
        }
    }
}
