using Win22_CSharp.Models;

namespace Win22_CSharp.Interfaces
{
    internal interface IContactService
    {
        void AddContact(IContact contact);
        void RemoveContact(IContact contact);
        Contact GetContactFromList(IContact contact);
        IEnumerable<IContact> GetAllContacts();
        void FileList();
    }
}
