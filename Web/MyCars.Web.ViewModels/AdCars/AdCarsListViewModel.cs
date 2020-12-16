namespace MyCars.Web.ViewModels.AdCars
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class AdCarsListViewModel : PagingViewModel
    {
        public IEnumerable<AdCarInLIstViewModel> AdCars { get; set; }
    }
}
