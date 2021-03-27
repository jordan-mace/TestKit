using OpenQA.Selenium;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace TestKit.Bootstrap.Selectors
{
    /// <summary>
    /// Used to identify a Bootstrap input element on a webpage.
    /// </summary>
    public class Input : LabelledItem
    {
        public Input(string hint) : base(hint)
        {
            Methods.Add(GetByPlaceholder);
        }

        public static Input WithHint(string hint)
        {
            return new Input(hint);
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
