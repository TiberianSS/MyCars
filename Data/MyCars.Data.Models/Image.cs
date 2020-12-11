namespace MyCars.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using MyCars.Data.Common.Models;

    public class Image : BaseModel<string>
    {
        public Image()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public int AdCarId { get; set; }

        public virtual AdCar AdCar { get; set; }

        public string Extension { get; set; }

        public string RemoteImageUrl { get; set; }

        public string AddedByUserId { get; set; }

        public ApplicationUser AddedByUser { get; set; }
    }
}
