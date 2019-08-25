using System;
using System.Collections.Generic;
using System.Text;
using Design_Patterns.StrategyWithInterfaces.Objects;

namespace Design_Patterns.StrategyWithInterfaces.Interfaces
{
    public interface IShippingCostStrategy
    {
        double Calculate(Order order);
    }
}
