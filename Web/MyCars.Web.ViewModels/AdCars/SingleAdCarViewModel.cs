namespace MyCars.Web.ViewModels.AdCars
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using AutoMapper;
    using MyCars.Data.Models;
    using MyCars.Services.Mapping;

    public class SingleAdCarViewModel : IMapFrom<AdCar>, IHaveCustomMappings
    {
        public string BrandName { get; set; }

        public string Model { get; set; }

        public int YearOfManufacture { get; set; }

        public string BodyTypeName { get; set; }

        public string FuelName { get; set; }

        public string TransmissionName { get; set; }

        public int Power { get; set; }

        public string Color { get; set; }

        public int TraveledKm { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int GsmNumber { get; set; }

        public string Email { get; set; }

        public string Location { get; set; }

        public DateTime CreatedOn { get; set; }

        public string AddedByUserUserName { get; set; }

        public string ImageUrl { get; set; }

        public IEnumerable<FeaturesViewModel> Features { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<AdCar, AdCarInLIstViewModel>()
                .ForMember(x => x.ImageUrl, opt =>
                    opt.MapFrom(x => x.Images.FirstOrDefault().RemoteImageUrl != null ?
                        x.Images.FirstOrDefault().RemoteImageUrl :
                        "/images/adcars/" + x.Images.FirstOrDefault().Id + "." + x.Images.FirstOrDefault().Extension));
        }
    }
}
