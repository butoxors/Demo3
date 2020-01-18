using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace PageObjects
{
    public class CommentPage : BasePage
    {
        public readonly By commentButtonBy = By.XPath("//a[contains(@title, 'Comment on this issue')]");
        public readonly By commentFieldBy = By.XPath("//textarea[@id='comment']");
        public readonly By commentEditFieldBy = By.XPath("//textarea[@class='textarea long-field wiki-textfield wiki-editor-initialised wiki-edit-wrapped']");
        public readonly By saveCommentButtonBy = By.XPath("//input[contains(@accesskey, 's')]");
        public readonly By textOfCommentBy = By.XPath("//div[contains(@class, 'action-body flooded')]");

        public readonly By commentEditButtonBy = By.XPath("//span[contains(@class,'aui-iconfont-edit') and text()='Edit']");
        public readonly By commentsBy = By.XPath("//div[@class='twixi-wrap verbose actionContainer']");

        public readonly By statusEditCommentBy = By.XPath("//span[contains(@class, 'redText subText')]");
        public readonly By deleteCommentButtonBy = By.XPath("//span[contains(@class, 'delete')]");
        public readonly By confirmDeleteButtonBy = By.XPath("//input[contains(@name, 'Delete')]");
        public readonly By commentTextModeBy = By.XPath("//a[@id='aui-uid-2']");
        public readonly By deleteCommentAllertBy = By.XPath("//div[contains(@class,'aui-message')]");

        public IWebElement commentButton => FindElementByXPath(commentButtonBy);
        public IWebElement commentField => FindElementByXPath(commentFieldBy);
        public IWebElement commentEditField => FindElementByXPath(commentEditFieldBy);
        public IWebElement saveCommentButton => FindElementByXPath(saveCommentButtonBy);
        public IWebElement textOfComment => FindElementByXPath(textOfCommentBy);

        public ICollection<IWebElement> commentsList => FindElementsByXPath(commentsBy);
        public ICollection<IWebElement> commentEditButton => FindElementsByXPath(commentEditButtonBy);

        public IWebElement statusEditComment => FindElementByXPath(statusEditCommentBy);

        public IWebElement deleteCommentButton => FindElementByXPath(deleteCommentButtonBy);
        public IWebElement confirmDeleteButton => FindElementByXPath(confirmDeleteButtonBy);
        public IWebElement commentTextMode => FindElementByXPath(commentTextModeBy);

        public IWebElement deleteCommentAllert => FindElementByXPath(deleteCommentAllertBy);

        public CommentPage(IWebDriver WebDriver) : base(WebDriver)
        {
        }

        public CommentPage CreateComment(string message)
        {
            WaitForLoaded();
            WaitBy(commentButtonBy);
            commentButton.Click();
            WaitBy(commentTextModeBy);
            commentTextMode.Click();
            WaitBy(commentFieldBy);
            commentField.Click();
            commentField.SendKeys(message);
            saveCommentButton.Click();
            return this;
        }

        public CommentPage VerifyThatCommentCreated(string expected)
        {
            WaitForLoaded();
            WaitBy(textOfCommentBy);
            string actualResult = textOfComment.GetAttribute("innerText").ToString();
            Assert.AreEqual(expected, actualResult);
            return this;
        }

        public CommentPage EditComment(string message)
        {
            WaitForLoaded();
            WaitBy(commentsBy);

            commentsList.First().Click();
            commentEditButton.First().Click();
            WaitBy(commentEditFieldBy);
            commentEditField.Clear();
            commentEditField.SendKeys(message);
            saveCommentButton.Click();
            return this;
        }

        public CommentPage VerifyThatCommentEdited(string expected)
        {
            WaitForLoaded();
            WaitBy(statusEditCommentBy);
            string actualResult = statusEditComment.GetAttribute("innerText").ToString();
            Assert.AreEqual(expected, actualResult);
            return this;
        }

        public CommentPage DeleteComment()
        {
            WaitForLoaded();
            WaitBy(commentsBy);
            commentsList.First().Click();
            deleteCommentButton.Click();
            WaitForLoaded();
            WaitBy(confirmDeleteButtonBy);
            confirmDeleteButton.Click();
            return this;
        }

        public CommentPage VerifyThatCommentDeleted(string expected)
        {
            WaitForLoaded();
            WaitBy(deleteCommentAllertBy);
            string actualResult = deleteCommentAllert.GetAttribute("innerText").ToString();
            Assert.AreEqual(expected, actualResult);
            return this;
        }
    }
}
