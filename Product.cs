using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace login
{
    class Product
    {
        public string name;
        public double price;
        public int count;
        public int place;
        public string visual;
        public string owner;
        public Product(string name, double price, int count, int place, string visual, string owner)
        {
            this.name = name;
            this.price = price;
            this.count = count;
            this.place = place;
            this.visual = visual;
            this.owner = owner;
            
        }
    }
}
