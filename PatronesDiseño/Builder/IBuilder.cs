using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronesDiseño.Builder
{
    public interface  IBuilder
    {
        public void Reset();
        public void SetAzucar(decimal sugar);
        public void SetAgua(decimal water);
        public void SetAlcohol(decimal Alcohol);
        public void SetHielo(decimal ice);
        public void SetLimon(decimal lemon);
        public void addIngredientes(string ingredient);
        public void Mix();
        public void Reposo();
    }
}
