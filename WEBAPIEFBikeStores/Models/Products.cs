﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEBAPIEFBikeStores.Models
{
    [Table("Products")]
    public partial class Products
    {
        public Products()
        {
            OrderItems = new HashSet<OrderItems>();
            Stocks = new HashSet<Stocks>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public short ModelYear { get; set; }
        public decimal ListPrice { get; set; }

        public Brands Brand { get; set; }
        public Categories Category { get; set; }
        public virtual ICollection<OrderItems> OrderItems { get; set; }
        public virtual ICollection<Stocks> Stocks { get; set; }
    }
}
