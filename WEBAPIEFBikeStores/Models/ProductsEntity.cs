using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEBAPIEFBikeStores.Models
{
    public class ProductsEntity
    {
        public int productId { get; set; }
        public string productName { get; set; }
        public int brandId { get; set; }
        public int categoryId { get; set; }
        public short modelYear { get; set; }
        public decimal listPrice { get; set; }
    }
}
