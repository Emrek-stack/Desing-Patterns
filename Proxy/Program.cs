using System;
using System.Threading;

namespace Proxy
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            CreditManagerProxy manager = new CreditManagerProxy();
            Console.WriteLine(manager.Calculate());
            Console.WriteLine(manager.Calculate());

            Console.ReadKey();
        }
    }

    abstract class CreditBase
    {
        public abstract int Calculate();
    }

    class CreditManager : CreditBase
    {
        public override int Calculate()
        {
            int result = 1;

            for (int i = 1; i < 5; i++)
            {
                result *= i;
                Thread.Sleep(1000);
            }
            return result;
        }
        
    }


    class CreditManagerProxy : CreditBase
    {
        private CreditManager _manager;
        private int _cachedValue;
        
        public override int Calculate()
        {
            if (_manager != null) return _cachedValue;
            _manager = new CreditManager();
            _cachedValue = _manager.Calculate();

            return _cachedValue;
        }
    }
    
}