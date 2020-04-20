using System;
using System.Collections.Generic;
using System.Text;

namespace HalloSingelton
{
    public class Logger
    {

        private static Logger instance = null;
        public static Logger Instance
        {
            get {
                if (instance == null)
                    instance = new Logger();

                return instance;
            }
        }


        private Logger()
        {
            Log("Neuer Logger gestartet");
        }

        public void Log(string txt, LogLevel level = LogLevel.Info)
        {
            var oldCol = Console.ForegroundColor;

            Console.ForegroundColor = level switch
            {
                LogLevel.Error => ConsoleColor.Red,
                LogLevel.Warn => ConsoleColor.DarkYellow,
                _ => ConsoleColor.Green,
            };

            Console.WriteLine($"[{DateTime.Now}] {txt}");
            Console.ForegroundColor = oldCol;
        }
    }

    public enum LogLevel
    {
        Info,
        Warn,
        Error
    }
}
