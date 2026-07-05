using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Models
{
    public class RoleViewModel
    {
        [Required]
        public string RoleName { get; set; } = string.Empty;
    }
}