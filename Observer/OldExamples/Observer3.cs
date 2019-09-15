using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace Design_Patterns.Observer
{

    public class Market
    {
        private List<float> prices = new List<float>();

        public void AddPrice(float price)
        {
            prices.Add(price);
            PriceAdded?.Invoke(this, price);
        }

        public event EventHandler<float> PriceAdded;
    }

    public class Observer3
    {
        static void Main1(string[] args)
        {
            var market = new Market();
            market.PriceAdded += (sender, f) => { Console.WriteLine($"We got a new price of {f}"); };
            market.AddPrice(456);
        }
    }
}
