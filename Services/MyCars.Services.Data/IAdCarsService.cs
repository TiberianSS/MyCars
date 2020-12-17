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

        IEnumerable<T> GetRandom<T>(int count);

        int GetCount();

        T GetById<T>(int id);

        Task UpdateAsync(int id, EditAdCarInputModel input);

        IEnumerable<T> GetByFeatures<T>(IEnumerable<int> featureIds);
    }
}
