using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace AlfaBankProzorro
{
    public class ObserverTest<TestWebDriver> : TestBase<TestWebDriver> where TestWebDriver : IWebDriver, new() //наследуемся от базового класса
    {
        [Test]
        public void TestMethod1()
        {
            OpenHomePage();
            ClickButton();
            Login(new AccountData("phone", "sms"));
        }

        [Test]
        public void SearchTest()
        {
            OpenHomePage();
            driver.FindElement(By.CssSelector(".nav.navbar-nav>li>a")).Click();
            driver.FindElement(By.CssSelector("#search-term")).Clear();
            driver.FindElement(By.CssSelector("#search-term")).SendKeys("квартира");
            driver.FindElement(By.CssSelector(".form-horizontal>input")).Click();
        }
    }
}
