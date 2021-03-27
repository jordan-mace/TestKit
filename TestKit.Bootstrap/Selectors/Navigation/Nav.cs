using OpenQA.Selenium;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace TestKit.Bootstrap.Selectors
{
    /// <summary>
    /// Used to identify a Bootstrap navbar on a webpage.
    /// </summary>
    public class Nav : CustomBy
    {
        public Nav(string hint)
        {
            Hint = hint;
            Methods.Add(GetByLinkWithinNav);
        }

        public static Nav WithHint(string hint)
        {
            return new Nav(hint);
        }

        /// <summary>
        /// Attempts to locate a Nav by the contents of any links inside the navbar
        /// </summary>
        private ReadOnlyCollection<IWebElement> GetByLinkWithinNav(ISearchContext context)
        {
            if (string.IsNullOrEmpty(Hint)) 
                return new ReadOnlyCollection<IWebElement>(new List<IWebElement>());

            return new ReadOnlyCollection<IWebElement>(context.FindElements(ClassName("nav"))
                .Where(z => z.FindElements(TagName("a")).Any(x => x.Text == Hint))
                .ToList());
        }
    }
}
