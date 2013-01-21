using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OmerKataTest
{
    public class Checkout
    {
        private PricingRules _pricingRules;
        private int total;

        public Checkout(PricingRules pricingRules)
        {
            _pricingRules = pricingRules;
        }

        public void scan(Item item)
        {
            total += item.price;
        }

        public int getTotal()
        {
            return total;
        }
    }
}
