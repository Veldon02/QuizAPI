using Domain.Common.Models;
using Domain.UserAggregate.ValueObjects;

namespace Domain.UserAggregate
{
    public class User : AggregateRoot<UserId>
    {
        private User() { }
        private User(UserId id,
            string firstName,
            string lastName,
            string email,
            string username,
            string password) : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Username = username;
            Password = password;
            CreatedDate = DateTime.UtcNow;
            UpdatedDate = DateTime.UtcNow;
        }

        public static User Create(string firstName,
            string lastName,
            string email,
            string username,
            string password
            )
        {
            return new User(
                UserId.CreateUnique(),
                firstName,
                lastName,
                email,
                username,
                password
                );
        }
        public string FirstName { get; private set; } = null!;
        public string LastName { get; private set; } = null!;
        public string Email { get; private set; } = null!;
        public string Username { get; private set; } = null!;
        public string Password { get; private set; } = null!;
        public DateTime CreatedDate { get; private set; }
        public DateTime UpdatedDate { get; private set; }
    }
}
