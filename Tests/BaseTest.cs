using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PageObjects;

namespace Tests
{
    [TestFixture]
    public  abstract class BaseTest
    {
        protected static IWebDriver driver = new ChromeDriver();

        protected LoginPage loginPage;
        protected MainPage mainPage;
        protected IssuesPage issuesPage;
        protected CommentPage commentPage;

        [OneTimeSetUp]
        public void SetUp()
        {
            driver.Manage().Window.Maximize();
            loginPage = new LoginPage(driver);
            mainPage = new MainPage(driver);
            issuesPage = new IssuesPage(driver);
            commentPage = new CommentPage(driver);

            loginPage
                .GoToLoginPage()
                .LogIn();
            mainPage
                .OpenProject();
        }

        [OneTimeTearDown]
        public void CloseBrowser()
        {
            driver.Quit();
        }
    }
}
