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
                    string[] updatedContact = UpdateContact(AllContacts);
                    int index = int.Parse(updatedContact[2]);
                    string[] ToUpdate = AllContacts[index];
                    AllContacts.Remove(ToUpdate);
                    updatedContact = new string[] { updatedContact[0], updatedContact[1] };
                    AllContacts.Add(updatedContact);
                }
                else if (input == "3")
                {
                    string[] ToDelete = DeleteContact(AllContacts);

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
                        Console.WriteLine(string.Format("This contact has the name {0} and number {1}", AllContacts[index][0], AllContacts[index][1]));


                    }
                    catch (global::System.Exception)
                    {
                        Console.WriteLine("Contact not found");
                    }
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
                bool created = false;
                while (!created)
                {
                    string contactName = "";
                    string contactNumber = "";
                    Console.WriteLine("What is this contact's name? ");
                    contactName = Console.ReadLine();
                    Console.WriteLine("What is this contact's phone number? ");
                    contactNumber = Console.ReadLine();
                    Console.WriteLine(string.Format("Name: {0}, Phone Number: {1}, is this correct? (Y/N)", contactName, contactNumber));
                    string input = Console.ReadLine();
                    input = input.ToUpper();
                bool invalidInput = true;  
                while (invalidInput == true)
                {
                    if (input == "Y")
                    {
                        string[] newContact = new string[] { contactName, contactNumber };
                        created = true;
                        invalidInput = false;
                        return newContact;

                    }
                    else if (input == "N")
                    {
                        created = false;
                        invalidInput = false;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input");
                        input = Console.ReadLine();
                        input = input.ToUpper();
                    }
                        
                }
                    


                }
                return null;
            }

        static string[] UpdateContact(List<string[]> contactList)
        {
            static string[] FindContact(List<string[]> contactList) {
            bool found = false;
                while (!found)
                {
                    Console.WriteLine("What is the name of the contact you want to update? ");
                    string toFind = Console.ReadLine();
                    int index = 0;
                    int index2 = 0;
                    foreach (string[] contact in contactList)
                    {
                        foreach (string entry in contact)
                        {

                            if (entry == toFind)
                            {

                                Console.WriteLine("Contact Found");
                                found = true;
                                string name = contactList[index][0];
                                string number = contactList[index][1];
                                string sIndex = index.ToString();
                                string[] toUpdate = new string[] { name, number, sIndex };
                                return toUpdate;


                            }
                            else
                                index2++;

                        }
                        if (!found)
                            index++;




                    }
                    if (!found)
                        Console.WriteLine("Contact not found");
                }
                return null;
        }
            
            string[] toUpdate = FindContact(contactList);
            string name = toUpdate[0];
            string number = toUpdate[1];
            string index = toUpdate[2];
            int realIndex = int.Parse(index);
            bool invalidInput = true;
            while (invalidInput == true)
            { 
                Console.WriteLine("Do you want to update the contact name? (Y/N) ");
                string input = Console.ReadLine();
                input = input.ToUpper();
            
            
                if (input == "Y")
                {
                    name = UpdateName(name);
                    invalidInput = false;
                }

                else if (input == "N")
                    invalidInput = false;
                else
                {
                    Console.WriteLine("Invalid input");
                }
            }
            invalidInput = true;
            while (invalidInput == true)
            {
                Console.WriteLine("Do you want to update the contact number? (Y/N) ");
                string input = Console.ReadLine();
                input = input.ToUpper();
                if (input == "Y")
                {
                    number = UpdateNumber(number);
                    invalidInput = false;
                }
                else if (input == "N")
                    invalidInput = false;
                else
                {
                    Console.WriteLine("Invalid input");
                }
            }
            
            static string UpdateName(string name)
                {
                bool updated = false;
                while (!updated) 
                {
                    bool emptyInput = true;
                    while (emptyInput) 
                    {
                        Console.WriteLine("What is the new name of the contact? ");
                        name = Console.ReadLine();
                            if (name == string.Empty)
                            {
                                Console.WriteLine("Name cannot be empty");
                            }
                            else
                            {
                                bool invalidInput = true;
                                while (invalidInput)
                                {
                                    Console.WriteLine(string.Format("This contact will be named {0}, is this correct? (Y/N)", name));
                                    string input = Console.ReadLine();
                                    input = input.ToUpper();
                                    if (input == "Y")
                                    {
                                        updated = true;
                                        invalidInput = false;
                                        return name;
                                    }
                                    else if (input == "N")
                                        invalidInput = false;
                                    else
                                    {
                                        Console.WriteLine("Invalid input");
                                        
                                    }
                                }

                            }
                        }
                    
                    }
                return null;
                }
                static string UpdateNumber(string number)
                {
                    bool updated = false;
                    while (!updated)
                    {
                        bool emptyInput = true;
                        while (emptyInput)
                        {
                            Console.WriteLine("What is the new number of the contact? ");
                            number = Console.ReadLine();
                            if (number == string.Empty)
                            {
                                Console.WriteLine("Number cannot be empty");
                            }
                            else
                            {
                                bool invalidInput = true;
                                while (invalidInput)
                                {
                                    Console.WriteLine(string.Format("This contact's number will be {0}, is this correct? (Y/N)", number));
                                    string input = Console.ReadLine();
                                    input = input.ToUpper();
                                    if (input == "Y")
                                    {
                                        updated = true;
                                        invalidInput = false;
                                        return number;
                                    }
                                    else if (input == "N")
                                        invalidInput = false;
                                    else
                                    {
                                        Console.WriteLine("Invalid input");

                                    }
                                }

                            }
                        }

                    }
                    return null;
            }
               
                string sIndex = realIndex.ToString();
                string[] updatedContact = new string[] {name, number, sIndex};
                return updatedContact;
            }
        static string[] DeleteContact(List<string[]> ContactList)
        {
            Console.WriteLine("What is the name of the contact you want to delete? ");
            string toFind = Console.ReadLine();
            int index = 0;
            int index2 = 0;
            bool found = false;
            foreach (string[] contact in ContactList)
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
            string[] ToDelete = new string[] { ContactList[index][0], ContactList[index][1]};
            return ToDelete;
        }

        }
        }
    
