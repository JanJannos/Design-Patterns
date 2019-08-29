using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Observer.Traditional
{
    // This is the subject / inherits from AbstractSubject
    public class StockTicker : AbstractSubject
    {
        private Stock stock;
        public Stock Stock
        {
            get { return stock; }
            set
            {
                stock = value;
                this.Notify();
            }
        }
    }
}