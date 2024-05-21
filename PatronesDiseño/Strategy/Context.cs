using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronesDiseño.Strategy
{
    public class Context
    {
        private IStrategy _strategy;
        //acceso a la _strategy y le asigno el value . para manejar su comportamiento dinamicamente
        public IStrategy Strategy
        {
            set
            { _strategy = value; }
        }
        public Context(IStrategy strategy)
        {
            _strategy = strategy;

        }
        public void Move()
        {
            _strategy.Move(); //llamado al comportamiento de la estrategia
        }

    }
}
