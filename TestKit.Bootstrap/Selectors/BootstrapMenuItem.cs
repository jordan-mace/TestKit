using OpenQA.Selenium;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace TestKit.Bootstrap.Selectors
{
    public class BootstrapMenuItem : CustomBy
    {
        public BootstrapMenuItem(string hint)
        {
            Hint = hint;
            Methods.Add(GetByClassName);
            Methods.Add(FindByButtonText);
            Methods.Add(GetByNavItem);
        }

        public static BootstrapMenuItem WithHint(string hint)
        {
            return new BootstrapMenuItem(hint);
        }

        private ReadOnlyCollection<IWebElement> GetByClassName(ISearchContext context)
        {
            if (string.IsNullOrEmpty(Hint)) 
                return context.FindElements(ClassName("menu-item"));

            return new ReadOnlyCollection<IWebElement>(new List<IWebElement>());
        }

        private ReadOnlyCollection<IWebElement> GetByNavItem(ISearchContext context)
        {
            if (string.IsNullOrEmpty(Hint)) return new ReadOnlyCollection<IWebElement>(new List<IWebElement>());

            return new ReadOnlyCollection<IWebElement>
                (context.FindElements(ClassName("nav-item"))
                .Where(z => z.GetProperty("textContent")
                .Contains(Hint))
                .ToList());
        }

        private ReadOnlyCollection<IWebElement> FindByButtonText(ISearchContext context)
        {
            if (string.IsNullOrEmpty(Hint)) return new ReadOnlyCollection<IWebElement>(new List<IWebElement>());

            return new ReadOnlyCollection<IWebElement>
                (context.FindElements(ClassName("menu-item"))
                .Where(z => z.GetProperty("textContent")
                .Contains(Hint))
                .ToList());
        }
    }
}
