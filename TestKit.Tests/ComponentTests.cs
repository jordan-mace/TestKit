using NUnit.Framework;
using OpenQA.Selenium;
using System.IO;
using OpenQA.Selenium.Chrome;
using TestKit.Bootstrap.Selectors;
using TestKit.Bootstrap.Selectors.Dropdowns;

namespace TestKit.Tests
{
    public class Tests
    {
        private IWebDriver _driver;
        private string _directory;

        [OneTimeSetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _directory = Directory.GetCurrentDirectory();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            _driver.Quit();
        }

        [Test]
        public void BootstrapMenuItems()
        {
            var path = Path.Combine(_directory, "navbar-static/index.html");
            _driver.Navigate().GoToUrl(path);

            _driver.FindElement(MenuItem.WithHint("Link"));
            _driver.FindElement(Button.WithHint("Search"));
        }

        [Test]
        public void BootstrapSignIn()
        {
            var path = Path.Combine(_directory, "sign-in/index.html");
            _driver.Navigate().GoToUrl(path);

            _driver.FindElement(Input.WithHint("Email address")).SendKeys("test123@test.com");
            _driver.FindElement(Input.WithHint("Password")).SendKeys("aaaa");
            _driver.FindElement(Checkbox.WithHint("Remember me")).Click();
            _driver.FindElement(Button.WithHint("Sign in")).Click();
        }

        [Test]
        public void BootstrapDropdowns()
        {
            var path = Path.Combine(_directory, "navbars/index.html");
            _driver.Navigate().GoToUrl(path);

            _driver.FindElement(Dropdown.WithHint("Dropdown"));
        }
    }
}