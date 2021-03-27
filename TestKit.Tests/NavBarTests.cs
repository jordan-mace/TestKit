using NUnit.Framework;
using System.IO;
using TestKit.Bootstrap.Selectors;
using TestKit.Bootstrap.Selectors.Dropdowns;

namespace TestKit.Tests
{
    public class NavBarTests : TestBase
    {
        [Test]
        public void BootstrapDropdowns()
        {
            var path = Path.Combine(_directory, "navbars/index.html");
            _driver.Navigate().GoToUrl(path);

            _driver.FindElement(Dropdown.WithHint("Dropdown"));
            _driver.FindElement(Navbar.WithHint("Always expand"));
        }
    }
}
