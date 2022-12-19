using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using Microsoft.EntityFrameworkCore;

namespace SapphireApp.Models
{
    [Table("Order")]
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        [Column(TypeName = "date")]
        public DateTime OrderDate { get; set; } = DateTime.Now;
        [Column(TypeName = "date")]
        public DateTime ShipDate { get; set; } = DateTime.Now;
        [StringLength(50)]
        [Unicode(false)]
        public string ShipName { get; set; } = null!;
        [StringLength(50)]
        [Unicode(false)]
        public string ShipAddress { get; set; } = null!;
        [StringLength(20)]
        [Unicode(false)]
        public string ShipCity { get; set; } = null!;
        [StringLength(30)]
        [Unicode(false)]
        public string ShipRegion { get; set; } = "United States";  
        [StringLength(40)]
        [Unicode(false)]
        public string ShipCountry { get; set; } = null!;
        [StringLength(20)]
        [Unicode(false)]
        public string ShipZipCode { get; set; } = null!;
        [StringLength(40)]
        [Unicode(false)]
        public string ContactPhone { get; set; } = null!;

        [ForeignKey("CustomerId")]
        [InverseProperty("Orders")]
        public virtual Customer Customer { get; set; } = null!;
        [InverseProperty("Order")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

       
    }
}
