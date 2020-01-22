using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace PageObjects
{
    public class MainPage : BasePage
    {
        public readonly new string url = "https://jira.softserve.academy/secure/Dashboard.jspa";
        public readonly By ProjectsButtonBy = By.XPath("//a[@id='browse_link']");
        public readonly By CurrentProjectBy = By.XPath("//li[@id='admin_main_proj_link']/a");

        public IWebElement ProjectsButton => FindElementByXPath(ProjectsButtonBy);
        public IWebElement CurrentProject => FindElementByXPath(CurrentProjectBy);

        public MainPage(IWebDriver webDriver) : base(webDriver) { }

        public MainPage GoToMainPage()
        {
            WebDriver.Navigate().GoToUrl(url);
            return this;
        }

        public MainPage OpenProject()
        {
            WaitForPageToLoad();
            ProjectsButton.Click();
            WaitBy(CurrentProjectBy);
            CurrentProject.Click();

            return this;
        }
    }
}
