using System;
using System.Collections.Generic;
using System.Text;

namespace Artity.Common
{
    public static class OffertConstants
    {
        public const string PhoneIsRequired = "Mobile noumber is required";

        public const string PleaseEnterValidPhone = "Please enter valid phone nubmer.";

        public const string PhoneRegex = "^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$";

        public const string Phone = "Phone for booking";
    }
}
