using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace OmerKataTest
{
    [TestClass]
    public class OmerKataTest
    {
        [TestMethod]
        public void IsBasketEmpty()
        {
            Basket basket = new Basket();
            Assert.AreEqual(0,basket.total);
        }

        [TestMethod]
        public void TotalForSpecialPrice()
        {
            Dictionary<string, int> saleRules = new Dictionary<string, int>();
            PricingRules pricingRules = new PricingRules(saleRules);
            Checkout ck = new Checkout(pricingRules);
            Item itemA = new Item { sku = "A", price = 50 };
            ck.scan(itemA);
            ck.scan(itemA);        //whenever scan is called the item price is added to the total from the Checkout class
            ck.scan(itemA);
            ck.getTotal().Should().Be.EqualTo(150);
        }

        [TestMethod]
        public void TotalForNonSaleItems()
        {
            Dictionary<string, int> saleRules = new Dictionary<string, int>();
            PricingRules pricingRules = new PricingRules(saleRules);
            Checkout ck = new Checkout(pricingRules);
            Item itemA = new Item { sku = "A", price = 50 };
            Item itemB = new Item { sku = "B", price = 30 };
            ck.scan(itemA);
            ck.scan(itemB);
            ck.scan(itemA);
            ck.getTotal().Should().Be.EqualTo(130);
        }
    }
}
// possibly find a way to join method TotalForNonSaleItems() and method TotalForSpecialPrice() into one method using an if statement but that could also be a violation of the SOLID principles. 

/*Alternative way of representing my collection of keys and values for prices
var prices = new Dictionary<string, int>
    {
        {"A", 50},
        {"B", 30},
        {"C", 20},
        {"D", 15},
    }; */