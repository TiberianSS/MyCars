namespace MyCars.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class AdCarFeature
    {
        public int Id { get; set; }

        public int AdCarId { get; set; }

        public virtual AdCar AdCar { get; set; }

        public int FeatureId { get; set; }

        public virtual Feature Feature { get; set; }
    }
}
