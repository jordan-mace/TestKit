using OpenQA.Selenium;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace TestKit.Bootstrap.Selectors
{
    public class BootstrapButton : CustomBy
    {
        public BootstrapButton(string hint)
        {
            Hint = hint;
            Methods.Add(GetByClassName);
            Methods.Add(FindByButtonText);
        }

        public static BootstrapButton WithHint(string hint)
        {
            return new BootstrapButton(hint);
        }

        private ReadOnlyCollection<IWebElement> GetByClassName(ISearchContext context)
        {
            if (string.IsNullOrEmpty(Hint)) 
                return context.FindElements(By.ClassName("btn"));

            return new ReadOnlyCollection<IWebElement>(new List<IWebElement>());
        }

        private ReadOnlyCollection<IWebElement> FindByButtonText(ISearchContext context)
        {
            if (string.IsNullOrEmpty(Hint)) return new ReadOnlyCollection<IWebElement>(new List<IWebElement>());

            return new ReadOnlyCollection<IWebElement>
                (context.FindElements(By.ClassName("btn"))
                .Where(z => z.GetProperty("textContent")
                .Contains(Hint))
                .ToList());
        }
    }
}
