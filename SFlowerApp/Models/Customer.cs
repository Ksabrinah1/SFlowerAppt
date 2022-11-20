using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SapphireApp.Models
{
    [Table("Customer")]
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string FirstName { get; set; } = null!;
        [StringLength(50)]
        [Unicode(false)]
        public string LastName { get; set; } = null!;
        [StringLength(20)]
        [Unicode(false)]
        public string? Phone { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string Email { get; set; } = null!;
        [StringLength(50)]
        [Unicode(false)]
        public string Address { get; set; } = null!;
        [StringLength(30)]
        [Unicode(false)]
        public string City { get; set; } = null!;
        [StringLength(30)]
        [Unicode(false)]
        public string? Region { get; set; }
        [StringLength(20)]
        [Unicode(false)]
        public string Zip { get; set; } = null!;
        [StringLength(40)]
        [Unicode(false)]
        public string Country { get; set; } = null!;

        [InverseProperty("Customer")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
