using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Earn
{
    public class EarnLocal : IEarn
    {

        public EarnLocal(decimal percentage)
        {
            _percentage = percentage;
        }

        private decimal _percentage; 
        public decimal Earn(decimal amount)
        {
            return amount * _percentage;
        }
    }
}

