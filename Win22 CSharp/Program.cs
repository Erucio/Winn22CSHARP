using Win22_CSharp.Interfaces;
using Win22_CSharp.Services;
using Win22_CSharp.Models;



var ContactService = new ContactService();
ContactService.FilePath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\content.json";
ContactService.FileList();
bool isRunning = true;


while (isRunning)
{

    Console.WriteLine("Please press a corresponding button to what you would like to do next");
    Console.WriteLine("1. Add a new contact");
    Console.WriteLine("2. View all contacts");
    Console.WriteLine("3. Detailed contact view");
    Console.WriteLine("4. Remove a specific contact");
    Console.WriteLine("E. Exit program");


    var userInput = Console.ReadLine();
    var newContact = new Contact();
    



    switch (userInput)
    {
        case "1":
            Console.Clear();
            Console.WriteLine("Please enter a first name.");
            newContact.FirstName = Console.ReadLine();
            Console.Clear() ;
            Console.WriteLine("Please enter a last name.");
            newContact.LastName = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Please enter an E-mail address.");
            newContact.Email = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Please enter a street address.");
            newContact.Address = Console.ReadLine();
            Console.Clear();


            ContactService.AddContact(newContact);
            Console.Clear();
            Console.WriteLine("A new contact has been added. What would you like to do now?");
            break;

        case "2":
            Console.Clear();
            Console.WriteLine("Current contacts in your Address-Book");
            Console.WriteLine();
            ContactService.GetAllContacts();
            Console.WriteLine();
            Console.WriteLine("Press a key to continue");
            Console.ReadKey();
            Console.Clear();

            break;


        case "3":
            {
                Console.Clear();
                Console.WriteLine("Write the full name of one of your Contacts");
                ContactService.GetContactFromList(null!);
                Console.WriteLine("Press a key to continue");
                Console.ReadKey();
                Console.Clear();
                
                
            }      
            break;

        case "4":
            {
                Console.Clear();
                Console.WriteLine("Write the full name of the Contact you would like to delete");
                ContactService.RemoveContact(null!); 
               
            }
            break;
        case "e":
            Console.Clear();
            Console.WriteLine("Exiting Program...");
            isRunning= false;

            break;
        case "E":
            Console.Clear();
            Console.WriteLine("Exiting Program...");
            isRunning = false;

            break;

        default:
            Console.Clear();
            Console.WriteLine("invalid option, please state one of the valid options...");
            break;

    }
    
}


Console.WriteLine("Thank you for using my program! Bye!");
