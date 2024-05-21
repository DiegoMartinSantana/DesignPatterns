using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronesDiseño.Strategy
{
    internal class BikeStrategy : IStrategy
    {
        public void Move()
        {
            Console.WriteLine("Bike is moving");
        }
    }
}
