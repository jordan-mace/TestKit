using OpenQA.Selenium;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace TestKit.Bootstrap.Selectors
{
    public class BootstrapCheckbox : LabelledItem
    {
        public BootstrapCheckbox(string hint) : base(hint)
        {
            Hint = hint;
            Methods.Add(GetByClassName);
        }

        public static BootstrapCheckbox WithHint(string hint)
        {
            return new BootstrapCheckbox(hint);
        }

        private ReadOnlyCollection<IWebElement> GetByClassName(ISearchContext context)
        {
            if (string.IsNullOrEmpty(Hint))
                return new ReadOnlyCollection<IWebElement>(new List<IWebElement>());

            return new ReadOnlyCollection<IWebElement>(context.FindElements(ClassName("checkbox")).Where(z => z.GetProperty("textContent").Trim() == Hint).ToArray());
        }
    }
}
