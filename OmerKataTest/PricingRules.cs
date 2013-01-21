using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OmerKataTest
{
    public class PricingRules
    {
        private Dictionary<string, int> _rules = new Dictionary<string, int>();

        public PricingRules(Dictionary<string, int> rules)
        {
            _rules = rules;
        }
    }
}