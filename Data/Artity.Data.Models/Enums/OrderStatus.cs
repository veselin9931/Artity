using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Artity.Data.Models.Enums
{
    public enum OrderStatus
    {
        [Description("Sent")]
        Sent = 1,
        Accepted = 2,
        Refused = 3,
        Reviewed = 4,
    }
}
