using System;
using System.Collections;
using System.Collections.Generic;

namespace Composite
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Employee emre = new Employee {Name = "Emre Karahan"};
            Employee badish = new Employee {Name = "Badiş Karahan"};
            Employee kokik = new Employee {Name = "Kökik Yaman"};
            Employee ahmet = new Employee {Name = "Ahmet"};
            Employee s2k = new Employee {Name = "S2k"};
            
            emre.AddSubOrdinate(badish);
            emre.AddSubOrdinate(kokik);
            badish.AddSubOrdinate(ahmet);
            ahmet.AddSubOrdinate(s2k);

            Contractor ali = new Contractor {Name = "Ali"};
            
            badish.AddSubOrdinate(ali);

            Console.WriteLine("-" + emre.Name);
            foreach (Employee manager in emre)
            {
                Console.WriteLine("--{0}",manager.Name);
                foreach (IPerson employee in manager)
                {
                    Console.WriteLine("---{0}",employee.Name);
                }
            }
            

        }
    }

    interface IPerson
    {
        string Name { get; set; }
    }

    class Contractor : IPerson
    {
        public string Name { get; set; }
                
    }

    class Employee : IPerson, IEnumerable<IPerson>
    {
        List<IPerson>  _subordinates = new List<IPerson>();

        public void AddSubOrdinate(IPerson person)
        {
            _subordinates.Add(person);
        }

        public void RemoveSubOrdinate(IPerson person)
        {
            _subordinates.Remove(person);
        }

        public IPerson GetSuborditante(int index)
        {
            return _subordinates[index];
        }
        
        public string Name { get; set; }
        
        public IEnumerator<IPerson> GetEnumerator()
        {
            foreach (var subordinate in _subordinates)
            {
                yield return subordinate;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}