using System.Net.Http.Headers;
using System.Runtime.InteropServices;

namespace Contact_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            List<string[]> AllContacts = new List<string[]>();
            
            while (!exit)
            {
                Console.WriteLine("Create new contact [1], Update a contact[2], Delete a contact [3], Search for a contact[4] or Exit [5]");
                string input = Console.ReadLine();
                if (input == "1")
                {
                    string[] aContact = NewContact();
                    AllContacts.Add(aContact);
                    Console.WriteLine(string.Format("Contact created with name {0} and phone number {1} ", AllContacts[AllContacts.Count - 1][0], AllContacts[AllContacts.Count - 1][1]));
                }
                else if (input == "2")
                {
                    Console.WriteLine("What is the name of the contact you want to update? ");
                    string toFind = Console.ReadLine();
                    int index = 0;
                    int index2 = 0;
                    bool found = false;
                    foreach (string[] contact in AllContacts)
                    {
                        Console.WriteLine(contact);
                        foreach (string entry in contact)
                        {

                            if (entry == toFind)
                            {

                                Console.WriteLine("Contact Found");
                                found = true;
                                break;
                            }
                            else
                                index2++;

                        }
                        if (found == false)
                            index++;




                    }
                    string[] updatedContact = UpdateContact(AllContacts[index][index2], AllContacts[index][index2 + 1]);
                    string[] ToUpdate = AllContacts[index];
                    AllContacts.Remove(ToUpdate);
                    AllContacts.Add(updatedContact);
                }
                else if (input == "3")
                {
                    Console.WriteLine("What is the name of the contact you want to delete? ");
                    string toFind = Console.ReadLine();
                    int index = 0;
                    int index2 = 0;
                    bool found = false;
                    foreach (string[] contact in AllContacts)
                    {
                        foreach (string entry in contact)
                        {

                            if (entry == toFind)
                            {

                                Console.WriteLine("Contact Found... Deleting....");
                                found = true;
                                break;
                            }
                            else
                                index2++;

                        }
                        if (found == false)
                            index++;

                    }
                    string[] ToDelete = AllContacts[index];
                    AllContacts.Remove(ToDelete);
                }
                else if (input == "4") 
                {
                    Console.WriteLine("What is the name or number of the contact you want to search for? ");
                    string toFind = Console.ReadLine();
                    int index = 0;
                    int index2 = 0;
                    bool found = false;
                    foreach (string[] contact in AllContacts)
                    {
                        
                        foreach (string entry in contact)
                        {
                            index2 = 0;
                            if (entry == toFind)
                            {

                                Console.WriteLine("Contact Found");
                                found = true;
                                if (index2 == 0)
                                break;
                            }
                            else
                                index2++;

                        }
                        if (found == false)
                            index++;
                    }
                    try
                    {
                        Console.WriteLine(string.Format("This contact has the name {0} and number {1}", AllContacts[index][0], AllContacts[index][1]))


                    }
                    catch (global::System.Exception)
                    {
                        Console.WriteLine("Contact not found")

                        
                    }
                    
                else if (input == "5")
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
            string contactName = "";
            string contactNumber = "";
            Console.WriteLine("What is this contact's name? ");
            contactName = Console.ReadLine();
            Console.WriteLine("What is this contact's phone number? ");
            contactNumber = Console.ReadLine();
            string[] newContact = new string[] {contactName, contactNumber}; 
            return newContact;
        }
        static string[] UpdateContact(string name, string number)
        {
            Console.WriteLine("Do you want to update the contact name? (Y/N) ");
            string YesNoInput = Console.ReadLine();
            YesNoInput = YesNoInput.ToUpper();
            if (YesNoInput == "Y")
                name = UpdateName(name);
            Console.WriteLine("Do you want to update the contact number? (Y/N) ");
            YesNoInput = Console.ReadLine();
            YesNoInput = YesNoInput.ToUpper();
            if (YesNoInput == "Y")
                number = UpdateNumber(number);
            static string UpdateName(string name)
            {
                Console.WriteLine("What is the new name of the contact? ");
                name = Console.ReadLine();
                return name;
            }
            static string UpdateNumber(string number)
            {
                Console.WriteLine("What is the new number of the contact? ");
                number = Console.ReadLine();
                return number;
            }
            string[] updatedContact = new string[] {name,number};
            return updatedContact;
        }
        
        
    }   
}