namespace MyCars.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface ITransmissionsService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();
    }
}
