using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;

namespace AlfaBankProzorro
{
    public class BuyerWithLicenceTest<TestWebDriver> : TestBase<TestWebDriver> where TestWebDriver : IWebDriver, new() //наследуемся от базового класса
    {
        [Test]
        public void CorrectCredentialsUserLoginTest()
        {
            OpenHomePage();
            Login(new AccountData("0501234567", "123"));
            Assert.IsTrue((driver.FindElement(By.LinkText("Вітаємо 0501234567!"))) != null, "Вітаємо 0501234567!");
            Logout();
        }

        [Test]
        public void IncorrectCredentialsUserLoginTest()
        {
            OpenHomePage();
            Login(new AccountData("phone", "123"));
            Logout();
        }

    }
}
