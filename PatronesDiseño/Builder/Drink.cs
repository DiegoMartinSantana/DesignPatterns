using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronesDiseño.Builder
{
    public class Drink
    {
        public List<string> Ingredientes { get; set; }
        public decimal Limon { get; set; }  
        public decimal Azucar { get; set; }
        public decimal Agua { get; set; }
        public decimal Hielo { get; set; }
        public decimal Alcohol { get; set; }

    }
}
