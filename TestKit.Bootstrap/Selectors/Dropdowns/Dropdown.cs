using OpenQA.Selenium;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace TestKit.Bootstrap.Selectors.Dropdowns
{
    /// <summary>
    /// Used to identify a Bootstrap select or dropdown on a webpage.
    /// </summary>
    public class Dropdown : CustomBy
    {
        public Dropdown(string hint)
        {
            Hint = hint;
            Methods.Add(FindByContents);
        }

        public static Dropdown WithHint(string hint)
        {
            return new Dropdown(hint);
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
