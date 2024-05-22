using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronesDiseño.Builder
{
    public class DrinkConcreteBuilder : IBuilder
    {
        //crea aca, por si no  obligo a los demas a tenerlo
        private Drink _drink;
        public DrinkConcreteBuilder()
        {
            Reset();
        }
        

        public void addIngredientes(string ingredient)
        {
            if (_drink.Ingredientes == null)
                _drink.Ingredientes = new List<string>();

            _drink.Ingredientes.Add(ingredient);
        }

        public void Mix()
        {
            Console.WriteLine("Mezclando los ingredientes");
            string show = $"Agua = {_drink.Agua} ,Sugar = {_drink.Azucar}, Alcohol = {_drink.Alcohol} , Hielo {_drink.Hielo} , Limon = {_drink.Limon} ";
            show += _drink.Ingredientes.Aggregate((i, j) => i + " ;" + j);

            Console.WriteLine(show);

        }

        public void Reposo()
        {
            Thread.Sleep(1000);  // suspende el hilo  
            Console.WriteLine("Termino el Reposo. Puede beber");
        }

        public void Reset()
        {
            _drink = new Drink();
        }

        public void SetAgua(decimal water)
        {
            _drink.Agua = water;
        }

        public void SetAlcohol(decimal Alcohol)
        {
            _drink.Alcohol = Alcohol;
        }

        public void SetAzucar(decimal sugar)
        {
           _drink.Azucar = sugar;
        }

        public void SetHielo(decimal ice)
        {
            _drink.Hielo = ice;
        }

        public void SetLimon(decimal lemon)
        {
            _drink.Limon = lemon;
        }
    }
}
