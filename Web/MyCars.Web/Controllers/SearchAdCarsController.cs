namespace MyCars.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using MyCars.Services.Data;
    using MyCars.Web.ViewModels.AdCars;
    using MyCars.Web.ViewModels.SearchAdCars;

    public class SearchAdCarsController : BaseController
    {
        private readonly IAdCarsService adcarsService;
        private readonly IFeaturesService featuresService;

        public SearchAdCarsController(
            IAdCarsService adcarsService,
            IFeaturesService featuresService)
        {
            this.adcarsService = adcarsService;
            this.featuresService = featuresService;
        }

        public IActionResult Index()
        {
            var viewModel = new SearchIndexViewModel
            {
                Features = this.featuresService.GetAll<FeatureNameIdViewModel>(),
            };

            return this.View(viewModel);
        }

        [HttpGet]
        public IActionResult List(SearchListInputModel input)
        {
            var viewModel = new ListViewMoel
            {
                AdCars = this.adcarsService
                .GetByFeatures<AdCarInLIstViewModel>(input.Features),
            };

            return this.View(viewModel);
        }
    }
}
