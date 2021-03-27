using OpenQA.Selenium;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace TestKit.Bootstrap.Selectors
{
    /// <summary>
    /// Used to identify a Bootstrap navbar on a webpage.
    /// </summary>
    public class Navbar : CustomBy
    {
        public Navbar(string hint)
        {
            Hint = hint;
            Methods.Add(GetByLinkWithinNavbar);
            Methods.Add(GetByNavBrand);
        }

        public static Navbar WithHint(string hint)
        {
            return new Navbar(hint);
        }

        /// <summary>
        /// Attempts to locate a NavBar by the contents of any links inside the navbar
        /// </summary>
        private ReadOnlyCollection<IWebElement> GetByLinkWithinNavbar(ISearchContext context)
        {
            if (string.IsNullOrEmpty(Hint)) 
                return new ReadOnlyCollection<IWebElement>(new List<IWebElement>());

            return new ReadOnlyCollection<IWebElement>(context.FindElements(ClassName("navbar"))
                .Where(z => z.FindElements(TagName("a")).Any(x => x.Text == Hint))
                .ToList());
        }

        /// <summary>
        /// Attempts to locate a NavBar by the contents of any links inside the navbar
        /// </summary>
        private ReadOnlyCollection<IWebElement> GetByNavBrand(ISearchContext context)
        {
            if (string.IsNullOrEmpty(Hint)) 
                return new ReadOnlyCollection<IWebElement>(new List<IWebElement>());

            return new ReadOnlyCollection<IWebElement>(context.FindElements(ClassName("navbar"))
                .Where(z => z.FindElements(ClassName("navbar-brand")).Any(x => x.Text == Hint))
                .ToList());
        }
    }
}
