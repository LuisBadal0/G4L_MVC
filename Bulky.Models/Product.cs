using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace StoreG.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        [DisplayName("Title Name")]
        public string ProductName { get; set; }

        public string Description { get; set; }

        [Required]
        public string Developer { get; set; }

        [Required]
        public string Publisher { get; set; }

        [Required]
        [DisplayName("List Price")]
        [Range(1, 2000)]
        public double ListPrice { get; set; }

        [DisplayName("Price for 1-50")]
        [Range(1, 2000)]
        public double Price50 { get; set; }

        [DisplayName("Price for 50-1000")]
        [Range(1, 2000)]
        public double Price100 { get; set; }
        [DisplayName("Categories")]
        
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Category Category { get; set; }

        [ValidateNever]
        public List<ProductImage> ProductImages { get; set; }
    }
}
