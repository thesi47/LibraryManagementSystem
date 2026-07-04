using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
    public class BookViewModel
    {
        public int BookId { get; set; }
        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "ISBN is required.")]
        public int ISBN { get; set; }
        [Required(ErrorMessage = "Price is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Price must be a positive number.")]
        public int Price { get; set; }
        [Required(ErrorMessage = "Quantity is required.")]
        public int Quantity { get; set; }
    }
}
