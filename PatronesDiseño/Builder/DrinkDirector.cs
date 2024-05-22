using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronesDiseño.Builder
{
    public class DrinkDirector
    {
        private IBuilder _builder; // director maneja distintos tipos , por eso IBuilder

        public DrinkDirector(IBuilder builder)
        {
            _builder = builder;
        }

        public void MakeDrink()
        {
            _builder.Reset();
            _builder.addIngredientes("ingrediente 1");
            _builder.addIngredientes("ingrediente 2");
            _builder.addIngredientes("ingrediente 3");
            _builder.SetAzucar(2);
            _builder.SetAgua(1);
            _builder.SetLimon(1);
            _builder.SetHielo(3);
            _builder.SetAlcohol(10);
            _builder.Mix();
            _builder.Reposo();
        }

    }
}
