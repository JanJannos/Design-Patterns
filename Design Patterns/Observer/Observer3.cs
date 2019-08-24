using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Design_Patterns.Annotations;

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
        static void Main(string[] args)
        {
            var market = new Market();
            market.PriceAdded += (sender, f) => { Console.WriteLine($"We got a new price of {f}"); };
            market.AddPrice(456);
        }
    }
}
