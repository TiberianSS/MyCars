namespace MyCars.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using MyCars.Data.Common.Repositories;
    using MyCars.Data.Models;
    using MyCars.Services.Mapping;
    using MyCars.Web.ViewModels.AdCars;

    public class AdCarsService : IAdCarsService
    {
        private readonly string[] allowedExtensions = new[] { "jpg", "png", "gif" };
        private readonly IDeletableEntityRepository<AdCar> adcarsRepository;
        private readonly IDeletableEntityRepository<Feature> featuresRepository;

        public AdCarsService(
            IDeletableEntityRepository<AdCar> adcarsRepository,
            IDeletableEntityRepository<Feature> featuresRepository)
        {
            this.adcarsRepository = adcarsRepository;
            this.featuresRepository = featuresRepository;
        }

        public async Task CreateAsync(CreateAdCarInputModel input, string userId, string imagePath)
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

            Directory.CreateDirectory($"{imagePath}/adcars/");

            foreach (var image in input.Images)
            {
                var extension = Path.GetExtension(image.FileName).TrimStart('.');

                if (!this.allowedExtensions.Any(x => extension.EndsWith(x)))
                {
                    throw new Exception($"Invalid image extension {extension}");
                }

                var dbImage = new Image
                {
                    AddedByUserId = userId,
                    Extension = extension,
                };

                adcar.Images.Add(dbImage);

                var physicalPath = $"{imagePath}/adcars/{dbImage.Id}.{extension}";
                using Stream fileStream = new FileStream(physicalPath, FileMode.Create);
                await image.CopyToAsync(fileStream);
            }

            await this.adcarsRepository.AddAsync(adcar);
            await this.adcarsRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll<T>(int page, int itemsPerPage = 12)
        {
            var adcars = this.adcarsRepository.AllAsNoTracking()
                .OrderByDescending(x => x.Id)
                .Skip((page - 1) * itemsPerPage).Take(itemsPerPage)
                .To<T>()
                .ToList();

            return adcars;
        }

        public IEnumerable<T> GetByFeatures<T>(IEnumerable<int> featureIds)
        {
            var query = this.adcarsRepository.All().AsQueryable();

            foreach (var featureId in featureIds)
            {
                query = query.Where(x => x.Features.Any(i => i.FeatureId == featureId));
            }

            return query.To<T>().ToList();
        }

        public T GetById<T>(int id)
        {
            var adcar = this.adcarsRepository.AllAsNoTracking().Where(x => x.Id == id)
                .To<T>().FirstOrDefault();

            return adcar;
        }

        public int GetCount()
        {
            return this.adcarsRepository.All().Count();
        }

        public IEnumerable<T> GetRandom<T>(int count)
        {
            return this.adcarsRepository.All()
                .OrderBy(x => Guid.NewGuid())
                .Take(count)
                .To<T>().ToList();
        }

        public async Task UpdateAsync(int id, EditAdCarInputModel input)
        {
            var adcars = this.adcarsRepository.All().FirstOrDefault(x => x.Id == id);
            adcars.BrandId = input.BrandId;
            adcars.Model = input.Model;
            adcars.YearOfManufacture = input.YearOfManufacture;
            adcars.BodyTypeId = input.BodyTypeId;
            adcars.FuelId = input.FuelId;
            adcars.TransmissionId = input.TransmissionId;
            adcars.Power = input.Power;
            adcars.TraveledKm = input.TraveledKm;
            adcars.Description = input.Description;
            adcars.GsmNumber = input.GsmNumber;
            adcars.Email = input.Email;
            adcars.Location = input.Location;

            await this.adcarsRepository.SaveChangesAsync();
        }
    }
}
