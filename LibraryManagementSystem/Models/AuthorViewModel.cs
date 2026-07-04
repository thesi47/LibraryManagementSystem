using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
    public class AuthorViewModel
    {
        public int AuthorId { get; set; }
        [Required(ErrorMessage = "Author name is required.")]
        public string AuthorName { get; set; }
        [Required(ErrorMessage = "Country is required.")]
        public string Country { get; set; }
    }
}
