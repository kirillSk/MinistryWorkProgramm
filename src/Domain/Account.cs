using Domain.Abstract;
using Domain.Definitions;

namespace Domain
{
    public class Account : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Login { get; set; }

        public AccountRole Role { get; set; }

        public string PasswordHash { get; set; }
    }
}