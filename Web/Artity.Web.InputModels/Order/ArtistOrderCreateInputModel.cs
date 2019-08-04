namespace Artity.Web.InputModels.Order
{
    using Artity.Services.Mapping;

    using System;

    using Artity.Data.Models;
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;

    public class ArtistOrderCreateInputModel : IMapTo<Order>, IMapFrom<Order>
    {
        [Required]
        [Display(Name = "Event date")]
        public DateTime EventDate { get; set; }

        [Required]
        public DateTime Duration { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 4)]
        public string Place { get; set; }

        public string Username { get; set; }

        [StringLength(30, MinimumLength = 4)]
        [Required]
        [Display(Name = "To")]
        public string ArtistNikname { get; set; }

        //TODO add validation.
        [Required]
        public string Type { get; set; }

        [Required]
        [StringLength(300, MinimumLength = 4)]
        public string Message { get; set; }

    }
}
