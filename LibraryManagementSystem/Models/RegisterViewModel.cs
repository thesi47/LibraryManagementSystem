using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
    public class RegisterViewModel
    {
        public string? FullName { get; set; }
        [Required]
        public string Email { get; set; }
        public string? Phone {  get; set; }
        public int StudentId { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
