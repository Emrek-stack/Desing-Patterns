using System;
using System.Collections.Generic;

namespace Builder
{
    internal class Program
    {
        public static void Main()
        {
        }
    }

    class ProductViewModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Discount { get; set; }        
        public bool DiscountApplied { get; set; }
    }

    abstract class ProductBuilder
    {
        public abstract void GetProductData();
        public abstract void ApplyDiscount();               
    }

    class NewCustomerProductBuilder: ProductBuilder
    {
        ProductViewModel model = new ProductViewModel();
        
        public override void GetProductData()
        {
            model.Id = 1;
            model.
        }

        public override void ApplyDiscount()
        {
            throw new NotImplementedException();
        }
    }

    class OldCustomerProductBuilder: ProductBuilder
    {
        public override void GetProductData()
        {
            throw new NotImplementedException();
        }

        public override void ApplyDiscount()
        {
            throw new NotImplementedException();
        }
    }
}