using NUnit.Framework;
using System;

namespace Tests.Demo
{
    [TestFixture]
    public class Test : BaseTest
    {
        [Test(Description = "User can create new issue in project"), Order(1)]
        public void TestUserCanCreateNewIssueInProject()
        {
            string issueName = "Test summary" + new Random().Next(1, 1000);

            issuesPage
                .OpenCreateIssueModal()
                .InitIssueModal()
                .CreateIssueModal
                .CreateNewIssue(issueName);
            issuesPage
                .VerifyThatIssueWasCreated(issueName);
        }

        [Test(Description = "User can view issue`s workflow from issue"), Order(5)]
        public void TestUserCanViewIssuesWorkflowFromIssue()
        {
            issuesPage.
                OpenWorkflow().
                VerifyThatWorkflowWasOpened();
            issuesPage.CloseWorkflow();
        }

        [Test(Description = "User can create comment in issue"), Order(2)]
        public void TestUserCanCreateCommentInIssue()
        {
            commentPage.CreateComment("TestComment")
                .VerifyThatCommentCreated("TestComment");    
        }

        [Test(Description = "User can edit comment in issue"), Order(3)]
        public void TestCanEditCommentInIssue()
        {
            commentPage.EditComment("EditTestComment")
                .VerifyThatCommentEdited("edited");
        }

        [Test(Description = "User can delete comment in issue"), Order(4)]
        public void TestUserCanDeleteCommentInIssue()
        {
            commentPage.DeleteComment()
                .VerifyThatCommentDeleted("TEST-12 has been updated.");
        }
    }
}
