using System;
using System.Collections.Generic;
using static ServerAspNetCoreLinux.ServerCore.ServerLogger.ServerLoggerConst;

namespace ServerAspNetCoreLinux.ServerCore.ServerLogger
{
    public static class ServerLoggerModel
    {
        private static List<string> _logs = new List<string>();

        public static void Log(TypeLog type, string message)
        {
            var header = string.Empty;
            var color = ConsoleColor.Black;
            var dateTime = DateTime.Now;

            switch (type)
            
            {
                case TypeLog.Debug:
                    color = ConsoleColor.White;
                    header = Debug;
                    break;
                case TypeLog.Error:
                    color = ConsoleColor.Red;
                    header = Error;
                    break;
                case TypeLog.Trace:
                    color = ConsoleColor.Blue;
                    header = Trace;
                    break;
                case TypeLog.Warn:
                    color = ConsoleColor.Yellow;
                    header = Warn;
                    break;
                case TypeLog.Fatal:
                    color = ConsoleColor.DarkRed;
                    header = Fatal;
                    break;
                case TypeLog.Info:
                    color = ConsoleColor.Green;
                    header = Info;
                    break;
                case TypeLog.UserMessage:
                    color = ConsoleColor.Cyan;
                    header = Info;
                    break;
            }

            Console.ForegroundColor = color;
            Console.Write($"[{header}] ");
            Console.ResetColor();
            Console.Write($"{dateTime.ToLongTimeString()} - ");
            Console.Write($"{message}");
            Console.WriteLine();
        }
    }
}