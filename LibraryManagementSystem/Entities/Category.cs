using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Entities
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
