using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;

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
#if NET451
            _directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
#else
            _directory = Directory.GetCurrentDirectory();
#endif
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}
