using System.ComponentModel.DataAnnotations;

namespace UserManagementAPI.Models.Binding
{
    public class UserBindingModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required] 
        public string Phone { get; set; }
        [Required] 
        public string Gender { get; set; }
        [Required] 
        public DateTime DateOfBirth { get; set; }
        public string Nationality { get; set; }
        [Required]
        public string Role { get; set; }
    }
}
