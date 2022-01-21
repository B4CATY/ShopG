using System;
using System.Collections.Generic;

#nullable disable

namespace ShopG.Entities
{
    public partial class Cart
    {
        public Cart()
        {
            CardProducts = new HashSet<CardProduct>();
        }

        public int Id { get; set; }
        public int? Accountid { get; set; }

        public virtual Account Account { get; set; }
        public virtual ICollection<CardProduct> CardProducts { get; set; }
    }
}
