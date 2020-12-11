namespace MyCars.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using MyCars.Data.Common.Models;

    public class Feature : BaseDeletableModel<int>
    {
        public Feature()
        {
            this.AdCars = new HashSet<AdCarFeature>();
        }

        public string Name { get; set; }

        public virtual ICollection<AdCarFeature> AdCars { get; set; }
    }
}
