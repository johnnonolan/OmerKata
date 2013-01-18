using System.Collections.Generic;
using NUnit.Framework;

namespace OmerKata
{

    [TestFixture]
    public class CheckOutTests
    {
        CheckOut _checkOut;

        [SetUp]
        public void SetUp()
        {
         var pricingRules = new Dictionary<string, decimal>();
            pricingRules.Add("A",0.5m);
            _checkOut = new CheckOut(pricingRules);
        }

        [Test]
        public void EmptyBasketZero()
        {           
            Assert.That(_checkOut.Total, Is.EqualTo(0));
        }

        [Test]
        public void WhenScanningAnItemItReturnsCorrectPrice()
        {            
            _checkOut.Scan("A");
            Assert.That(_checkOut.Total,Is.EqualTo(0.5m));
        }
    }

    public class CheckOut
    {
        readonly Dictionary<string, decimal> _pricingRules;

        public CheckOut(Dictionary<string, decimal> pricingRules)
        {
            _pricingRules = pricingRules;            
        }

        public decimal Total { get; private set; }

        public void Scan(string item)
        {
            Total += _pricingRules[item];
        }
    }
}
