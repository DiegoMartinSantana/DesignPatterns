using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronesDiseño.State
{
    public class NotDebtorState : IState
    {
        public void Action(CustomerContext context, decimal amount)
        {
            if (amount <= context.Residue)
            {
                context.Discount(amount);
                Console.WriteLine($"Gasta {amount} y le queda {context.Residue} de saldo ");
                if (context.Residue <= 0) // si su saldo es  
                {
                    context.SetState(new DebtorState()); //cambia estado a deudor
                }

            }
            else
            {
                Console.WriteLine($"No tiene suficiente saldo para gastar {amount} le queda {context.Residue} de saldo ");
            }
        }
    }
}
