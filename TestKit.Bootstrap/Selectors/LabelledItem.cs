using OpenQA.Selenium;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace TestKit.Bootstrap.Selectors
{
    public class LabelledItem : CustomBy
    {
        public LabelledItem(string hint)
        {
            Hint = hint;
            Methods.Add(GetByLabel);
        }

        protected ReadOnlyCollection<IWebElement> GetByLabel(ISearchContext context)
        {
            if (string.IsNullOrEmpty(Hint))
                return new ReadOnlyCollection<IWebElement>(new List<IWebElement>());

            var forItems = context.FindElements(TagName("label"))
                .Where(z => !string.IsNullOrEmpty(z.GetAttribute("for")))
                .Where(z => z.GetProperty("textContent").Trim() == Hint)
                .Select(x => context.FindElement(Id(x.GetAttribute("for"))));

            return new ReadOnlyCollection<IWebElement>(forItems.ToList());
        }
    }
}
