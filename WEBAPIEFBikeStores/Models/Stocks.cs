using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEBAPIEFBikeStores.Models
{
    [Table("Stocks")]
    public partial class Stocks
    {
        public int StoreId { get; set; }
        public int ProductId { get; set; }
        public int? Quantity { get; set; }

        public Products Product { get; set; }
        public Stores Store { get; set; }
    }
}
