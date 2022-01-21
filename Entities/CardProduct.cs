using System;
using System.Collections.Generic;

#nullable disable

namespace ShopG.Entities
{
    public partial class CardProduct
    {
        public int Id { get; set; }
        public int? Productid { get; set; }
        public int? Cardid { get; set; }

        public virtual Cart Card { get; set; }
        public virtual Product Product { get; set; }
    }
}
