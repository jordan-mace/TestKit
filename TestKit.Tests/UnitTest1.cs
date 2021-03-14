using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TestKit.Bootstrap.Selectors;

namespace TestKit.Tests
{
    public class Tests
    {
        private IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }

        [Test]
        public void Test1()
        {
            _driver.Navigate().GoToUrl("https://www.jordanmace.dev");
            _driver.FindElement(BootstrapMenuItem.WithHint("Blog")).Click();
            Assert.Pass();
        }
    }
}