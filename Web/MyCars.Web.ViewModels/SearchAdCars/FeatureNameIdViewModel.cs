namespace MyCars.Web.ViewModels.SearchAdCars
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using MyCars.Data.Models;
    using MyCars.Services.Mapping;

    public class FeatureNameIdViewModel : IMapFrom<Feature>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
