using Patrones_Diseño.Singleton;

namespace Patrones_Diseño
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            var singleton = Singleton.Singleton.Instance;

            var log = Singleton.Log.Instance;
            log.Save("Hola Mundo");
        }
    }
}
