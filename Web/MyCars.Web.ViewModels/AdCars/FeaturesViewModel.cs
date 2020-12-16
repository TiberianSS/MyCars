namespace MyCars.Web.ViewModels.AdCars
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using MyCars.Data.Models;
    using MyCars.Services.Mapping;

    public class FeaturesViewModel : IMapFrom<AdCarFeature>
    {
        public string FeatureName { get; set; }
    }
}
