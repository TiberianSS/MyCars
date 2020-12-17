namespace MyCars.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using MyCars.Common;
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
        private readonly IWebHostEnvironment environment;

        public AdCarsController(
            IBrandsService brandsService,
            IBodyTypesService bodyTypesService,
            IFuelsService fuelsService,
            ITransmissionsService transmissionsService,
            IAdCarsService adcarsService,
            UserManager<ApplicationUser> userManager,
            IWebHostEnvironment environment)
        {
            this.brandsService = brandsService;
            this.bodyTypesService = bodyTypesService;
            this.fuelsService = fuelsService;
            this.transmissionsService = transmissionsService;
            this.adcarsService = adcarsService;
            this.userManager = userManager;
            this.environment = environment;
        }

        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public IActionResult Edit(int id)
        {
            var inputModel = this.adcarsService.GetById<EditAdCarInputModel>(id);
            inputModel.BrandsItems = this.brandsService.GetAllAsKeyValuePairs();
            inputModel.BodyTypeItems = this.bodyTypesService.GetAllAsKeyValuePairs();
            inputModel.FuelItems = this.fuelsService.GetAllAsKeyValuePairs();
            inputModel.TransmissionItems = this.transmissionsService.GetAllAsKeyValuePairs();

            return this.View(inputModel);
        }

        [HttpPost]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public async Task<IActionResult> Edit(int id, EditAdCarInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.BrandsItems = this.brandsService.GetAllAsKeyValuePairs();
                input.BodyTypeItems = this.bodyTypesService.GetAllAsKeyValuePairs();
                input.FuelItems = this.fuelsService.GetAllAsKeyValuePairs();
                input.TransmissionItems = this.transmissionsService.GetAllAsKeyValuePairs();

                return this.View(input);
            }

            await this.adcarsService.UpdateAsync(id, input);

            return this.RedirectToAction(nameof(this.ById), new { id });
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
            try
            {
                await this.adcarsService.CreateAsync(input, user.Id, $"{this.environment.WebRootPath}/images");
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                input.BrandsItems = this.brandsService.GetAllAsKeyValuePairs();
                input.BodyTypeItems = this.bodyTypesService.GetAllAsKeyValuePairs();
                input.FuelItems = this.fuelsService.GetAllAsKeyValuePairs();
                input.TransmissionItems = this.transmissionsService.GetAllAsKeyValuePairs();

                return this.View(input);
            }

            return this.Redirect("/");
        }

        public IActionResult All(int id = 1)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            const int ItemsPerPage = 12;

            var vieModel = new AdCarsListViewModel
            {
                ItemsPerPage = ItemsPerPage,
                PageNumber = id,
                AdCarsCount = this.adcarsService.GetCount(),
                AdCars = this.adcarsService.GetAll<AdCarInLIstViewModel>(id, ItemsPerPage),
            };
            return this.View(vieModel);
        }

        public IActionResult ById(int id)
        {
            var adcar = this.adcarsService.GetById<SingleAdCarViewModel>(id);

            return this.View(adcar);
        }

        [HttpPost]
        [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
        public async Task<IActionResult> Delete(int id)
        {
            await this.adcarsService.DeleteAsync(id);

            return this.RedirectToAction(nameof(this.All));
        }
    }
}
