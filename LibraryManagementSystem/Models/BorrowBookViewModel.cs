using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
    public class BorrowBookViewModel
    {
        public int BorrowId { get; set; }
        [Required(ErrorMessage = "Book ID is required.")]
        public DateTime BorrowDate { get; set; }
        [Required(ErrorMessage = "Return date is required.")]
        public DateTime ReturnDate { get; set; }
        public bool Status { get; set; } = false;
    }
}
