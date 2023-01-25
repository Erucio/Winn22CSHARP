using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System;
using Win22_CSharp.Interfaces;
using Win22_CSharp.Models;

namespace Win22_CSharp.Services
{
    internal class ContactService : IContactService
    {

        public string FilePath { get; set; } = null!;
        private List<Contact> contacts = new();

        public FileService file = new();

        private readonly FileService fileRead = new();

        

        public void FileList()
        {
            try
            {
                var items = JsonConvert.DeserializeObject<List<Contact>>(fileRead.Read(FilePath));
                if (items != null)
                {
                    contacts = items;
                }
            }
            catch { }
        }

        //Add Contact
        public void AddContact(IContact contact)
        {
            contacts.Add((Contact) contact);
            file.Save(FilePath, JsonConvert.SerializeObject( contacts ));

        }

        //View All Contacts
        public IEnumerable<IContact> GetAllContacts()
        {
            foreach (var contact in contacts)
            {
                Console.WriteLine($"Contact:{contact.DisplayName}");
            }
            return contacts;

        }

        //View Detailed Contact
        public Contact GetContactFromList(IContact contact)
        {
            var _contact = Console.ReadLine();

            bool contactFound = false;

            for (int i = 0; i < contacts.Count; i++) 
            {
                if (contacts[i].DisplayName == _contact)
                {
                    contactFound = true;
                    Console.Clear();
                    Console.WriteLine($"Name: {contacts[i].DisplayName}");
                    Console.WriteLine($"Email: {contacts[i].Email}");
                    Console.WriteLine($"Address: {contacts[i].Address}");
                    Console.WriteLine();
                } 
            }
            if (!contactFound)
            {
                Console.Clear();
                Console.WriteLine("Could not find Contact");
            }
            return null!;
        }
        //Remove Contact
        public void RemoveContact(IContact contact)
        {
            var _contact = Console.ReadLine();

            bool contactFound = false;
            bool deleteValidation = true;

            

            for (int i = 0; i < contacts.Count; i++)
            {
                if (contacts[i].DisplayName == _contact)
                {
                    Console.Clear();
                    contactFound = true;
                    Console.WriteLine($"Are you sure you want to delete {contacts[i].DisplayName} from your contacts? Press y for Yes and n for No");


                    while (deleteValidation)
                    {
                        var UserInput = Console.ReadLine();
                        if (UserInput == "y")
                        {
                            Console.Clear() ;
                            contacts.Remove(contacts[i]);
                            file.Save(FilePath, JsonConvert.SerializeObject(contacts));
                            Console.WriteLine("Good Riddance...");
                            deleteValidation= false;
                        }
                        else if (UserInput == "n")
                        {
                            Console.Clear() ;
                            Console.WriteLine($"Alright {contacts[i].DisplayName} can stay a little longer.");
                            deleteValidation = false;

                        }
                        else
                        {
                            Console.WriteLine("Invalid input... type y for Yes and n For No.");
                        }
                    }

                }

            }
            if(!contactFound)
            {
                Console.Clear();
                Console.WriteLine("Could not find Contact");
            }
        }


    }



}