namespace MyCars.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using MyCars.Data;
    using MyCars.Data.Common.Repositories;
    using MyCars.Data.Models;

    public class BrandsController : AdministrationController
    {
        private readonly IDeletableEntityRepository<Brand> dataRepository;

        public BrandsController(IDeletableEntityRepository<Brand> dataRepository)
        {
            this.dataRepository = dataRepository;
        }

        // GET: Administration/Brands
        public async Task<IActionResult> Index()
        {
            return this.View(await this.dataRepository.AllWithDeleted().ToListAsync());
        }

        // GET: Administration/Brands/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var brand = await this.dataRepository.All()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (brand == null)
            {
                return this.NotFound();
            }

            return this.View(brand);
        }

        // GET: Administration/Brands/Create
        public IActionResult Create()
        {
            return this.View();
        }

        // POST: Administration/Brands/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] Brand brand)
        {
            if (this.ModelState.IsValid)
            {
                await this.dataRepository.AddAsync(brand);
                await this.dataRepository.SaveChangesAsync();
                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(brand);
        }

        // GET: Administration/Brands/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var brand = this.dataRepository.All().FirstOrDefault(x => x.Id == id);
            if (brand == null)
            {
                return this.NotFound();
            }

            return this.View(brand);
        }

        // POST: Administration/Brands/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] Brand brand)
        {
            if (id != brand.Id)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.dataRepository.Update(brand);
                    await this.dataRepository.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.BrandExists(brand.Id))
                    {
                        return this.NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(brand);
        }

        // GET: Administration/Brands/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var brand = await this.dataRepository.All()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (brand == null)
            {
                return this.NotFound();
            }

            return this.View(brand);
        }

        // POST: Administration/Brands/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var brand = this.dataRepository.All().FirstOrDefault(x => x.Id == id);
            this.dataRepository.Delete(brand);
            await this.dataRepository.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool BrandExists(int id)
        {
            return this.dataRepository.All().Any(e => e.Id == id);
        }
    }
}
