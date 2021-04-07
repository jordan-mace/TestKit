using OpenQA.Selenium;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace TestKit.Bootstrap.Selectors
{
    /// <summary>
    /// Used to identify a Bootstrap alert on a webpage.
    /// </summary>
    public class Alert : CustomBy
    {
        public Alert(string hint)
        {
            Hint = hint;
            Methods.Add(FindByAlertText);
        }

        public static Alert WithHint(string hint)
        {
            return new Alert(hint);
        }

        public static Alert WithoutHint()
        {
            return new Alert("");
        }

        private ReadOnlyCollection<IWebElement> FindByAlertText(ISearchContext context)
        {
            if (string.IsNullOrEmpty(Hint)) return new ReadOnlyCollection<IWebElement>(new List<IWebElement>());

            return new ReadOnlyCollection<IWebElement>
                (context.FindElements(ClassName("alert"))
                .Where(z => z.GetProperty("textContent")
                .Contains(Hint))
                .ToList());
        }

        private ReadOnlyCollection<IWebElement> FindAllAlerts(ISearchContext context)
        {
            if (!string.IsNullOrEmpty(Hint)) return new ReadOnlyCollection<IWebElement>(new List<IWebElement>());

            return new ReadOnlyCollection<IWebElement>
                (context.FindElements(ClassName("alert"))
                .ToList());
        }
    }
}
