using MedScheduler.Domain.Enums;
using System.Net.Mail;

namespace MedScheduler.Domain.Entities
{
    public class User
    {
        public Guid Id {get; private set;}
        public string Name {get; private set;} = string.Empty;
        public string Email {get; private set;} = string.Empty;
        public string PasswordHash {get; private set;} = string.Empty;
        public DateTime CreatedAt {get; private set;}
        public UserEnum Role {get; private set;}
        public Guid ? SpecialityId {get; private set;} 


        private User(){}

        public User(string name, string email, string passwordHash, UserEnum role, Guid specialityId)
        {
            Id = Guid.NewGuid();
            Name = name;
            IsValidEmail(email);
            Email = email;
            PasswordHash = passwordHash;
            CreatedAt = DateTime.Now;
            Role = role;
            SpecialityId = specialityId;
        }

        private void IsValidEmail(string email)
        {
            var addr = new MailAddress(email);
            if (addr.Address == email) Email = email; 
            throw new ArgumentException("Invalid email format.");
        }
    }

    
}
