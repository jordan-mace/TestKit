using OpenQA.Selenium;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace TestKit.Bootstrap.Selectors
{
    /// <summary>
    /// Used to identify a Bootstrap menu item inside a navbar on a webpage.
    /// </summary>
    public class MenuItem : CustomBy
    {
        public MenuItem(string hint)
        {
            Hint = hint;
            Methods.Add(GetByClassName);
            Methods.Add(FindByContents);
            Methods.Add(GetByNavItem);
        }

        public static MenuItem WithHint(string hint)
        {
            return new MenuItem(hint);
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

        private ReadOnlyCollection<IWebElement> FindByContents(ISearchContext context)
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
