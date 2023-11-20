using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

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

        [Required]
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

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }
}
