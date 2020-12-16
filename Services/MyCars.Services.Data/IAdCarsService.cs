namespace MyCars.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using MyCars.Web.ViewModels.AdCars;

    public interface IAdCarsService
    {
        Task CreateAsync(CreateAdCarInputModel input, string userId, string imagePath);

        IEnumerable<T> GetAll<T>(int page, int itemsPerPage = 12);

        int GetCount();

        T GetById<T>(int id);
    }
}
