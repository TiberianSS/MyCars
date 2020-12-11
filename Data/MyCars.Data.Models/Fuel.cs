namespace MyCars.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using MyCars.Data.Common.Models;

    public class Fuel : BaseDeletableModel<int>
    {
        public Fuel()
        {
            this.AdCars = new HashSet<AdCar>();
        }

        public string Name { get; set; }

        public virtual ICollection<AdCar> AdCars { get; set; }
    }
}
