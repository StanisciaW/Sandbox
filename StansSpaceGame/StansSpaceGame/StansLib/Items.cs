using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StansLib;

namespace StansLib
{
    public class Items
    {
        public Items(string name, int price, int stock)
        {
            this.name = name;
            this.price = price;
            this.stock = stock;
        }

        private string name;
        private int price;
        private int stock;

        public string GetName() => this.name;
        public double GetPrice() => this.price;
        public int GetStock() => this.stock;

    }
}

