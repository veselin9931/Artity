using System.Collections;
using System.Collections.Generic;

namespace Artity.Web.Areas.Administration.ViewModels.Dashboard
{
    public class IndexViewModel
    {
        public int SettingsCount { get; set; }

        public IEnumerable<ApprovedArtistViewModel> allArtist { get; set; }

        public IEnumerable<ApprovedPerformenceViewModel> allPerformence { get; set; }

        public IEnumerable<ArtistsEditingViewModel> allArtistsForEdit { get; set; }
    }
}
