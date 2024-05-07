using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Earn
{
    public class EarnForeign : IEarn
    {
        private decimal _percentage;
        private decimal _extra;
        public EarnForeign(decimal percentage, decimal extra)
        {
            _percentage = percentage;
            _extra = extra;
        }

        public decimal Earn(decimal amount)
        {

            return (amount * _percentage) + _extra;
        }
    }
}
