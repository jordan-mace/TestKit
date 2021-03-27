using OpenQA.Selenium;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace TestKit.Bootstrap.Selectors
{
    /// <summary>
    /// Used to identify a Bootstrap button on a webpage.
    /// </summary>
    public class Button : CustomBy
    {
        public Button(string hint)
        {
            Hint = hint;
            Methods.Add(GetByClassName);
            Methods.Add(FindByButtonText);
        }

        public static Button WithHint(string hint)
        {
            return new Button(hint);
        }

        private ReadOnlyCollection<IWebElement> GetByClassName(ISearchContext context)
        {
            if (string.IsNullOrEmpty(Hint)) 
                return context.FindElements(ClassName("btn"));

            return new ReadOnlyCollection<IWebElement>(new List<IWebElement>());
        }

        private ReadOnlyCollection<IWebElement> FindByButtonText(ISearchContext context)
        {
            if (string.IsNullOrEmpty(Hint)) return new ReadOnlyCollection<IWebElement>(new List<IWebElement>());

            return new ReadOnlyCollection<IWebElement>
                (context.FindElements(ClassName("btn"))
                .Where(z => z.GetProperty("textContent")
                .Contains(Hint))
                .ToList());
        }
    }
}
