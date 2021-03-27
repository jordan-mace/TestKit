using OpenQA.Selenium;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace TestKit.Bootstrap.Selectors
{
    /// <summary>
    /// Used to identify a Bootstrap badge on a webpage.
    /// </summary>
    public class Badge : CustomBy
    {
        public Badge(string hint)
        {
            Hint = hint;
            Methods.Add(FindByBadgeText);
        }

        public static Badge WithHint(string hint)
        {
            return new Badge(hint);
        }

        private ReadOnlyCollection<IWebElement> FindByBadgeText(ISearchContext context)
        {
            if (string.IsNullOrEmpty(Hint)) return new ReadOnlyCollection<IWebElement>(new List<IWebElement>());

            return new ReadOnlyCollection<IWebElement>
                (context.FindElements(ClassName("badge"))
                .Where(z => z.GetProperty("textContent")
                .Contains(Hint))
                .ToList());
        }
    }
}
