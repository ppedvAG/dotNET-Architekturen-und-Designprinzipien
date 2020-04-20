using System;
using System.Threading.Tasks;

namespace HalloSingelton
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Singelton!");

            //var logger = new Logger();

            for (int i = 0; i < 10; i++)
            {
                Task.Run(() =>
                {
                    Logger.Instance.Log($"{i}: Logger Info TEST");
                    Logger.Instance.Log($"{i}: Logger Warnung TEST", LogLevel.Warn);
                    Logger.Instance.Log($"{i}: Logger Fehler TEST", LogLevel.Error);
                });
            }



            Console.WriteLine("Ende");
            Console.ReadLine();
        }
    }
}
