using Artity.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Artity.Web.ViewModels.Order
{
    public class UserPerformenceOrderViewModel : IMapFrom<Data.Models.Order>
    {
        public string Id { get; set; }

        public string PerformenceTitle { get; set; }

        public string Status { get; set; }

        public string Place { get; set; }

        public DateTime Duration { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
