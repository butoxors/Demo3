using NUnit.Framework;
using OpenQA.Selenium;
using PageObjects.Pages.Widgets;
using System.Collections.Generic;
using System.Linq;

namespace PageObjects
{
    public class IssuesPage : BasePage
    {
        public readonly By CreateIssueButtonBy = By.XPath("//button[text()='Create issue']");
        public readonly By OpenIssuesFormBy = By.XPath("//button[@original-title='Open create dialog']");
        public readonly By IssueTabBy = By.XPath("//span[@title='Issues']");
        public readonly By AllIssuesBy = By.XPath("//span[contains(@class, 'summary')]");
        public readonly By ViewWorkflowButtonBy = By.XPath("//a[contains(@title,'workflow')]");
        public readonly By WorkflowBy = By.XPath("//div[@id='view-workflow-dialog']");

        public IWebElement CreateIssueButton => FindElementByXPath(CreateIssueButtonBy);
        public IWebElement OpenIssuesForm => FindElementByXPath(OpenIssuesFormBy);
        public IWebElement IssueTab => FindElementByXPath(IssueTabBy);
        public ICollection<IWebElement> AllIssues => FindElementsByXPath(AllIssuesBy);
        public IWebElement ViewWorkflowButton => FindElementByXPath(ViewWorkflowButtonBy);
        public IWebElement Workflow => FindElementByXPath(WorkflowBy);

        public CreateIssueModal createIssueModal;

        public IssuesPage(IWebDriver webDriver) : base(webDriver) { }

        public IssuesPage initIssueModal()
        {
            createIssueModal = new CreateIssueModal(WebDriver);
            return this;
        }

        public IssuesPage OpenCreateIssueModal()
        {
            WaitForLoaded();
            WaitBy(CreateIssueButtonBy);
            CreateIssueButton.Click();
            WaitForLoaded();
            WaitBy(OpenIssuesFormBy);
            OpenIssuesForm.Click();

            return this;
        }

        public void GoTo()
        {
            WebDriver.Navigate().GoToUrl(url);
        }

        public IssuesPage OpenWorkflow()
        {
            WaitBy(ViewWorkflowButtonBy);
            ViewWorkflowButton.Click();

            return this;
        }

        public void VerifyThatWorkflowWasOpened()
        {
            WaitBy(WorkflowBy);
            Assert.NotNull(Workflow);
        }

        public void VerifyThatIssueWasCreated(string issueName)
        {
            WebDriver.Navigate().Refresh();
            WaitForLoaded();
            WaitBy(AllIssuesBy);
            string actualName = AllIssues.Where(x => x.Text == issueName).FirstOrDefault().Text;
            Assert.AreEqual(issueName, actualName);
        }
    }
}
