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
                Console.WriteLine("Create new contact [1], Update a contact[2], Delete a contact [3], or Exit [4]");
                string input = Console.ReadLine();
                if (input == "1") 
                {
                    int i = 0;
                    string[] aContact = NewContact();
                    AllContacts.Add(aContact);
                    Console.WriteLine(AllContacts);
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
                        //if (found == false)
                            //index++;
                        
                            
                        
                        
                    }
                    //string[] updatedContact = UpdateContact(AllContacts[index][index2], AllContacts[index][index2+1]);
                    //Console.WriteLine(AllContacts[index][index2]);
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
            string contactName = "";
            string contactNumber = "";
            ContactName(contactName);
            ContactNumber(contactNumber);
            static string ContactName(string contactName)
            {
                Console.WriteLine("What is this contact's name? ");
                contactName = Console.ReadLine();
                return contactName;
            }
            static string ContactNumber(string contactNumber)
            {
                Console.WriteLine("What is this contact's phone number? ");
                contactNumber = Console.ReadLine();
                return contactNumber;
            }
            string[] newContact = { contactName, contactNumber };
            Console.WriteLine(newContact);
            return newContact;
        }
        static string[] UpdateContact(string name, string number)
        {
            Console.WriteLine("Do you want to update the contact name? (Y/N) ");
            string YesNoInput = Console.ReadLine();
            if (YesNoInput == "Y")
                name = UpdateName(name);
            Console.WriteLine("Do you want to update the contact number? (Y/N) ");
            YesNoInput = Console.ReadLine();
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
            string[] updatedContact = {name,number};
            return updatedContact;
        }
    }   
}