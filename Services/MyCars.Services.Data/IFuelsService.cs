namespace MyCars.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IFuelsService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();
    }
}
