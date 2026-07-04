using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
    public class EditUserViewModel
    {
        public string Id { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
        public string? UserName { get; set; }
    }
}