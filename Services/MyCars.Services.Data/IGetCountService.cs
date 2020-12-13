namespace MyCars.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using MyCars.Web.ViewModels.Home;

    public interface IGetCountService
    {
        IndexViewModel GetCounts();
    }
}
