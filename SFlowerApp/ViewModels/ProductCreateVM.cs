using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SapphireApp.Models;

namespace SapphireApp.ViewModels
{
    public class ProductCreateVM
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Price { get; set; }
        public string ProductImage { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }

        //[NotMapped]
        //public SelectList ProductList { get; set; }
        //Navigation property
        //public ProductCategory ProductCategory { get; set; }
    }
}
