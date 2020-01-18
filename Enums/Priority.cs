using System.ComponentModel;

namespace Enums
{
    public enum Priority
    {
        [Description("Immediate")]
        Immediate,
        [Description("High")]
        High,
        [Description("Medium")]
        Medium,
        [Description("Low")]
        Low,
        [Description("Very Low")]
        VeryLow
    }
}
