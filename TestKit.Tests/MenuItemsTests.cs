using NUnit.Framework;
using System.IO;
using TestKit.Bootstrap.Selectors;

namespace TestKit.Tests
{
    public class MenuItemsTests : TestBase
    {
        [Test]
        public void BootstrapMenuItems()
        {
            var path = Path.Combine(_directory, "navbar-static/index.html");
            _driver.Navigate().GoToUrl(path);

            _driver.FindElement(MenuItem.WithHint("Link"));
            _driver.FindElement(Button.WithHint("Search"));
        }
    }
}
