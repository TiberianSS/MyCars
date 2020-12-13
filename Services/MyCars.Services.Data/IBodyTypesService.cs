namespace MyCars.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IBodyTypesService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();
    }
}
