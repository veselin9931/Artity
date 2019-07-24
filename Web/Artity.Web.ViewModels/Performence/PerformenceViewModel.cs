using System;
using System.Collections.Generic;
using System.Text;

namespace Artity.Web.ViewModels.Performence
{
    public class PerformenceViewModel
    {
        public IEnumerable<PerformenceAllViewModel> Performences { get; set; }

        public IEnumerable<string> Categories { get; set; }

    }
}
