using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Earn
{
    public class EarnLocalFactory: EarnFactory
    {
        private decimal _percentage;

        public EarnLocalFactory(decimal percentage)
        { 
            _percentage = percentage;
        }

        public override IEarn Earn()
        {
            return new EarnLocal(_percentage);  
        }
    }
}
