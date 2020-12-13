namespace MyCars.Web.ViewModels.AdCars
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class AdCarFeatureInputModel
    {
        [Required]
        [MinLength(2)]
        public string FeatureName { get; set; }
    }
}
