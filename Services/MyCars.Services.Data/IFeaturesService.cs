namespace MyCars.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IFeaturesService
    {
        IEnumerable<T> GetAll<T>();
    }
}
