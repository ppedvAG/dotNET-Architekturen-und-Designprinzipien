using System;

namespace HalloSingelton
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Singelton!");

            //var logger = new Logger();
            

            Logger.Instance.Log("Logger Info TEST");
            Logger.Instance.Log("Logger Warnung TEST", LogLevel.Warn);
            Logger.Instance.Log("Logger Fehler TEST", LogLevel.Error);



            Console.WriteLine("Ende");
            Console.ReadLine();
        }
    }
}
