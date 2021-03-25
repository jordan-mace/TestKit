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
        public void BootstrapButtons()
        {
            _driver.Navigate().GoToUrl("https://getbootstrap.com/");
            _driver.FindElement(BootstrapButton.WithHint("Get started")).Click();
        }

        [Test]
        public void BootstrapMenuItems()
        {
            _driver.Navigate().GoToUrl("https://getbootstrap.com/docs/5.0/examples/navbar-static/");
            _driver.FindElement(BootstrapMenuItem.WithHint("Link")).Click();
        }

        [Test]
        public void BootstrapInputs()
        {
            _driver.Navigate().GoToUrl("https://getbootstrap.com/docs/5.0/examples/checkout/");
            _driver.FindElement(BootstrapInput.WithHint("First name")).SendKeys("test123");
        }
    }
}