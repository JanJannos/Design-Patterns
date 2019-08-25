using System;
using System.Collections.Generic;
using System.Text;

namespace Design_Patterns.Strategy
{
    public class Order
    {
        public Address Destination { get; set; }
        public Address Origin { get; set; }
    }
}
