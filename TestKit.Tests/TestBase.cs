using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;

namespace TestKit.Tests
{
    public class TestBase
    {
        public IWebDriver _driver { get; private set; }
        public string _directory { get; private set; }

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
    }
}
