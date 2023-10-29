using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
	public class Category
	{
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Category Name is required.")]
        [MaxLength(20)]
        [Display(Name = "Category Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Display Order is required.")]
        [Range(1, 100, ErrorMessage = "Display Order must be between 1 and 100.")]
        [Display(Name = "Display Order")]
        public int? DisplayOrder { get; set; }
    }
}
