namespace MyCars.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using MyCars.Data.Common.Models;

    public class Brand : BaseDeletableModel<int>
    {
        public Brand()
        {
            this.AdCars = new HashSet<AdCar>();
        }

        public string Name { get; set; }

        public virtual ICollection<AdCar> AdCars { get; set; }
    }
}
