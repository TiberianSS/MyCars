namespace MyCars.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using MyCars.Data.Common.Repositories;
    using MyCars.Data.Models;
    using MyCars.Services.Data.Models;
    using MyCars.Web.ViewModels.Home;

    public class GetCountService : IGetCountService
    {
        private readonly IDeletableEntityRepository<AdCar> adcarsRepository;
        private readonly IDeletableEntityRepository<Brand> brandsRepository;
        private readonly IDeletableEntityRepository<Feature> featuresRepository;
        private readonly IRepository<Image> imagesRepository;

        public GetCountService(
            IDeletableEntityRepository<AdCar> adcarsRepository,
            IDeletableEntityRepository<Brand> brandsRepository,
            IDeletableEntityRepository<Feature> featuresRepository,
            IRepository<Image> imagesRepository)
        {
            this.adcarsRepository = adcarsRepository;
            this.brandsRepository = brandsRepository;
            this.featuresRepository = featuresRepository;
            this.imagesRepository = imagesRepository;
        }

        public CountsDto GetCounts()
        {
            var data = new CountsDto
            {
                AdCarsCount = this.adcarsRepository.All().Count(),
                BrandsCount = this.brandsRepository.All().Count(),
                FeaturesCount = this.featuresRepository.All().Count(),
                ImagesCount = this.imagesRepository.All().Count(),
            };

            return data;
        }

        // public IndexViewModel GetCounts()
        // {
        //     var data = new IndexViewModel
        //     {
        //         AdCarsCount = this.adcarsRepository.All().Count(),
        //         BrandsCount = this.brandsRepository.All().Count(),
        //         FeaturesCount = this.featuresRepository.All().Count(),
        //         ImagesCount = this.imagesRepository.All().Count(),
        //     };
        //
        //     return data;
        // }
    }
}
