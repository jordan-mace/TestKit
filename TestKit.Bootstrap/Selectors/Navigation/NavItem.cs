using OpenQA.Selenium;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace TestKit.Bootstrap.Selectors
{
    /// <summary>
    /// Used to identify a Bootstrap nav-item on a webpage.
    /// </summary>
    public class NavItem : CustomBy
    {
        public NavItem(string hint)
        {
            Hint = hint;
            Methods.Add(GetByTextContent);
        }

        public static NavItem WithHint(string hint)
        {
            return new NavItem(hint);
        }
        
        private ReadOnlyCollection<IWebElement> GetByTextContent(ISearchContext context)
        {
            if (string.IsNullOrEmpty(Hint)) return new ReadOnlyCollection<IWebElement>(new List<IWebElement>());

            return new ReadOnlyCollection<IWebElement>
                (context.FindElements(ClassName("nav-item"))
                .Where(z => z.GetProperty("textContent")
                .Contains(Hint))
                .ToList());
        }
    }
}
