using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PageObjects;

namespace Tests
{
    [TestFixture]
    public  abstract class BaseTest
    {
        protected IWebDriver driver;

        protected LoginPage loginPage;
        protected MainPage mainPage;
        protected IssuesPage issuesPage;
        protected CommentPage commentPage;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            loginPage = new LoginPage(driver);
            mainPage = new MainPage(driver);
            issuesPage = new IssuesPage(driver);
            commentPage = new CommentPage(driver);
        }

        [TearDown]
        public void closeBrowser()
        {
            driver.Quit();
        }
    }
}
