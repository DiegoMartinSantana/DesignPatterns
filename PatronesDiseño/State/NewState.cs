using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronesDiseño.State
{
    public class NewState : IState
    {
        public void Action(CustomerContext context, decimal amount)
        {
            Console.WriteLine($"Agrego dinero a su saldo {amount}");
            context.Residue = amount;
            context.SetState(new NotDebtorState());
        }
    }
}
