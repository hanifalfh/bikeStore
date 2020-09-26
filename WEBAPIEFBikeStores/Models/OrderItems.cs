using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEBAPIEFBikeStores.Models
{
    [Table("OrderItems")]
    public partial class OrderItems
    {
        public int OrderId { get; set; }
        public int ItemId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal ListPrice { get; set; }
        public decimal Discount { get; set; }

        public virtual Orders Order { get; set; }
        public virtual Products Product { get; set; }
    }
}
