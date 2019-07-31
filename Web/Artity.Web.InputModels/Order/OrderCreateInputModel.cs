namespace Artity.Web.InputModels.Order
{
    using Artity.Services.Mapping;

    using System;

    using Artity.Data.Models;
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;

    public class OrderCreateInputModel : IMapTo<Order>, IMapFrom<Order>
    {
        [Required]
        public DateTime EventDate { get; set; }

        [Required]
        public DateTime Duration { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 4)]
        public string Place { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 4)]
        public string Username { get; set; }

        [StringLength(30, MinimumLength = 4)]
        [Required]
        public string ArtistNikname { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        [StringLength(300, MinimumLength = 4)]
        public string Message { get; set; }

    }
}
