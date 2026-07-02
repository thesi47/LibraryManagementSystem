using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Entities
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string Country {  get; set; }
    }
}
