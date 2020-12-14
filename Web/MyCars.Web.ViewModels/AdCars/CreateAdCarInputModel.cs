namespace MyCars.Web.ViewModels.AdCars
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using MyCars.Data.Models;

    public class CreateAdCarInputModel
    {
        [Display(Name = "Brand")]
        public int BrandId { get; set; }

        [Required]
        [MinLength(2)]
        public string Model { get; set; }

        [Range(1900, int.MaxValue)]
        [Display(Name = "Year Of Manufacture")]
        public int YearOfManufacture { get; set; }

        [Display(Name = "BodyType")]
        public int BodyTypeId { get; set; }

        [Display(Name = "Fuel")]
        public int FuelId { get; set; }

        [Display(Name = "Transmission")]
        public int TransmissionId { get; set; }

        [Range(1, 1000)]
        [Display(Name = "Power (к.с.)")]
        public int Power { get; set; }

        [Required]
        [MinLength(3)]
        public string Color { get; set; }

        [Range(0, 500000)]
        [Display(Name = "TraveledKm (km.)")]
        public int TraveledKm { get; set; }

        [Required]
        [MinLength(20)]
        public string Description { get; set; }

        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "GsmNumber for contacts")]
        public int GsmNumber { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email for contacts (optional)")]
        public string Email { get; set; }

        [Required]
        [MinLength(3)]
        public string Location { get; set; }

        public IEnumerable<AdCarFeatureInputModel> Features { get; set; }

        // public virtual ICollection<Image> Images { get; set; }
        public IEnumerable<KeyValuePair<string, string>> BrandsItems { get; set; }

        public IEnumerable<KeyValuePair<string, string>> BodyTypeItems { get; set; }

        public IEnumerable<KeyValuePair<string, string>> FuelItems { get; set; }

        public IEnumerable<KeyValuePair<string, string>> TransmissionItems { get; set; }
    }
}
