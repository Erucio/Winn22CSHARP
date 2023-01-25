using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Win22_CSharp.Interfaces
{
    internal interface IContact
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
        string Address { get;  set; }
        public string DisplayName => $"{FirstName} {LastName}";
    }
}
