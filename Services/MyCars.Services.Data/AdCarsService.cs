namespace MyCars.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using MyCars.Data.Common.Repositories;
    using MyCars.Data.Models;
    using MyCars.Web.ViewModels.AdCars;

    public class AdCarsService : IAdCarsService
    {
        private readonly IDeletableEntityRepository<AdCar> adcarsRepository;
        private readonly IDeletableEntityRepository<Feature> featuresRepository;

        public AdCarsService(
            IDeletableEntityRepository<AdCar> adcarsRepository,
            IDeletableEntityRepository<Feature> featuresRepository)
        {
            this.adcarsRepository = adcarsRepository;
            this.featuresRepository = featuresRepository;
        }

        public async Task CreateAsync(CreateAdCarInputModel input, string userId)
        {
            var adcar = new AdCar
            {
                BrandId = input.BrandId,
                Model = input.Model,
                YearOfManufacture = input.YearOfManufacture,
                BodyTypeId = input.BodyTypeId,
                FuelId = input.FuelId,
                TransmissionId = input.TransmissionId,
                Power = input.Power,
                Color = input.Color,
                TraveledKm = input.TraveledKm,
                Description = input.Description,
                Price = input.Price,
                GsmNumber = input.GsmNumber,
                Email = input.Email,
                Location = input.Location,
                AddedByUserId = userId,
            };

            foreach (var inputFeature in input.Features)
            {
                var feature = this.featuresRepository.All().FirstOrDefault(x => x.Name == inputFeature.FeatureName);

                if (feature == null)
                {
                    feature = new Feature { Name = inputFeature.FeatureName };
                }

                adcar.Features.Add(new AdCarFeature
                {
                    Feature = feature,
                });
            }

            await this.adcarsRepository.AddAsync(adcar);
            await this.adcarsRepository.SaveChangesAsync();
        }
    }
}
