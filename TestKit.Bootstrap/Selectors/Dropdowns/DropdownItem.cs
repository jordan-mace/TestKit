using OpenQA.Selenium;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace TestKit.Bootstrap.Selectors.Dropdowns
{
    public class BootstrapDropdownItem : CustomBy
    {
        public BootstrapDropdownItem(string hint)
        {
            Hint = hint;
            Methods.Add(FindByContents);
        }

        public static BootstrapDropdownItem WithHint(string hint)
        {
            return new BootstrapDropdownItem(hint);
        }

        private ReadOnlyCollection<IWebElement> FindByContents(ISearchContext context)
        {
            if (string.IsNullOrEmpty(Hint)) return new ReadOnlyCollection<IWebElement>(new List<IWebElement>());

            return new ReadOnlyCollection<IWebElement>
                (context.FindElements(ClassName("dropdown"))
                .Where(z => z.GetProperty("textContent")
                .Contains(Hint))
                .ToList());
        }
    }
}
