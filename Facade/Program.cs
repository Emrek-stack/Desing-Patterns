using System;
using System.Collections.Generic;

namespace Facade
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.Save();
        }
    }

    class Logging : ILogging
    {
        public void Log()
        {
            Console.WriteLine("Logged");
        }
    }

    internal interface ILogging
    {
        void Log();
    }

    class Caching : ICaching
    {
        public void Cache()
        {
            Console.WriteLine("Cached");
        }
    }

    internal interface ICaching
    {
        void Cache();
    }

    class Authorize : IAuthorize
    {
        public void UserCheck()
        {
            Console.WriteLine("User Checked");
        }
    }

    internal interface IAuthorize
    {
        void UserCheck();
    }

    class Validation:IValidate
    {
        public void Validate()
        {
            Console.WriteLine("Validated!");
        }
    }

    internal interface IValidate
    {
        void Validate();
    }

    class CustomerManager
    {
        private readonly CrossCuttingConcernsFacaded _concerns;

        public CustomerManager()
        {
            _concerns = new CrossCuttingConcernsFacaded();
        }

        public void Save()
        {
            _concerns.Caching.Cache();
            _concerns.Logging.Log();
            _concerns.Authorize.UserCheck();
            _concerns.Validate.Validate();

            Console.WriteLine("Saved!");
        }
    }

    class CrossCuttingConcernsFacaded
    {
        public readonly ILogging Logging;
        public readonly ICaching Caching;
        public readonly IAuthorize Authorize;
        public readonly IValidate Validate;

        public CrossCuttingConcernsFacaded()
        {
            Logging = new Logging();
            Caching = new Caching();
            Authorize = new Authorize();
            Validate = new Validation();
        }
    }
}