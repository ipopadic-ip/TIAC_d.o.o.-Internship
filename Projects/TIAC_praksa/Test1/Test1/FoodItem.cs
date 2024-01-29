using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test1;


namespace Test1
{
    class FoodItem : IPurchasable
    {
        public FoodItem() { }
        public FoodItem(double price, string name)
        {
            Price = price;
            Name = name;
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Category { get; set; }

    }
}
