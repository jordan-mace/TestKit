using OpenQA.Selenium;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace TestKit.Bootstrap.Selectors
{
    public class BootstrapInput : LabelledItem
    {
        public BootstrapInput(string hint) : base(hint)
        {
            Methods.Add(GetByPlaceholder);
        }

        public static BootstrapInput WithHint(string hint)
        {
            return new BootstrapInput(hint);
        }

        private ReadOnlyCollection<IWebElement> GetByPlaceholder(ISearchContext context)
        {
            if (string.IsNullOrEmpty(Hint)) 
                return new ReadOnlyCollection<IWebElement>(new List<IWebElement>());

            return new ReadOnlyCollection<IWebElement>(context.FindElements(TagName("input"))
                .Where(z => z.GetAttribute("placeholder") == Hint).ToList());
        }
    }
}
