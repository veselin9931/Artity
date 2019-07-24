using System;
using System.Collections.Generic;
using System.Text;

namespace Artity.Web.ViewModels.Artist
{
    public class ArtistViewModel
    {
        public IEnumerable<ArtistAllViewModel> ArtistAlls { get; set; }

        public IEnumerable<string> Categories { get; set; }


    }
}
