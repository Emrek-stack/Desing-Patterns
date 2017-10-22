using System;

namespace Prototype
{
    class Program
    {
        static void Main()
        {

            Customer customer = new Customer() {FirstName = "Emre", LastName = "Karahan", City = "İstanbul", Id = 1};            
            var customer2 = (Customer)customer.Clone();
            
            
            customer2.FirstName = "Salih";
            Console.WriteLine(customer.FirstName);
            Console.WriteLine(customer2.LastName);
        }
    }

    public abstract class Person
    {
        public abstract Person Clone();
                
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }

    public class Employee : Person
    {
        public decimal Salary { get; set; }
        public override Person Clone()
        {
            return (Person) MemberwiseClone();
        }
    }
    
    public class Customer : Person
    {
        public string City { get; set; }

        public override Person Clone()
        {
            return (Person) MemberwiseClone();
        }
    }
    
}