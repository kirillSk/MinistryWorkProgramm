using System.ComponentModel;

namespace Domain.Definitions
{
    public enum TaskState
    {
        [Description("Отправлено министру")]
        SendToMinistr,
        [Description("Отправлено секретарю")]
        BackToReferet,
        [Description("Закрыто")]
        Close,
    }
}