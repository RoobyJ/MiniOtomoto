using System;
using System.Collections.Generic;

#nullable disable

namespace MiniOtomoto.Models
{
    public partial class Add
    {
        public int IdAdds { get; set; }
        public long IdOffer { get; set; }
        public int IdBrand { get; set; }
        public int IdModel { get; set; }
        public int ProductionYear { get; set; }
        public string Mileage { get; set; }
        public string Fuel { get; set; }
        public string Power { get; set; }

        public virtual Brand IdBrandNavigation { get; set; }
        public virtual Model IdModelNavigation { get; set; }
    }
}
