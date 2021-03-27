using OpenQA.Selenium;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace TestKit.Bootstrap.Selectors
{
    public class BootstrapCheckbox : CustomBy
    {
        public BootstrapCheckbox(string hint)
        {
            Hint = hint;
            Methods.Add(GetByLabel);
            Methods.Add(GetByClassName);
        }

        public static BootstrapCheckbox WithHint(string hint)
        {
            return new BootstrapCheckbox(hint);
        }

        private ReadOnlyCollection<IWebElement> GetByLabel(ISearchContext context)
        {
            if (string.IsNullOrEmpty(Hint))
                return new ReadOnlyCollection<IWebElement>(new List<IWebElement>());

            var forItems = context.FindElements(TagName("label"))
                .Where(z => !string.IsNullOrEmpty(z.GetAttribute("for")))
                .Where(z => z.GetProperty("textContent").Trim() == Hint)
                .Select(x => context.FindElement(Id(x.GetAttribute("for"))));

            return new ReadOnlyCollection<IWebElement>(forItems.ToList());
        }

        private ReadOnlyCollection<IWebElement> GetByClassName(ISearchContext context)
        {
            if (string.IsNullOrEmpty(Hint))
                return new ReadOnlyCollection<IWebElement>(new List<IWebElement>());

            return new ReadOnlyCollection<IWebElement>(context.FindElements(ClassName("checkbox")).Where(z => z.GetProperty("textContent").Trim() == Hint).ToArray());
        }
    }
}
