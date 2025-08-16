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

        private User(string name, string email, string passwordHash, UserEnum role, Guid specialityId)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            PasswordHash = passwordHash;
            CreatedAt = DateTime.Now;
            Role = role;
            SpecialityId = specialityId;
        }

        private static bool IsValidEmail(string email)
        {
            var addr = new MailAddress(email);
            return addr.Address == email ? true : false;
        }

        public static User Create(string name, string email, string passwordHash, UserEnum role, Guid specialityId)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name must be provided.");

            if (IsValidEmail(email))
                throw new ArgumentException("Email format invalid.");

            if (string.IsNullOrWhiteSpace(passwordHash))
                throw new ArgumentException("Password must be provided.");

            if (role == UserEnum.Doctor && specialityId == Guid.Empty)
                throw new ArgumentException("SpecialityId must be provided for doctors.");

            var user = new User(name, email, passwordHash, role, specialityId);

            return user;
        }
    }

    
}
