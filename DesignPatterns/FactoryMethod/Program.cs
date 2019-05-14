using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager(new LoggerFactory());
            customerManager.Save();

            Console.ReadLine();
        }
    }

    public class LoggerFactory:ILoggerFactory
    {
        public ILogger CreateLogger()
        {
            return new DsLogger();
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

    public class DsLogger:ILogger
    {
        public void Log()
        {
            Console.WriteLine("Logged with DsLogger");
        }
    }

    public class CustomerManager
    {
        private ILoggerFactory _loggerFactory; 
        public CustomerManager(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;

        }
        

        public void Save()
        {
            Console.WriteLine("Saved!");
            ILogger logger = new LoggerFactory().CreateLogger();
            logger.Log();
        }
    }
}
