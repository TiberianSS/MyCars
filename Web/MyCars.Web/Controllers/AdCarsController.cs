namespace MyCars.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using MyCars.Data.Models;
    using MyCars.Services.Data;
    using MyCars.Web.ViewModels.AdCars;

    public class AdCarsController : Controller
    {
        private readonly IBrandsService brandsService;
        private readonly IBodyTypesService bodyTypesService;
        private readonly IFuelsService fuelsService;
        private readonly ITransmissionsService transmissionsService;
        private readonly IAdCarsService adcarsService;
        private readonly UserManager<ApplicationUser> userManager;

        public AdCarsController(
            IBrandsService brandsService,
            IBodyTypesService bodyTypesService,
            IFuelsService fuelsService,
            ITransmissionsService transmissionsService,
            IAdCarsService adcarsService,
            UserManager<ApplicationUser> userManager)
        {
            this.brandsService = brandsService;
            this.bodyTypesService = bodyTypesService;
            this.fuelsService = fuelsService;
            this.transmissionsService = transmissionsService;
            this.adcarsService = adcarsService;
            this.userManager = userManager;
        }

        [Authorize]
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
        [Authorize]
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

            // var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = await this.userManager.GetUserAsync(this.User);

            await this.adcarsService.CreateAsync(input, user.Id);

            return this.Redirect("/");
        }

        public IActionResult All(int id)
        {
            return this.View();
        }
    }
}
