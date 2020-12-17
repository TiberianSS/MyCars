namespace MyCars.Web.ViewModels.AdCars
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using Microsoft.AspNetCore.Http;
    using MyCars.Data.Models;

    public class CreateAdCarInputModel : BaseAdCarInputModel
    {
        public IEnumerable<IFormFile> Images { get; set; }

        public IEnumerable<AdCarFeatureInputModel> Features { get; set; }
    }
}
