using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    public class ObjectOnly
    {


        private string _name;

        private static ObjectOnly _instance = null; 

        private static object _lock = new object(); //objeto para sincronizar

        public  static ObjectOnly InstancewithName(string name) //metodo que deuvleve la instancia
        {
            lock (_lock) { //bloqueo el objeto
                if (_instance == null)
                {

                    _instance = new ObjectOnly(name); // como no puedo crear , aca dentro utilizo el constructor!

                    return _instance;
                    //hace algo mas con el nombre..
                } }
                return _instance;
        }
        private  ObjectOnly(string name) // constructor privado  
        {
            _name = name;   
        }
        public void Save(String Message)
        {
            File.AppendAllText(_name, Message + Environment.NewLine); //metodo para guardar cada vez que hace un LOG
        }

        /* public ObjectOnly Instance
         {
             get
             {
                 return _instance; //retorna la instancia
             }
         }*/






    }
}
