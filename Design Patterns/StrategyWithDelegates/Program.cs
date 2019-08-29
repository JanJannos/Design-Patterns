using System;
using System.Collections.Generic;
using System.Text;

namespace Design_Patterns.Strategy
{
    public class Program
    {
        /**
         *  Strategy Pattern
         *  Here we're injecting the Strategy to the Func
         */

        public static void Main1(string[] args)
        {
            Func<Order, double> fedExStrategy = CalcForFedEx;
            Func<Order, double> upsStrategy = delegate (Order order) { return 4.00d; };
            Func<Order, double> uspsStrategy = order => 3.25d;

            Order theOrder = Mother.CreateOrder();

            var calculatorService = new ShippingCostCalculatorService();
            Console.WriteLine("FedEx Shipping Cost: " +
                              calculatorService.CalculateShippingCost(theOrder, fedExStrategy));

            Console.WriteLine("UPS Shipping Cost: " +
                              calculatorService.CalculateShippingCost(theOrder, upsStrategy));

            Console.WriteLine("USPS Shipping Cost: " +
                              calculatorService.CalculateShippingCost(theOrder, uspsStrategy));

            Console.ReadKey();
        }

        internal static double CalcForFedEx(Order arg)
        {
            return 5.00d;
        }
    }
}
