namespace MyCars.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using MyCars.Data.Common.Repositories;
    using MyCars.Data.Models;
    using MyCars.Services.Mapping;

    public class FeaturesService : IFeaturesService
    {
        private readonly IDeletableEntityRepository<Feature> featuresRepository;

        public FeaturesService(IDeletableEntityRepository<Feature> featuresRepository)
        {
            this.featuresRepository = featuresRepository;
        }

        public IEnumerable<T> GetAll<T>()
        {
            return this.featuresRepository.All()
                .OrderBy(x => x.Name)
                .To<T>().ToList();
        }
    }
}
