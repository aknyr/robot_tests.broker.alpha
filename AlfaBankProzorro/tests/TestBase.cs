using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using System;
using OpenQA.Selenium;
using System.Text;

namespace AlfaBankProzorro
{            
    [TestFixture(typeof(ChromeDriver))]
    [TestFixture(typeof(InternetExplorerDriver))]
    [TestFixture(typeof(FirefoxDriver))]
    //сюда переносим все повторяющиеся методы общие для всех тестов
    public class TestBase<TestWebDriver> where TestWebDriver : IWebDriver, new()
    {
            protected IWebDriver driver;
            private StringBuilder verificationErrors;
            protected string baseURL;
            //private bool acceptNextAlert = true;

            [SetUp]
            public void SetUpTest()
            {
                if (typeof(TestWebDriver).Name == "ChromeDriver")
                {
                    ChromeOptions options = new ChromeOptions();
                    //для теста отключаем все расширения браузера (иначе вылазит запрос)
                    options.AddArgument("disable-extensions");
                    //передаем переменную options в новый инстант ChromeDriver чтобы запустить с параметрами
                    driver = new ChromeDriver(options);
                }
                else if (typeof(TestWebDriver).Name == "InternetExplorerDriver")
                {
                    driver = new TestWebDriver();
                }
                else
                {
                    driver = new TestWebDriver();
                }
                driver.Manage().Window.Maximize();
                baseURL = "http://zorro.azurewebsites.net/";
                verificationErrors = new StringBuilder();
            }
    
                [TearDown]
                public void TeardownTest()
                {
                    try
                    {
                        driver.Quit();
                    }
                    catch (Exception)
                    {
                        // Ignore errors if unable to close the browser
                    }
                    Assert.AreEqual("", verificationErrors.ToString());
                }
    
                protected void Login(AccountData account)
                {
                    driver.FindElement(By.Id("loginLink")).Click();
                    driver.FindElement(By.Id("Phone")).Clear();
                    driver.FindElement(By.Id("Phone")).SendKeys(account.phone);
                    driver.FindElement(By.CssSelector("input.btn.btn-default")).Click();
                    driver.FindElement(By.Id("Code")).Clear();
                    driver.FindElement(By.Id("Code")).SendKeys(account.sms);
                    driver.FindElement(By.CssSelector("input.btn.btn-default")).Click();
                }
    
                protected void Logout()
                {
                    driver.FindElement(By.Id("logoutForm")).Click();
                }
    
                protected void OpenHomePage()
                {
                    driver.Navigate().GoToUrl(baseURL + "/");
                }
    
                protected void ClickButton()
                {
                    driver.FindElement(By.Id("ZA9")).Click();
                }
    
                protected void FillRegistrationForm(UserRegistrationData regdata)
                {
                    throw new NotImplementedException();
                }
        }
}
