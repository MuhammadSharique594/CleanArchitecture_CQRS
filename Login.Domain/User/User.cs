using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Domain.User
{
    public class User
    {
        public Guid Id { get; private set; }
        public string? FirstName { get; private set; }
        public string? LastName { get; private set; }
        public string? FullName => $"{FirstName} {LastName}";
        public string? Email { get; private set; }
        public string? Password { get; private set; }

        private User(string email, string firstName, string lastName, string password) 
        { 
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
        }

        public static User Create(string email, string password, string firstName, string lastName)
        {
            return new User(email, firstName, lastName, password);
        }
    }
}
