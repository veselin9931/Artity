using System.ComponentModel;

namespace Artity.Data.Models.Enums
{
    public enum OrderType
    {
        [Description("Price")]
        Price =1,
        [Description("Price")]
        Contract = 2,
        [Description("Price")]
        Charity = 3,
        [Description("Price")]
        PerHour = 4,
    }
}
