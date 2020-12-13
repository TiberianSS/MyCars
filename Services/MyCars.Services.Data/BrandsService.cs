namespace MyCars.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using MyCars.Data.Common.Repositories;
    using MyCars.Data.Models;

    public class BrandsService : IBrandsService
    {
        private readonly IDeletableEntityRepository<Brand> brandsRepository;

        public BrandsService(IDeletableEntityRepository<Brand> brandsRepository)
        {
            this.brandsRepository = brandsRepository;
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs()
        {
            return this.brandsRepository.AllAsNoTracking()
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                }).ToList().Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name));
        }
    }
}
