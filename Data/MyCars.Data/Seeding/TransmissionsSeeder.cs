namespace MyCars.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using MyCars.Data.Models;

    public class TransmissionsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Transmissions.Any())
            {
                return;
            }

            await dbContext.Transmissions.AddAsync(new Transmission { Name = "Ръчни" });
            await dbContext.Transmissions.AddAsync(new Transmission { Name = "Автоматични" });

            await dbContext.SaveChangesAsync();
        }
    }
}
