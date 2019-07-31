using System;
using System.Collections.Generic;
using System.Text;

namespace Artity.Web.InputModels.Order
{
    public class OrderCreateAndTypesInputModel
    {
        public IEnumerable<string> Types { get; set; }

        public OrderCreateInputModel Input { get; set; }
    }
}
