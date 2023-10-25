using Microsoft.EntityFrameworkCore;

namespace UserManagementAPI.Models
{
    public class User
    {

        public User(string firstName, string lastName, string email, string phone, string gender, string nationality, DateTime dateOfBirth, string role)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
            Gender = gender;
            Nationality = nationality;
            DateOfBirth = dateOfBirth;
            Role = role;
        }

        public int Id { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; } 
        public string Nationality { get; set; }
        public string Role { get; set; }

    }
}
