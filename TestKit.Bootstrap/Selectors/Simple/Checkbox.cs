using OpenQA.Selenium;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace TestKit.Bootstrap.Selectors
{
    /// <summary>
    /// Used to identify a Bootstrap checkbox on a webpage.
    /// </summary>
    public class Checkbox : LabelledItem
    {
        public Checkbox(string hint) : base(hint)
        {
            Hint = hint;
            Methods.Add(GetByClassName);
        }

        public static Checkbox WithHint(string hint)
        {
            return new Checkbox(hint);
        }

        private ReadOnlyCollection<IWebElement> GetByClassName(ISearchContext context)
        {
            if (string.IsNullOrEmpty(Hint))
                return new ReadOnlyCollection<IWebElement>(new List<IWebElement>());

            return new ReadOnlyCollection<IWebElement>(context.FindElements(ClassName("checkbox")).Where(z => z.GetProperty("textContent").Trim() == Hint).ToArray());
        }
    }
}
