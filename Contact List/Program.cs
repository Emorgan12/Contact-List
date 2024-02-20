using System.Net.Http.Headers;

namespace Contact_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            string[,] AllContacts = new string[,] { };
            
            while (!exit)
            {
                Console.WriteLine("Create new contact [1], Update a contact[2], Delete a contact [3], or Exit [4]");
                string input = Console.ReadLine();
                if (input == "1") 
                {
                    int i = 0;
                    string[] contact = NewContact();
                    
                    

                    
                }
                else if (input == "2")
                {
                    Console.WriteLine("What is the name and number of the contact you want to update? ");
                    string toFind = Console.ReadLine();
                    int found;
                    foreach (string contact in AllContacts)
                    {
                        int index = 0;
                        if (contact == toFind)
                        {
                            found = index;
                            break;
                        }
                        else
                            index++;
                        Console.WriteLine(index);
                    }
                }
                else if (input == "3")
                {

                }
                else if (input == "4")
                {
                    exit = true;
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
                    
            }
            
            Console.ReadKey();
        }
        static string[] NewContact()
        {
            Contact contact = new Contact();
            ContactName(contact);
            ContactNumber(contact);
            static string ContactName(Contact contact)
            {
                Console.WriteLine("What is this contact's name? ");
                contact.Name = Console.ReadLine();
                return contact.Name;
            }
            static string ContactNumber(Contact contact)
            {
                Console.WriteLine("What is this contact's phone number? ");
                contact.phoneNumber = Console.ReadLine();
                return contact.phoneNumber;
            }
            string[] newContact = { contact.Name, contact.phoneNumber };
            return newContact;
        }
        static string[] UpdateContact(Contact contact)
        {
            Console.WriteLine("Do you want to update the contact name? (Y/N) ");
            string YesNoInput = Console.ReadLine();
            if (YesNoInput == "Y")
                contact.Name = UpdateName(contact);
            Console.WriteLine("Do you want to update the contact number? (Y/N) ");
            YesNoInput = Console.ReadLine();
            if (YesNoInput == "Y")
                contact.phoneNumber = UpdateNumber(contact);
            static string UpdateName(Contact contact)
            {
                Console.WriteLine("What is the new name of the contact? ");
                contact.Name = Console.ReadLine();
                return contact.Name;
            }
            static string UpdateNumber(Contact contact)
            {
                Console.WriteLine("What is the new number of the contact? ");
                contact.phoneNumber = Console.ReadLine();
                return contact.phoneNumber;
            }
            string[] updatedContact = { contact.Name, contact.phoneNumber };
            return updatedContact;
        }
    }   
}