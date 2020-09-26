using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEBAPIEFBikeStores.Models
{
    [Table("Brands")]
    public partial class Brands
    {
        public Brands()
        {
            Products = new HashSet<Products>();
        }

        public int BrandId { get; set; }
        public string BrandName { get; set; }

        public virtual ICollection<Products> Products { get; set; }
    }
}
