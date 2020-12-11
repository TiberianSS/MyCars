namespace MyCars.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using MyCars.Data.Models;

    public class BodyTypesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.BodyTypes.Any())
            {
                return;
            }

            await dbContext.BodyTypes.AddAsync(new BodyType { Name = "Седан" });
            await dbContext.BodyTypes.AddAsync(new BodyType { Name = "Хечбек" });
            await dbContext.BodyTypes.AddAsync(new BodyType { Name = "Комби" });
            await dbContext.BodyTypes.AddAsync(new BodyType { Name = "Купе" });
            await dbContext.BodyTypes.AddAsync(new BodyType { Name = "Кабрио" });
            await dbContext.BodyTypes.AddAsync(new BodyType { Name = "Джип" });
            await dbContext.BodyTypes.AddAsync(new BodyType { Name = "Пикап" });
            await dbContext.BodyTypes.AddAsync(new BodyType { Name = "Ван" });

            await dbContext.SaveChangesAsync();
        }
    }
}
