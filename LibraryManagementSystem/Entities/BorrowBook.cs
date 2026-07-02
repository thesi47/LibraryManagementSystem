using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Entities
{
    public class BorrowBook
    {
        [Key]
        public int BorrowId { get; set; }
        public int BookId { get; set; }
        public int MemberID { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public bool Status { get; set; }
    }
}
