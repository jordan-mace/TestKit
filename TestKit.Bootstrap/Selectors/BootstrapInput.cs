using OpenQA.Selenium;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace TestKit.Bootstrap.Selectors
{
    public class BootstrapInput : CustomBy
    {
        public BootstrapInput(string hint)
        {
            Hint = hint;
            Methods.Add(GetByLabel);
        }

        public static BootstrapInput WithHint(string hint)
        {
            return new BootstrapInput(hint);
        }

        private ReadOnlyCollection<IWebElement> GetByLabel(ISearchContext context)
        {
            if (string.IsNullOrEmpty(Hint)) return new ReadOnlyCollection<IWebElement>(new List<IWebElement>());

            var labelAttr = context.FindElements(TagName("label"))
                .Single(z => z.GetProperty("textContent") == Hint)
                .GetAttribute("for");

            return new ReadOnlyCollection<IWebElement>(context.FindElements(By.Id(labelAttr)).ToList());
        }
    }
}
