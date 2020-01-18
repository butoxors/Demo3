using System.ComponentModel;

namespace Enums
{
    public enum IssueType
    {
        [Description("Story")]
        Story,
        [Description("Bug")]
        Bug,
        [Description("New Feature")]
        New,
        [Description("Task")]
        Task,
        [Description("Test")]
        Test,
        [Description("Improvement")]
        Improvement,
        [Description("Epic")]
        Epic,
        [Description("Risk")]
        Risk,
        [Description("Survey Feedback")]
        Survey
    }
}
