using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace PageObjects
{
    public abstract class BasePage
    {
        public string url = null;
        protected IWebDriver WebDriver;
        protected WebDriverWait webDriverWait;

        public BasePage(IWebDriver WebDriver)
        {
            this.WebDriver = WebDriver;
            webDriverWait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(15));
            webDriverWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            webDriverWait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
            webDriverWait.IgnoreExceptionTypes(typeof(ElementClickInterceptedException));
        }

        public IWebElement FindElementByXPath(string xPath)
        {
            IWebElement element = null;
            try
            {
                element = WebDriver.FindElement(By.XPath(xPath));
            }
            catch (Exception) { }

            return element;
        }

        public IWebElement FindElementByXPath(By xPath)
        {
            IWebElement element = null;
            try
            {
                element = WebDriver.FindElement(xPath);
            }
            catch (Exception) { }

            return element;
        }

        public ICollection<IWebElement> FindElementsByXPath(string xPath)
        {
            ICollection<IWebElement> elements = null;
            try
            {
                elements = WebDriver.FindElements(By.XPath(xPath));
            }
            catch (Exception) { }

            return elements;
        }

        public ICollection<IWebElement> FindElementsByXPath(By xPath)
        {
            ICollection<IWebElement> elements = null;
            try
            {
                elements = WebDriver.FindElements(xPath);
            }
            catch (Exception) { }

            return elements;
        }

        public void WaitForPageToLoad()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)WebDriver;
            webDriverWait.Until(webDriver => js.ExecuteScript("return document.readyState").Equals("complete"));
        }

        public void WaitBy(By by)
        {
            webDriverWait.Until<bool>(webDriver =>
            {
                try
                {
                    return webDriver.FindElement(by).Displayed;
                }
                catch (Exception)
                {
                    return false;
                }
            });
        }

        public void WaitBy(string by)
        {
            webDriverWait.Until<bool>(webDriver =>
            {
                try
                {
                    return webDriver.FindElement(By.XPath(by)).Displayed;
                }
                catch (Exception)
                {
                    return false;
                }
            });
        }
    }
}
