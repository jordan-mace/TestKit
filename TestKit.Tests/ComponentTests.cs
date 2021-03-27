using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TestKit.Bootstrap.Selectors;
using TestKit.Bootstrap.Selectors.Dropdowns;

namespace TestKit.Tests
{
    public class Tests
    {
        private IWebDriver _driver;

        [OneTimeSetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
        }

        [OneTimeTearDown]
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
        public void BootstrapSignin()
        {
            _driver.Navigate().GoToUrl("https://getbootstrap.com/docs/5.0/examples/sign-in/");
            _driver.FindElement(BootstrapInput.WithHint("Email address")).SendKeys("test123@test.com");
            _driver.FindElement(BootstrapInput.WithHint("Password")).SendKeys("aaaa");
            _driver.FindElement(BootstrapCheckbox.WithHint("Remember me")).Click();
            _driver.FindElement(BootstrapButton.WithHint("Sign in")).Click();
        }

        //[Test]
        //public void BootstrapInputs()
        //{
        //    _driver.Navigate().GoToUrl("https://getbootstrap.com/docs/5.0/examples/checkout/");
        //    _driver.FindElement(BootstrapInput.WithHint("First name")).SendKeys("test123");
        //    _driver.FindElement(BootstrapCheckbox.WithHint("Shipping address is the same as my billing address"));
        //}

        [Test]
        public void BootstrapDropdowns()
        {
            _driver.Navigate().GoToUrl("https://getbootstrap.com/docs/5.0/examples/navbars/");
            _driver.FindElement(BootstrapDropdown.WithHint("Dropdown"));
        }
    }
}