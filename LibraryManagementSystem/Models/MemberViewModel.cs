using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
    public class MemberViewModel
    {
        public int MemberId { get; set; }
        [Required(ErrorMessage = "Member name is required.")]
        public string MemberName { get; set; }
        [Phone(ErrorMessage = "Invalid phone number.")]
        public string PhoneNumber { get; set; }
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }
    }
}
