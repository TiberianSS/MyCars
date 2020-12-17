namespace MyCars.Web.ViewModels.AdCars
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using MyCars.Data.Models;
    using MyCars.Services.Mapping;

    public class EditAdCarInputModel : BaseAdCarInputModel, IMapFrom<AdCar>
    {
        public int Id { get; set; }
    }
}
