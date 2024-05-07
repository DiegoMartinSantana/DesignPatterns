using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronesDiseño.Factory_Method
{

    //CREADOR DE FABRICAS   DE VENTAS DE TIPO WEB, TELEFONICA, FISICA Y CATALOGO CADA UNA CON SUS PROPS Y METODOS RESPECTIVOS


    //Creador
    public abstract class FactoryCreator  //no puedo crear clases abstracts pero si sus hijos 
    {

        public abstract ISale Vender(); 
        // METOOD QUE VA A OBLIGAR A DEVOLVER LA VENTA DE TIPO ISALE
        

    }


    //FABRICA CONCRETA hereda de la fabrica creadora y crean objs de distintos tipos 
    //cada uno maneja sus props y constructor
    public class WebSaleFactory : FactoryCreator
    { 
        private double _discount;
        public WebSaleFactory(double discount) { 
        _discount = discount;   
        }
        public override ISale Vender()
        {
            return new WebSale(_discount); // prop y la crea aca retornando la creacion aca

        }
    }

    public class PhoneSaleFactory : FactoryCreator
    {
            private double _surcharge; 
        public PhoneSaleFactory(double  surcharge)
        {
            _surcharge = surcharge;
        }
        public override ISale Vender()
        {
            return new PhoneSale(_surcharge);
        }

    }

    public class PhysicalSaleFactory : FactoryCreator
    {
        private double _surcharge;
        private double _discount;
        public PhysicalSaleFactory(double surcharge, double discount)
        {
            _surcharge = surcharge;
            _discount = discount;
        }
        public override ISale Vender()
        {
            return new PhysicalSale(_surcharge, _discount);
        }

    }

    public class CatalogSaleFactory : FactoryCreator
    {
        private int _catalogNumber;
        public CatalogSaleFactory(int catalogNumber)
        {
            _catalogNumber = catalogNumber;
        }
        public override ISale Vender()
        {
            return new CatalogSale(_catalogNumber);
        }

    }   



    //Interfaz a utilizar. TODAS LAS VENTAS COMPARTEN METODO VENTA Y UN NOMBRE
    public interface ISale
    {
        public void  Vender(double total);

    }


    //TODAS SE COMPORTAN DE MANERA DISTINTA. PERO A LA HORA DE VENDER TODAS TIENEN QUE TENER UN METODO VENDER -     
    //producto concreto
    public class CatalogSale : ISale
    {
        private int _catalogNumber;
        public CatalogSale(int catalogNumber)
        {
            _catalogNumber = catalogNumber;
        }
        public void Vender(double total)
        {
            Console.WriteLine($"Venta por catalogo. Nro de catalogo : {_catalogNumber} , queda un total de : {total}");
        }
    }


    public class PhysicalSale : ISale
    {
        public PhysicalSale(double surcharge, double discount)
        {
            _surcharge = surcharge;
            _discount = discount;
        }   

        private double _surcharge;
        private double _discount;

        public void Vender(double total)
        {
            double totalfinal = total + (total * _surcharge);
            totalfinal= totalfinal - (totalfinal * _discount);

            Console.WriteLine($"Venta fisica ,recargo del : {_surcharge} y descuento del : {_discount} queda un total de : {totalfinal}");
        }
    }
    public class  WebSale : ISale
    {

        public WebSale(double discount)
        {
            _discount = discount;
        }

        private double _discount;
        public void Vender(double total)
        {
            double totalfinal = total - (total* _discount);
            Console.WriteLine($"Venta por web  , descuento del : {_discount} ,queda un total de : {totalfinal}" );
        }

    }


    public class PhoneSale : ISale
    {
        public PhoneSale(double surcharge)
        {
            _surcharge = surcharge;
        }   
        private double _surcharge;
        public void Vender(double total)
        {
            double totalfinal = total +(total * _surcharge);
            Console.WriteLine($"Venta por telefono , recargo del {_surcharge}, total final de : {totalfinal} ");
        }
    }


}
