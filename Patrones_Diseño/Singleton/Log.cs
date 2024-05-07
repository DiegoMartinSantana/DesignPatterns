using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patrones_Diseño.Singleton
{
    public class Log
    {
        private string _path = "log.txt";

        private readonly static Log _instance = new Log();

        private Log()
        {
            //constructor private
        }

        public static Log Instance // prop para acceder a la instancia
        {
            get
            {
                return _instance;
            }
        }

        public void Save(String Message)
        {
            File.AppendAllText(_path, Message + Environment.NewLine); ;
        }

    }
}
