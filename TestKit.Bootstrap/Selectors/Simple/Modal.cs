using OpenQA.Selenium;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace TestKit.Bootstrap.Selectors
{
    /// <summary>
    /// Used to identify a Bootstrap modal on a webpage.
    /// </summary>
    public class Modal : CustomBy
    {
        public Modal(string hint)
        {
            Hint = hint;
            Methods.Add(GetByModalTitle);
        }

        public static Modal WithHint(string hint)
        {
            return new Modal(hint);
        }

        private ReadOnlyCollection<IWebElement> GetByModalTitle(ISearchContext context)
        {
            if (string.IsNullOrEmpty(Hint)) 
                return new ReadOnlyCollection<IWebElement>(new List<IWebElement>());

            return new ReadOnlyCollection<IWebElement>(context.FindElements(ClassName("modal"))
                .Where(z => z.FindElements(ClassName("modal-title")).Any(x => x.Text == Hint))
                .ToList());
        }
    }
}
