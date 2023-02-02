using Win22_CSharp.Interfaces;

namespace Win22_CSharp.Models
{
    internal class Contact : IContact
    {

        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string DisplayName => $"{FirstName} {LastName}";

    }
}
