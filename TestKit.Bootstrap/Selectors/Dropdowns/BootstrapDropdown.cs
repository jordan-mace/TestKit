using OpenQA.Selenium;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace TestKit.Bootstrap.Selectors.Dropdowns
{
    public class BootstrapDropdown : CustomBy
    {
        public BootstrapDropdown(string hint)
        {
            Hint = hint;
            Methods.Add(FindByContents);
        }

        public static BootstrapDropdown WithHint(string hint)
        {
            return new BootstrapDropdown(hint);
        }

        private ReadOnlyCollection<IWebElement> FindByContents(ISearchContext context)
        {
            if (string.IsNullOrEmpty(Hint)) return new ReadOnlyCollection<IWebElement>(new List<IWebElement>());

            return new ReadOnlyCollection<IWebElement>
                (context.FindElements(ClassName("dropdown"))
                .Where(z => z.GetProperty("innerText") == Hint)
                .ToList());
        }
    }
}
