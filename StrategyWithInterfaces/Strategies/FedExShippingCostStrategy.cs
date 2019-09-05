using Design_Patterns.StrategyWithInterfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Design_Patterns.StrategyWithInterfaces.Objects;

namespace Design_Patterns.StrategyWithInterfaces.Strategies
{
    public class FedExShippingCostStrategy : IShippingCostStrategy
    {
        public double Calculate(Order order)
        {
            return 5.00d;
        }
    }
}
