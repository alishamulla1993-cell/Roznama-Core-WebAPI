using System;
using System.IO;

namespace Roznama.Infrastructure.Logging
{
    public static class LogHelper
    {
        private static readonly string LogDirectory =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");

        static LogHelper()
        {
            if (!Directory.Exists(LogDirectory))
                Directory.CreateDirectory(LogDirectory);
        }

        public static void Log(string message)
        {
            string file = Path.Combine(LogDirectory, $"log_{DateTime.Now:yyyyMMdd}.txt");
            string log = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}{Environment.NewLine}";
            File.AppendAllText(file, log);
        }
    }
}