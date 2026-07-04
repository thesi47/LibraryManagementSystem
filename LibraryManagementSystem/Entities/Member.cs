using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Entities
{
    public class Member
    {
        [Key]
        public int MemberId { get; set; }
        public string MemberName { get; set; }
        public string PhoneNumber {  get; set; }
        public string Email { get; set; }

    }
}
