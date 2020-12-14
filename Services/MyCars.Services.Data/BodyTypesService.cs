namespace MyCars.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using MyCars.Data.Common.Repositories;
    using MyCars.Data.Models;

    public class BodyTypesService : IBodyTypesService
    {
        private readonly IDeletableEntityRepository<BodyType> bodyTypesRepository;

        public BodyTypesService(IDeletableEntityRepository<BodyType> bodyTypesRepository)
        {
            this.bodyTypesRepository = bodyTypesRepository;
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs()
        {
            return this.bodyTypesRepository.AllAsNoTracking()
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                })
                .OrderBy(x => x.Name)
                .ToList().Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name));
        }
    }
}
