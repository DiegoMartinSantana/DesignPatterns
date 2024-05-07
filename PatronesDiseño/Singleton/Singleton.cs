using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PatronesDiseño.Singleton
{
    public class Singleton
    {


        private readonly static Singleton _instance = new Singleton();  
        private Singleton() { 
            //constructor privado para no crear  mas OBJS DE ESTA CLASE        
        }
        //CREO SU GET
        public static Singleton Instance
        {
            get {
                return _instance;
            }

           
        }
        
    }
}
