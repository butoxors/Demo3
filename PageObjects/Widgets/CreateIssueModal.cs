using OpenQA.Selenium;
using System.Collections.Generic;
using System.Threading;

namespace PageObjects.Pages.Widgets
{
    public class CreateIssueModal : BasePage
    {
        public readonly By SelectIssueTypeBy = By.XPath("//input[@id='issuetype-field']");
        public readonly By IssueTypesBy = By.XPath("//a[@class='aui-icon-container']");
        public readonly By IssueSummaryBy = By.XPath("//input[@name='summary']");
        public readonly By PriorityBy = By.XPath("//label[text()='Priority']/following-sibling::div/input");
        public readonly By DescriptopnBy = By.XPath("//*[@id='tinymce']/p");
        public readonly By CreateIssueButtonBy = By.XPath("//input[@id='create-issue-submit']");
        public readonly By CancelIssueButtonBy = By.XPath("//a[@class='cancel']");

        public IWebElement SelectIssueType => FindElementByXPath(SelectIssueTypeBy);
        public ICollection<IWebElement> IssueTypes => FindElementsByXPath(IssueTypesBy);
        public IWebElement IssueSummary => FindElementByXPath(IssueSummaryBy);
        public IWebElement Priority => FindElementByXPath(PriorityBy);
        public IWebElement Descriptopn => FindElementByXPath(DescriptopnBy);
        public IWebElement CreateIssueButton => FindElementByXPath(CreateIssueButtonBy);
        public IWebElement CancelIssueButton => FindElementByXPath(CancelIssueButtonBy);

        public CreateIssueModal(IWebDriver WebDriver) : base(WebDriver) { }

        public CreateIssueModal CreateNewIssue(string summary)
        {
            WaitForLoaded();
            WaitBy(IssueSummaryBy);
            IssueSummary.SendKeys(summary);
            CreateIssueButton.Click();
            WaitForLoaded();
            WebDriver.Navigate().Refresh();
            WaitForLoaded();

            return this;
        }
    }
}
