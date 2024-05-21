using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronesDiseño.Strategy
{
    internal class CarStrategy : IStrategy
    {
        public void Move()
        {
            Console.WriteLine("Car is moving");

        }
    }
}
