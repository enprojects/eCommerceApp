using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.ComponentModel;

namespace Infrastructure.Data
{
    internal class TraceLogger : ILogger
    {
        private string categoryName;

        public TraceLogger(string categoryName)
        {
            this.categoryName = categoryName;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (this.categoryName == "DbContextLogger")
            {
               
                var message = formatter(state, exception);
                if (message.Contains("Executed DbCommand"))
                {
                    System.Diagnostics.Debug.Print($"**************{DateTime.Now.ToString("dd/mm/yyyy HH:mm:ss")}************************************");
                    
                    

                    Console.WriteLine(message);
                    System.Diagnostics.Debug.Print(message);
                    System.Diagnostics.Debug.Print("*********************************************************");
                }
            }
            
        }
    }
}