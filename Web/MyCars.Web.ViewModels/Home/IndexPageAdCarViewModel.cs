namespace MyCars.Web.ViewModels.Home
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using AutoMapper;
    using MyCars.Data.Models;
    using MyCars.Services.Mapping;

    public class IndexPageAdCarViewModel : IMapFrom<AdCar>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string BrandName { get; set; }

        public string Model { get; set; }

        public string YearOfManufacture { get; set; }

        public string BodyTypeName { get; set; }

        public string FuelName { get; set; }

        public string ImageUrl { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<AdCar, IndexPageAdCarViewModel>()
                .ForMember(x => x.ImageUrl, opt =>
                    opt.MapFrom(x => x.Images.FirstOrDefault().RemoteImageUrl != null ?
                        x.Images.FirstOrDefault().RemoteImageUrl :
                        "/images/adcars/" + x.Images.FirstOrDefault().Id + "." + x.Images.FirstOrDefault().Extension));
        }
    }
}
