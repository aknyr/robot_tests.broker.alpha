using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace AlfaBankProzorro
{
    public class BuyerWithoutLicenceTest<TestWebDriver> : TestBase<TestWebDriver> where TestWebDriver : IWebDriver, new()//наследуемся от базового класса
    {
        [Test]
        public void TestMethod1()
        {

        }
    }
}
