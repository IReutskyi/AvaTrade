using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Selenium
{
    public class Elements : ReadOnlyCollection<IWebElement>
    {
        private readonly IList<IWebElement> _elements;
        private readonly string Name;
        public Elements(IList<IWebElement> list, string name) : base(list)
        {
            _elements = list;
            Name = name;
        }

        public By FoundBy { get; set; }
        public bool IsEmpty => Count == 0;

    }
}
