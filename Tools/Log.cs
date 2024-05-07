using System.Runtime.InteropServices;

namespace Tools
{
    public class Log
    {
        private string _path;

        private static Log _instance = null; //asigno null para  recibirlo

        private Log(string path)
        {

            _path = path;
        }


        public static Log CreateLog(string path) {

            //SI ES NULL ACCEDO , SINO RETORNO LA EXISTENTE
            if (_instance == null) {
                _instance = new Log(path);
            }
            return _instance;

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
