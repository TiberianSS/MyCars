namespace MyCars.Web.Controllers
{
    using System.Diagnostics;
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;
    using MyCars.Data;
    using MyCars.Data.Common.Repositories;
    using MyCars.Data.Models;
    using MyCars.Services.Data;
    using MyCars.Web.ViewModels;
    using MyCars.Web.ViewModels.Home;

    public class HomeController : BaseController
    {
        private readonly IGetCountService countService;

        public HomeController(IGetCountService countService)
        {
            this.countService = countService;
        }

        public IActionResult Index()
        {
            var viewModel = this.countService.GetCounts();

            return this.View(viewModel);
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
