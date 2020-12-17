namespace MyCars.Web.ViewModels.SearchAdCars
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using MyCars.Web.ViewModels.AdCars;

    public class SearchIndexViewModel
    {
        public IEnumerable<FeatureNameIdViewModel> Features { get; set; }
    }
}
