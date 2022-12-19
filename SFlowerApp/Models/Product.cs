using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SapphireApp.Models
{
    [Table("Product")]
    public partial class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string ProductName { get; set; } 
        [StringLength(50)]
        [Unicode(false)]
        public string Category { get; set; }
        [StringLength(30)]
        [Unicode(false)]
        public string Color { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Price { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? Description { get; set; }

        public string ProductImage { get; set; }
        [NotMapped]
        public  IFormFile ImageFile { get; set; }

        [InverseProperty("Product")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        //navigation Property

       // public virtual ICollection<Order> Orders { get; set; }
    }
}
