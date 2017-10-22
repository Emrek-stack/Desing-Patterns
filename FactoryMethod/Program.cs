using System;
using System.Collections.Generic;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager(new LoggerFactory2());
            customerManager.Save();

            Console.ReadLine();
        }
                
    }

    public class LoggerFactory :  ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            // Business to decide factory
            return new EdLogger();
        }
    }
    
    public class LoggerFactory2 :  ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            // Business to decide factory
            return new LogfNetLogger();
        }
    }


    public interface ILoggerFactory
    {
        ILogger CreateLogger();
    }

    public interface ILogger
    {
        void Log();
    }

    public class EdLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with EdLogger");
        }
    }
    
    public class LogfNetLogger : ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with LogfNetLogger");
        }
    }

    public class CustomerManager
    {
        private readonly ILoggerFactory _loggerFactory;

        public CustomerManager(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }
        
        public void Save()
        {
            Console.WriteLine("Saved!");
            ILogger logger = _loggerFactory.CreateLogger();
            logger.Log();
        }
    }
}