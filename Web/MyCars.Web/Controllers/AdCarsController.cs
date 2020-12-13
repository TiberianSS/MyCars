namespace MyCars.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using MyCars.Services.Data;
    using MyCars.Web.ViewModels.AdCars;

    public class AdCarsController : Controller
    {
        private readonly IBrandsService brandsService;
        private readonly IBodyTypesService bodyTypesService;
        private readonly IFuelsService fuelsService;
        private readonly ITransmissionsService transmissionsService;
        private readonly IAdCarsService adcarsService;

        public AdCarsController(
            IBrandsService brandsService,
            IBodyTypesService bodyTypesService,
            IFuelsService fuelsService,
            ITransmissionsService transmissionsService,
            IAdCarsService adcarsService)
        {
            this.brandsService = brandsService;
            this.bodyTypesService = bodyTypesService;
            this.fuelsService = fuelsService;
            this.transmissionsService = transmissionsService;
            this.adcarsService = adcarsService;
        }

        public IActionResult Create()
        {
            var viewModel = new CreateAdCarInputModel();
            viewModel.BrandsItems = this.brandsService.GetAllAsKeyValuePairs();
            viewModel.BodyTypeItems = this.bodyTypesService.GetAllAsKeyValuePairs();
            viewModel.FuelItems = this.fuelsService.GetAllAsKeyValuePairs();
            viewModel.TransmissionItems = this.transmissionsService.GetAllAsKeyValuePairs();

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAdCarInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.BrandsItems = this.brandsService.GetAllAsKeyValuePairs();
                input.BodyTypeItems = this.bodyTypesService.GetAllAsKeyValuePairs();
                input.FuelItems = this.fuelsService.GetAllAsKeyValuePairs();
                input.TransmissionItems = this.transmissionsService.GetAllAsKeyValuePairs();

                return this.View(input);
            }

            await this.adcarsService.CreateAsync(input);

            return this.Redirect("/");
        }
    }
}
