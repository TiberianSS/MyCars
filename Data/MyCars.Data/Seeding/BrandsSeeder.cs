namespace MyCars.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using MyCars.Data.Models;

    public class BrandsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Brands.Any())
            {
                return;
            }

            await dbContext.Brands.AddAsync(new Brand { Name = "VW" });
            await dbContext.Brands.AddAsync(new Brand { Name = "Mercedes" });
            await dbContext.Brands.AddAsync(new Brand { Name = "Opel" });
            await dbContext.Brands.AddAsync(new Brand { Name = "Audi" });
            await dbContext.Brands.AddAsync(new Brand { Name = "Renault" });
            await dbContext.Brands.AddAsync(new Brand { Name = "Peugeot" });
            await dbContext.Brands.AddAsync(new Brand { Name = "Ford" });
            await dbContext.Brands.AddAsync(new Brand { Name = "Toyota" });
            await dbContext.Brands.AddAsync(new Brand { Name = "Citroen" });
            await dbContext.Brands.AddAsync(new Brand { Name = "Fiat" });
            await dbContext.Brands.AddAsync(new Brand { Name = "Mazda" });
            await dbContext.Brands.AddAsync(new Brand { Name = "Nissan" });
            await dbContext.Brands.AddAsync(new Brand { Name = "Honda" });
            await dbContext.Brands.AddAsync(new Brand { Name = "Seat" });
            await dbContext.Brands.AddAsync(new Brand { Name = "Skoda" });
            await dbContext.Brands.AddAsync(new Brand { Name = "Mitsubishi" });
            await dbContext.Brands.AddAsync(new Brand { Name = "Hyndai" });
            await dbContext.Brands.AddAsync(new Brand { Name = "Suzuki" });
            await dbContext.Brands.AddAsync(new Brand { Name = "Subaru" });
            await dbContext.Brands.AddAsync(new Brand { Name = "Volvo" });
            await dbContext.Brands.AddAsync(new Brand { Name = "Alfa Romeo" });
            await dbContext.Brands.AddAsync(new Brand { Name = "Chevrolet" });
            await dbContext.Brands.AddAsync(new Brand { Name = "Dacia" });
            await dbContext.Brands.AddAsync(new Brand { Name = "Jeep" });
            await dbContext.Brands.AddAsync(new Brand { Name = "Lancia" });
            await dbContext.Brands.AddAsync(new Brand { Name = "Mini" });
            await dbContext.Brands.AddAsync(new Brand { Name = "Daihatsu" });
            await dbContext.Brands.AddAsync(new Brand { Name = "Chrysler" });
            await dbContext.Brands.AddAsync(new Brand { Name = "Smart" });
            await dbContext.Brands.AddAsync(new Brand { Name = "Rover" });
            await dbContext.Brands.AddAsync(new Brand { Name = "Daewoo" });
            await dbContext.Brands.AddAsync(new Brand { Name = "Ssangyong" });
            await dbContext.Brands.AddAsync(new Brand { Name = "Porsche" });
            await dbContext.Brands.AddAsync(new Brand { Name = "Jaguar" });
            await dbContext.Brands.AddAsync(new Brand { Name = "Saab" });
            await dbContext.Brands.AddAsync(new Brand { Name = "Lada" });
            await dbContext.Brands.AddAsync(new Brand { Name = "Lexus" });
            await dbContext.Brands.AddAsync(new Brand { Name = "Infiniti" });
            await dbContext.Brands.AddAsync(new Brand { Name = "Dodge" });
            await dbContext.Brands.AddAsync(new Brand { Name = "Isuzu" });
            await dbContext.Brands.AddAsync(new Brand { Name = "Great wall" });
            await dbContext.Brands.AddAsync(new Brand { Name = "Moskvich" });
            await dbContext.Brands.AddAsync(new Brand { Name = "Tata" });
            await dbContext.Brands.AddAsync(new Brand { Name = "Range Rover" });
            await dbContext.Brands.AddAsync(new Brand { Name = "UAZ" });
            await dbContext.Brands.AddAsync(new Brand { Name = "Cadillac" });
            await dbContext.Brands.AddAsync(new Brand { Name = "Tesla" });
            await dbContext.Brands.AddAsync(new Brand { Name = "Trabant" });
            await dbContext.Brands.AddAsync(new Brand { Name = "MG" });
            await dbContext.Brands.AddAsync(new Brand { Name = "Bentley" });
            await dbContext.Brands.AddAsync(new Brand { Name = "Lamborghini" });
            await dbContext.Brands.AddAsync(new Brand { Name = "Lincoln" });
            await dbContext.Brands.AddAsync(new Brand { Name = "DR" });
            await dbContext.Brands.AddAsync(new Brand { Name = "Volga" });
            await dbContext.Brands.AddAsync(new Brand { Name = "Pontiac" });
            await dbContext.Brands.AddAsync(new Brand { Name = "Wartburg" });
            await dbContext.Brands.AddAsync(new Brand { Name = "Maserati" });
            await dbContext.Brands.AddAsync(new Brand { Name = "Mahindra" });
            await dbContext.Brands.AddAsync(new Brand { Name = "VAZ" });
            await dbContext.Brands.AddAsync(new Brand { Name = "Hummer" });
            await dbContext.Brands.AddAsync(new Brand { Name = "Ferrari" });
            await dbContext.Brands.AddAsync(new Brand { Name = "Zaz" });
            await dbContext.Brands.AddAsync(new Brand { Name = "Iveco" });
            await dbContext.Brands.AddAsync(new Brand { Name = "Haval" });
            await dbContext.Brands.AddAsync(new Brand { Name = "GAZ" });
            await dbContext.Brands.AddAsync(new Brand { Name = "Rolls Royce" });
            await dbContext.Brands.AddAsync(new Brand { Name = "Bulck" });
            await dbContext.Brands.AddAsync(new Brand { Name = "Aston Martin" });
            await dbContext.Brands.AddAsync(new Brand { Name = "Acura" });
            await dbContext.Brands.AddAsync(new Brand { Name = "Zastava" });
            await dbContext.Brands.AddAsync(new Brand { Name = "Piagglo" });
            await dbContext.Brands.AddAsync(new Brand { Name = "Datsun" });
            await dbContext.Brands.AddAsync(new Brand { Name = "Asia Motors" });
            await dbContext.Brands.AddAsync(new Brand { Name = "GMC" });
            await dbContext.Brands.AddAsync(new Brand { Name = "DS" });
            await dbContext.Brands.AddAsync(new Brand { Name = "Aro" });
            await dbContext.Brands.AddAsync(new Brand { Name = "Yogomo" });
            await dbContext.Brands.AddAsync(new Brand { Name = "Gas Gonow" });
            await dbContext.Brands.AddAsync(new Brand { Name = "MAN" });
            await dbContext.Brands.AddAsync(new Brand { Name = "McLaren" });
            await dbContext.Brands.AddAsync(new Brand { Name = "Maybach" });
            await dbContext.Brands.AddAsync(new Brand { Name = "Scion" });
            await dbContext.Brands.AddAsync(new Brand { Name = "Plymouth" });
            await dbContext.Brands.AddAsync(new Brand { Name = "Microcar" });
            await dbContext.Brands.AddAsync(new Brand { Name = "Barkas" });
            await dbContext.Brands.AddAsync(new Brand { Name = "Oldsmobile" });
            await dbContext.Brands.AddAsync(new Brand { Name = "Ligier" });
            await dbContext.Brands.AddAsync(new Brand { Name = "Geo" });
            await dbContext.Brands.AddAsync(new Brand { Name = "Aixam" });
            await dbContext.Brands.AddAsync(new Brand { Name = "Talbot" });
            await dbContext.Brands.AddAsync(new Brand { Name = "Lotus" });
            await dbContext.Brands.AddAsync(new Brand { Name = "Landwind" });
            await dbContext.Brands.AddAsync(new Brand { Name = "Shuanghuan" });
            await dbContext.Brands.AddAsync(new Brand { Name = "Alpina" });
            await dbContext.Brands.AddAsync(new Brand { Name = "Austin" });
            await dbContext.Brands.AddAsync(new Brand { Name = "Triumph" });
            await dbContext.Brands.AddAsync(new Brand { Name = "Proton" });

            await dbContext.SaveChangesAsync();
        }
    }
}
