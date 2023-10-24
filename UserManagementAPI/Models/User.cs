﻿using Microsoft.EntityFrameworkCore;

namespace UserManagementAPI.Models
{
    public class User
    {
        public int Id { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; } 
        public string Nationality { get; set; }
        public Role Role { get; set; }

    }
}
