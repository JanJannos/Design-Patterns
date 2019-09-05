using System;
using System.Collections.Generic;
using System.Text;
using Design_Patterns.StrategyWithInterfaces.Interfaces;
using Design_Patterns.StrategyWithInterfaces.Objects;

namespace StrategyWithInterfaces.ShippingCostCalculatorService
{
    public class ShippingCostCalculatorService
    {
        readonly IShippingCostStrategy shippingCostStrategy;

        public ShippingCostCalculatorService(IShippingCostStrategy shippingCostStrategy)
        {
            this.shippingCostStrategy = shippingCostStrategy;
        }

        public double CalculateShippingCost(Order order)
        {
            return shippingCostStrategy.Calculate(order);
        }
    }
}
