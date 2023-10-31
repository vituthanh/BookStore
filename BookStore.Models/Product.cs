using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Tiêu đề")]
        public string Title { get; set; }

        [Display(Name = "Mô tả")]
        public string Description { get; set; }

        [Required]
        public string ISBN { get; set; }

        [Required]
        [Display(Name = "Tác giả")]
        public string Author { get; set; }

        [Required]
        [Display(Name = "Giá niêm yết")]
        [Range(1000, 10000000)]
        public double ListPrice { get; set; }

        [Required]
        [Display(Name = "Giá cho 1-50")]
        [Range(1000, 10000000)]
        public double Price { get; set; }

        [Required]
        [Display(Name = "Giá cho 50+")]
        [Range(1000, 10000000)]
        public double Price50 { get; set; }

        [Required]
        [Display(Name = "Giá cho 100+")]
        [Range(1000, 10000000)]
        public double Price100 { get; set; }

        [Display(Name = "Danh mục")]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        [ValidateNever]
        public string ImageUrl { get; set; }
    }
}
