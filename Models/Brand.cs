using System;
using System.Collections.Generic;

#nullable disable

namespace MiniOtomoto.Models
{
    public partial class Brand
    {
        public Brand()
        {
            Adds = new HashSet<Add>();
            Models = new HashSet<Model>();
        }

        public int IdBrand { get; set; }
        public string BrandName { get; set; }

        public virtual ICollection<Add> Adds { get; set; }
        public virtual ICollection<Model> Models { get; set; }
    }
}
