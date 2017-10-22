using System;
using System.Reflection;

namespace AbstractFactory
{
    class Program
    {
        static void Main()
        {
            ProductManager productManager = new ProductManager(new Factory1());
            ProductManager productManager2 = new ProductManager(new Factory2());
            productManager.GetAll();
            productManager2.GetAll();
            
        }
    }


    public abstract class CrossCuttingConcernsFactory1
    {
        public abstract Logging CreateLogger();
        public abstract Caching CreateCaching();
    }

    public class Factory1 : CrossCuttingConcernsFactory1
    {
        public override Logging CreateLogger()
        {
            return new Log4NetLogger();
        }

        public override Caching CreateCaching()
        {
            return new RedisCache();
        }
    }
    
    public class Factory2 : CrossCuttingConcernsFactory1
    {
        public override Logging CreateLogger()
        {
            return new NLogger();
        }

        public override Caching CreateCaching()
        {
            return new RedisCache();
        }
    }


    public abstract class Logging
    {
        public abstract void Log(string message);
    }

    public abstract class Caching
    {
        public abstract void Cache(string data);
    }

    
    public class Log4NetLogger: Logging
    {
        public override void Log(string message)
        {
            Console.WriteLine("Logged With Log4Net");
        }
    }
    
    public class NLogger: Logging
    {
        public override void Log(string message)
        {
            Console.WriteLine("Logged With NLogger");
        }
    }
    
    public class MemCache : Caching
    {
        public override void Cache(string data)
        {
            Console.WriteLine("Cached with MemCache");
        }
    }
    
    public class RedisCache : Caching
    {
        public override void Cache(string data)
        {
            Console.WriteLine("Cached with Redis");
        }
    }

    public class ProductManager
    {
        private CrossCuttingConcernsFactory1 _crossCuttingConcernsFactory1;
        private readonly Logging _logging;
        private readonly Caching _caching;

        public ProductManager(CrossCuttingConcernsFactory1 crossCuttingConcernsFactory1)
        {
            _crossCuttingConcernsFactory1 = crossCuttingConcernsFactory1;
            _logging = crossCuttingConcernsFactory1.CreateLogger();
            _caching = crossCuttingConcernsFactory1.CreateCaching();
        
        }

        public void GetAll()
        {            
            _logging.Log("Logged");
            _caching.Cache("Cached");
            Console.WriteLine("Products listed!");
        }
    }
}