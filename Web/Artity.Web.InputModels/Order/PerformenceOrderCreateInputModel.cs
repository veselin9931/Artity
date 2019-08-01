namespace Artity.Web.InputModels.Order
{
    using Artity.Services.Mapping;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class PerformenceOrderCreateInputModel : IMapTo<Data.Models.Order>, IMapFrom<Data.Models.Order>
    {
        [Required]
        [Display(Name = "Event date")]
        public DateTime EventDate { get; set; }

        [Required]
        [Display(Name = "Performence")]
        public string PerformenceName { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 4)]
        public string Place { get; set; }

        public string Username { get; set; }

        [StringLength(30, MinimumLength = 4)]
        [Required]
        [Display(Name = "To")]
        public string ArtistNikname { get; set; }

        [Required]
        [StringLength(300, MinimumLength = 4)]
        public string Message { get; set; }
    }
}
