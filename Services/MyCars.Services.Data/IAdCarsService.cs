namespace MyCars.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using MyCars.Web.ViewModels.AdCars;

    public interface IAdCarsService
    {
        Task CreateAsync(CreateAdCarInputModel input);
    }
}
