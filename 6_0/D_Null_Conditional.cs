using System;
using System.Collections.Generic;
using System.IO;
using static System.Console;
using static System.Environment;

namespace _6_0
{
    public class Null_Conditional
    {
        static void Main()
        {
            var planet1 = new Planet();
            Planet planet2 = null;

            var planet1Name = planet1?.Name;
            var planet2Name = planet2?.Name;
            var totalMales = planet1?.TotalPopulation?.Males;

            //Null coalescing to assign default values
            totalMales = planet1?.TotalPopulation?.Males ?? 0L;

            //Conditional invocation of methods

            Logger.WriteMessage += LogToConsole;
            Logger.WriteMessage += LogToFile;

            Logger.WriteMessage("I am failing just like that!");
            Logger.WriteMessage -= LogToConsole;
            Logger.WriteMessage("I am failing just like that!");
            Logger.WriteMessage -= LogToConsole;
            Logger.WriteMessage("I am failing just like that!");
        }

        public static void LogToConsole(string message)
        {
            Error.WriteLine(message);
        }

        public static void LogToFile(string msg)
        {
            string logPath = GetFolderPath(SpecialFolder.MyDocuments);
            using (var log = File.AppendText(logPath))
            {
                log.WriteLine(msg);
                log.Flush();
            }
        }
    }

    internal class Planet
    {
        internal string Name { get; set; }
        internal Population TotalPopulation { get; set; }
        internal double Diameter { get; set; }

        internal void MonitorRotation() => Write($"{Name} is rotating.");
    }

    internal class Population
    {
        internal long Males { get; }
        internal long Females { get; }
        internal long Transenders { get; }
    }

    internal static class Logger
    {
        internal static Action<string> WriteMessage;
        public static Severity LogLevel { get; } = Severity.Warning;

        public static void LogMessage(Severity s, string component, string msg)
        {
            if (s < LogLevel)
                return;

            var outputMsg = $"{DateTime.Now}\t{s}\t{component}\t{msg}";
            WriteMessage?.Invoke(outputMsg);
        }

        public enum Severity
        {
            Verbose,
            Trace,
            Information,
            Warning,
            Error,
            Critical
        }
    }
}

//?. null propagation operator
//The compiler generates code for the ?. operator that ensures the left side of the ?. expression 
//is evaluated once, and the result is cached