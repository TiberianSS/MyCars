﻿namespace MyCars.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using MyCars.Data.Common.Repositories;
    using MyCars.Data.Models;

    public class TransmissionsService : ITransmissionsService
    {
        private readonly IDeletableEntityRepository<Transmission> transmissionsRepository;

        public TransmissionsService(IDeletableEntityRepository<Transmission> transmissionsRepository)
        {
            this.transmissionsRepository = transmissionsRepository;
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs()
        {
            return this.transmissionsRepository.AllAsNoTracking()
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
