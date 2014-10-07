using System.ComponentModel;

namespace Domain.Definitions
{
    public enum AccountRole
    {
        [Description("Министр")]
        Ministr,
        [Description("Секретарь")]
        Referent
    }
}