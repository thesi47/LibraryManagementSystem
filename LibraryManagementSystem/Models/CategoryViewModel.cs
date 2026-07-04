using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
    public class CategoryViewModel
    {
        public int CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }
    }
}
