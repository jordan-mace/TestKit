using NUnit.Framework;
using OpenQA.Selenium;
using System.IO;
using OpenQA.Selenium.Chrome;
using TestKit.Bootstrap.Selectors;
using TestKit.Bootstrap.Selectors.Dropdowns;

namespace TestKit.Tests
{
    public class SignInTests : TestBase
    {
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
    }
}