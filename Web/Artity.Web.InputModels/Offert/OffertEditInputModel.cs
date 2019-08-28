using Artity.Common;
using Artity.Web.InputModels.Type;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Artity.Web.InputModels.Offert
{
    public class OffertEditInputModel
    {
        [Display(Name = "Type")]
        [Required]
        public int Type { get; set; }

        [Display(Name = "Name")]
        [Required]
        [StringLength(800, MinimumLength = 10)]
        public string Title { get; set; }

        [Display(Name = "Features about our offerts")]
        [Required]
        [StringLength(800, MinimumLength = 10)]
        public string Features { get; set; }

        public bool Contract { get; set; }

        [Display(Name = "Price")]
        [Required]
        [Range(typeof(decimal), "0", "100000", ErrorMessage = PerformenceErrors.Price)]
        public decimal Price { get; set; }

        public string Review { get; set; }

        [Display(Name = "Town")]
        [Required]
        public string Town { get; set; }

        [Display(Name = OffertConstants.Phone)]
        [Required(ErrorMessage = OffertConstants.PhoneIsRequired)]
        [RegularExpression(OffertConstants.PhoneRegex, ErrorMessage = OffertConstants.PleaseEnterValidPhone)]
        public string Tel { get; set; }

        public IEnumerable<OffertTypeInputModel> Categories { get; set; }
    }
}
