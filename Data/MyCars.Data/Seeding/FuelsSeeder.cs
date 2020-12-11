namespace MyCars.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using MyCars.Data.Models;

    public class FuelsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Fuels.Any())
            {
                return;
            }

            await dbContext.Fuels.AddAsync(new Fuel { Name = "Бензин" });
            await dbContext.Fuels.AddAsync(new Fuel { Name = "Дизел" });
            await dbContext.Fuels.AddAsync(new Fuel { Name = "Газ/Бензин" });
            await dbContext.Fuels.AddAsync(new Fuel { Name = "Метан/Бензин" });
            await dbContext.Fuels.AddAsync(new Fuel { Name = "Хибрид" });
            await dbContext.Fuels.AddAsync(new Fuel { Name = "Електричество" });

            await dbContext.SaveChangesAsync();
        }
    }
}
