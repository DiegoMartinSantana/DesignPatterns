using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Earn
{
    public class EarnForeignFactory : EarnFactory
    {
        private decimal _percentage;
        private decimal _extra;

        public EarnForeignFactory(decimal percentage, decimal extra)
        {
            _percentage = percentage;
            _extra = extra;
        }

        public override IEarn Earn() //metodo devolver Iearn 
        {
           return new EarnForeign(_percentage, _extra); 
        }
    }
}
