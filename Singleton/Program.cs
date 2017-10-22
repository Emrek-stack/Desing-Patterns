using System;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            var customerManager =  CustomerManager.CreateAsSingleton();
            customerManager.Save();
                        
        }
    }

    class CustomerManager
    {
        private static CustomerManager _customer;
        static readonly object LockObject = new object();
        
        private CustomerManager()
        {
            
        }

        public static CustomerManager CreateAsSingleton()
        {
            lock (LockObject)
            {
                if (_customer == null)
                {
                    _customer = new CustomerManager();
                }
            }                 
            return _customer;                        
        }

        public void Save()
        {
            Console.WriteLine("Saved!");
        }
    }
}