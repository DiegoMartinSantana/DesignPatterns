using PatronesDiseño.Factory_Method;
using PatronesDiseño.Singleton;
using System.Runtime.InteropServices;

namespace PatronesDiseño
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region SINGLETON
            var singleton = Singleton.Singleton.Instance;

            var log = Singleton.Log.Instance;
            log.Save("Hola Mundo");
            Console.WriteLine("Hello, World!");
            #endregion


            #region FACTORY METHOD
            //CREO LAS FABRICAS CONCRETAS

            var WebFactory = new WebSaleFactory(0.15); //discount 15%
            var PhoneFactory = new PhoneSaleFactory(0.30);  //recargo del 30%
            var CatalogFactory = new CatalogSaleFactory(199); // venta realizada x catalogo 199
            var PhysicalFactory = new PhysicalSaleFactory(0.10, 0.5); //recargo del 10% y descuento del 5%

            //asigno al tipo ISALE  
            ISale saleWeb = WebFactory.Vender(); // crea una venta por web
            saleWeb.Vender(1000); // le paso el monto de la venta vendida

            ISale salePhone = PhoneFactory.Vender();
            salePhone.Vender(500);

            ISale saleCatalog = CatalogFactory.Vender();    
            saleCatalog.Vender(300);

            ISale salePhysical = PhysicalFactory.Vender();
            salePhysical.Vender(500000);
            #endregion

        }
    }
}
