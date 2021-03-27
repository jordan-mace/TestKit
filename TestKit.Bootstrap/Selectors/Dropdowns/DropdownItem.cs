using OpenQA.Selenium;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace TestKit.Bootstrap.Selectors.Dropdowns
{
    /// <summary>
    /// Used to identify an item within a Bootstrap dropdown/select on a webpage.
    /// </summary>
    public class DropdownItem : CustomBy
    {
        public DropdownItem(string hint)
        {
            Hint = hint;
            Methods.Add(FindByContents);
        }

        public static DropdownItem WithHint(string hint)
        {
            return new DropdownItem(hint);
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
