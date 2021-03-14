using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace TestKit.Bootstrap.Selectors
{
    public class CustomBy : By
    {
        protected string Hint { get; set; }
        protected List<Func<ISearchContext, IEnumerable<IWebElement>>> Methods = new List<Func<ISearchContext, IEnumerable<IWebElement>>>();

        public override IWebElement FindElement(ISearchContext context)
        {
            return FindElements(context).First();
        }

        public override ReadOnlyCollection<IWebElement> FindElements(ISearchContext context)
        {
            var elList = new List<IWebElement>();

            foreach (var func in Methods)
                elList.AddRange(func.Invoke(context));

            return new ReadOnlyCollection<IWebElement>(elList);
        }
    }
}
