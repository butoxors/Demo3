using Helpers.Json;
using Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace PageObjects
{
    public class LoginPage : BasePage
    {
        public readonly new string url = "https://jira.softserve.academy/login.jsp";
        private UserModel userModel;

        public IWebElement UsernameField => FindElementByXPath("//input[@name='os_username']");
        public IWebElement PasswordField => FindElementByXPath("//input[@name='os_password']");
        public IWebElement LogInButton => FindElementByXPath("//input[@name='login']");

        public LoginPage(IWebDriver webDriver) : base(webDriver)
        {
            userModel = JsonHelper.GetUserModel();
        }

        public LoginPage GoToLoginPage()
        {
            WebDriver.Navigate().GoToUrl(url);
            return this;
        }

        public LoginPage LogIn()
        {
            WaitForPageToLoad();
            UsernameField.SendKeys(userModel.Username);
            PasswordField.SendKeys(userModel.Password);
            LogInButton.Click();
            return this;
        }
    }
}
