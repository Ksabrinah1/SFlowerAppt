using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SapphireApp.ViewModels
{
    public class ProductEditVM
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Price { get; set; }
        public string ProductImage { get; set; }

    }
}
