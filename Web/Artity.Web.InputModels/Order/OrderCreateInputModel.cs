namespace Artity.Web.InputModels.Order
{
    using Artity.Services.Mapping;

    using System;

    using Artity.Data.Models;

    public class OrderCreateInputModel : IMapTo<Order>, IMapFrom<Order>
    {
        public DateTime EventDate { get; set; }

        public DateTime Duration { get; set; }

        public string Place { get; set; }

        public string Username { get; set; }

         public string Type { get; set; }

        public string Message { get; set; }
    }
}
