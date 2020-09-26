using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEBAPIEFBikeStores.Models
{
    [Table("Staffs")]
    public partial class Staffs
    {
        public Staffs()
        {
            InverseManager = new HashSet<Staffs>();
            Orders = new HashSet<Orders>();
        }

        public int StaffId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public byte Active { get; set; }
        public int StoreId { get; set; }
        public int? ManagerId { get; set; }

        public Staffs Manager { get; set; }
        public Stores Store { get; set; }
        public virtual ICollection<Staffs> InverseManager { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
    }
}
