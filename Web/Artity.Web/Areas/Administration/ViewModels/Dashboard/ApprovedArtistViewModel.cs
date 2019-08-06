using Artity.Data.Models;
using Artity.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Artity.Web.Areas.Administration.ViewModels.Dashboard
{
    public class ApprovedArtistViewModel : IMapFrom<Artist>
    {
        public string Id { get; set; }

        public string Nikname { get; set; }

        public string AboutMe { get; set; }

        public bool IsApproved { get; set; }
    }
}
