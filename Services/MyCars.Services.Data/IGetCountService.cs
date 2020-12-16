namespace MyCars.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using MyCars.Services.Data.Models;
    using MyCars.Web.ViewModels.Home;

    public interface IGetCountService
    {
        CountsDto GetCounts();
    }
}
