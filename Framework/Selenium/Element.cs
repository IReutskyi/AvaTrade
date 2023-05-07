using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Selenium
{
    public class Element : IWebElement
    {
        internal readonly IWebElement _element;
        public readonly string Name;
        public By FoundBy { get; set; }

        public Element(IWebElement element, string name)
        {
            _element = element;
            Name = name;
        }

        public IWebElement Current => _element ?? throw new NullReferenceException("_element is null");


        public string TagName => Current.TagName;

        public string Text => Current.Text;

        public bool Enabled => Current.Enabled;

        public bool Selected => Current.Selected;

        public Point Location => Current.Location;

        public Size Size => Current.Size;

        public bool Displayed => Current.Displayed;

        public void Clear()
        {
            Current.Clear();
        }

        public void Click()
        {
            Current.Click();
        }

        public void ClickByJS()
        {
            ((IJavaScriptExecutor)Driver.Current).ExecuteScript("arguments[0].click();", Current);
        }

        public void ClickByActions()
        {
            Actions actions = new Actions(Driver.Current);
            actions.Click().Perform();
        }

        public void ClickOnCenter()
        {
            Actions actions = new Actions(Driver.Current);
            actions.MoveByOffset(Current.Location.X + 20, Current.Location.Y + 15).Click().Perform();
        }

        public IWebElement FindElement(By by)
        {
            return Current.FindElement(by);
        }

        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            return Current.FindElements(by);
        }

        public string GetAttribute(string attributeName)
        {
            return Current.GetAttribute(attributeName);
        }

        public string GetCssValue(string propertyName)
        {
            return Current.GetCssValue(propertyName);
        }

        public string GetDomAttribute(string attributeName)
        {
            return GetDomAttribute(attributeName);
        }

        public string GetDomProperty(string propertyName)
        {
            return Current.GetDomProperty(propertyName);
        }

        public ISearchContext GetShadowRoot()
        {
            return Current.GetShadowRoot();
        }

        public void SendKeys(string text)
        {
            Current.SendKeys(text);
        }

        public void Submit()
        {
            Current.Submit();
        }
        public void Hover()
        {
            Actions actions = new Actions(Driver.Current);
            actions.MoveToElement(Current).Perform();
        }

        public void ScrollElementToCenter()
        {
            ((IJavaScriptExecutor)Driver.Current).ExecuteScript("arguments[0].scrollIntoView({block: \"center\"});", Current);
        }
    }
}
