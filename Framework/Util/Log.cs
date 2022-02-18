using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Framework.Util
{
    public static class Log
    {
        public static ILogger log = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.Parent.FullName +
                    "/Framework/SavedLogs/SavedLogInformation.log")
            .CreateLogger();

        public static void Info(string message)
        {
            log.Information(message);
        }

        public static void Info(Exception ex, string message)
        {
            log.Information(ex, message);
        }
    }
}
