using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Entities
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        public string Title { get; set; }
        public int ISBN { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public int CatagoryId { get; set;}
        public int AuthorId { get; set; }

    }
}
