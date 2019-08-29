using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Observer.EventAndDelegate
{
    class StockTicker
    {
        private Stock stock;
        public Stock Stock
        {
            get { return stock; }
            set
            {
                stock = value;
                // When we have a new Stock , we call the On Stock Change Event
                this.OnStockChange(new StockChangeEventArgs(this.stock));
            }
        }

        public event EventHandler<StockChangeEventArgs> StockChange;

        protected virtual void OnStockChange(StockChangeEventArgs e)
        {
            // This rule checks if there are any observers 
            // that are associate with the stock change event
            if (StockChange != null)
            {
                // This rule would call each of the Observers 
                // With the subject and the event arguments
                StockChange(this, e);
            }
        }
    }
}