namespace MyCars.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using MyCars.Data.Common.Models;

    public class AdCar : BaseDeletableModel<int>
    {
        public AdCar()
        {
            this.Features = new HashSet<AdCarFeature>();
            this.Images = new HashSet<Image>();
        }

        public int BrandId { get; set; }

        public virtual Brand Brand { get; set; }

        public string Model { get; set; }

        public int YearOfManufacture { get; set; }

        public int BodyTypeId { get; set; }

        public virtual BodyType BodyType { get; set; }

        public int FuelId { get; set; }

        public virtual Fuel Fuel { get; set; }

        public int TransmissionId { get; set; }

        public virtual Transmission Transmission { get; set; }

        public int Power { get; set; }

        public string Color { get; set; }

        public int TraveledKm { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int GsmNumber { get; set; }

        public string Email { get; set; }

        public string Location { get; set; }

        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }

        public virtual ICollection<AdCarFeature> Features { get; set; }

        public virtual ICollection<Image> Images { get; set; }
    }
}
