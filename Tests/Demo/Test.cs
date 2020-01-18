using NUnit.Framework;
using System;

namespace Tests.Demo
{
    [TestFixture]
    public class Test : BaseTest
    {
        private void PreConditions()
        {
            loginPage
                .GoTo()
                .LogIn();
            mainPage
                .OpenProject();
        }

        [Test(Description = "JB-001 - User can create new issue in project")]

        public void JB001()
        {
            string issueName = "Test summary" + new Random().Next(1, 1000);

            PreConditions();

            issuesPage
                .OpenCreateIssueModal()
                .initIssueModal()
                .createIssueModal
                .CreateNewIssue(issueName);
            issuesPage
                .VerifyThatIssueWasCreated(issueName);
        }

        [Test(Description = "JB-010 - User can view issue`s workflow from issue")]
        public void JB010()
        {
            PreConditions();

            issuesPage.
                OpenWorkflow().
                VerifyThatWorkflowWasOpened();
        }

        [Test(Description = "User can create comment in issue")]
        public void JB020()
        {
            PreConditions();

            commentPage.CreateComment("TestComment")
                .VerifyThatCommentCreated("TestComment");    
        }

        [Test(Description = "User can edit comment in issue")]
        public void JB030()
        {
            PreConditions();

            commentPage.EditComment("EditTestComment")
                .VerifyThatCommentEdited("edited");
        }

        [Test(Description = "User can delete comment in issue")]
        public void JB040()
        {
            PreConditions();

            commentPage.DeleteComment()
                .VerifyThatCommentDeleted("TEST-12 has been updated.");
        }
    }
}
