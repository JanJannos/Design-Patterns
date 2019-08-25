using System;
using System.Collections.Generic;
using System.Text;

namespace Design_Patterns.Strategy
{
    public class ShippingCostCalculatorService
    {
        public double CalculateShippingCost(Order order,
            Func<Order, double> shippingCostStrategy)
        {
            return shippingCostStrategy(order);
        }
    }
}
