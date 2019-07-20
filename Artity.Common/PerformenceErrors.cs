using System;
using System.Collections.Generic;
using System.Text;

namespace Artity.Common
{
    public static class PerformenceErrors
    {
        public const string Required = "Title name is required.";

        public const string StringLenght = "The {0} must be at least {2} and at max {1} characters long.";

        public const string MinLenght = "Title name is too short.";

        public const string InvalidDate = "Date is invalid";

        public const string Price = "The {0} must be between {2} and {1}.";
    }
}
