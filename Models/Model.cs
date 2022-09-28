using System;
using System.Collections.Generic;

#nullable disable

namespace MiniOtomoto.Models
{
    public partial class Model
    {
        public Model()
        {
            Adds = new HashSet<Add>();
        }

        public int IdModel { get; set; }
        public int IdBrand { get; set; }
        public string ModelName { get; set; }

        public virtual Brand IdBrandNavigation { get; set; }
        public virtual ICollection<Add> Adds { get; set; }
    }
}
