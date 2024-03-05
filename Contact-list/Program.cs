using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;

namespace Contact_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            List<List<string>> AllContacts = new List<List<string>>();

            while (!exit)
            {
                Console.WriteLine("Create new contact [1], Update a contact[2], Delete a contact [3], Search for a contact[4], See all contacts[5] or Exit [6]");
                string input = Console.ReadLine();
                if (input == "1")
                {
                    List<string> aContact = NewContact();
                    AllContacts.Add(aContact);
                    Console.WriteLine(string.Format("Contact created with name {0} and phone number {1} ", AllContacts[AllContacts.Count - 1][0], AllContacts[AllContacts.Count - 1][1]));
                }
                else if (input == "2")
                {
                    List<string> updatedContact = UpdateContact(AllContacts);
                    int index = int.Parse(updatedContact.Last());
                    AllContacts.RemoveAt(index);
                    updatedContact.RemoveAt(updatedContact.Count-1);
                    AllContacts.Add(updatedContact);
                }
                else if (input == "3")
                {
                    List<string> ToDelete = DeleteContact(AllContacts);
                    if (ToDelete == null)
                        Console.WriteLine("No contact was deleted");
                    else
                    {
                        int index = int.Parse(ToDelete[0]);
                        AllContacts.Remove(AllContacts[index]);
                        Console.WriteLine("Contact deleted successfully");
                    }

                }
                else if (input == "4")
                {
                    SearchContact(AllContacts);
                }
                else if (input == "5")
                {
                    OutputAllContacts(AllContacts);
                }
                else if (input == "6")
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
        static List<string> NewContact()
        {
            bool created = false;
            while (!created)
            {
                string contactName = "";
                string contactNumber = "";
                long ignoreMe = 0;
                Console.WriteLine("What is this contact's name? ");
                contactName = Console.ReadLine();
                bool invalidLength = true;
                while (invalidLength) 
                {
                    Console.WriteLine("What is this contact's phone number? ");
                    contactNumber = Console.ReadLine();
                    bool isDigit = long.TryParse(contactNumber, out ignoreMe);
                    if (isDigit == false)
                    {
                        Console.WriteLine("Phone number must be numerical");
                       
                    }
                        
                    else if (contactNumber.Length != 11)
                    {
                        Console.WriteLine("Invalid phone number, must be 11 digits long");
                        
                    }
                    else
                        invalidLength = false;
                }
                Console.WriteLine(string.Format("Name: {0}, Phone Number: {1}, is this correct? (Y/N)", contactName, contactNumber));
                string input = Console.ReadLine();
                input = input.ToUpper();
                bool invalidInput = true;
                while (invalidInput == true)
                {
                    if (input == "Y")
                    {
                        List<string> newContact = new List<string> { contactName, contactNumber };
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

        static List<string> UpdateContact(List<List<string>> contactList)
        {
            static List<string> FindContactU(List<List<string>> contactList)
            {
                bool found = false;
                while (!found)
                {
                    Console.WriteLine("What is the name or number of the contact you want to update? ");
                    string toFind = Console.ReadLine();
                    int index = 0;
                    int index2 = 0;
                    foreach (List<string> contact in contactList)
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
                                List<string> toUpdate = new List<string> {name, number, sIndex };
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

            List<string> toUpdate = FindContactU(contactList);
            List<string> updatedContact = new List<string>();
            List<string> newInfo = new List<string>();
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
            invalidInput = true;
            while (invalidInput == true)
            {
                int runs = 0;
                Console.WriteLine("Do you want to add additional information? (Y/N) ");
                string input = Console.ReadLine();
                input = input.ToUpper();
                if (input == "Y")
                {
                    newInfo = AddInformation(toUpdate);
                    invalidInput = false;
                }
                else if (input == "N")
                    invalidInput = false;
                else
                {
                    Console.WriteLine("Invalid input");
                }
            }
            static List<string> AddInformation(List<string> contact)
            {
                bool updated = false;
                while (!updated)
                {
                    bool emptyInput = true;
                    while (emptyInput)
                    {
                        Console.WriteLine("What do you want to add? ");
                        string info = Console.ReadLine();
                        Console.WriteLine(string.Format("What is your contact's {0}? ", info));
                        string content = Console.ReadLine();
                        if (info == string.Empty || content == string.Empty)
                        {
                            Console.WriteLine("Info or content cannot be empty");
                        }
                        else
                        {
                            bool invalidInput = true;
                            while (invalidInput)
                            {
                                Console.WriteLine(string.Format("This contact will have a {0} {1}, is this correct? (Y/N)", info, content));
                                string input = Console.ReadLine();
                                input = input.ToUpper();
                                if (input == "Y")
                                {
                                    updated = true;
                                    invalidInput = false;
                                    List<string> newInfo = new List<string> { info, content };
                                    return newInfo;
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
                bool invalidLength = true;
                bool updated = false;
                long ignoreMe = 0;
                while (!updated)
                {
                    bool emptyInput = true;
                    while (emptyInput)
                    {
                        while (invalidLength)
                        {
                            Console.WriteLine("What is this contact's phone number? ");
                            number = Console.ReadLine();
                            bool isDigit = long.TryParse(number, out ignoreMe);
                            if (isDigit == false)
                            {
                                Console.WriteLine("Phone number must be numerical");

                            }

                            else if (number.Length != 11)
                            {
                                Console.WriteLine("Invalid phone number, must be 11 digits long");

                            }
                            else if (number == string.Empty)
                                Console.WriteLine("Number cannot be empty");
                            else
                            {
                                invalidLength = false;
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
                    
                }
               
                return null;
            }
            string sIndex = realIndex.ToString();
            updatedContact.Add(name);
            updatedContact.Add(number);
            try
            {
                updatedContact.Add(newInfo[0]);
                updatedContact.Add(newInfo[1]);
            }
            catch (Exception ex)
            {
                Console.WriteLine("No additional information added");
            }
            updatedContact.Add(sIndex);
            return updatedContact;
        }
        static List<string> DeleteContact(List<List<string>> ContactList)
        {
            static List<string> FindContactD(List<List<string>> contactList)
            {

                bool found = false;
                while (!found)
                {
                    Console.WriteLine("What is the name or number of the contact you want to delete? ");
                    string toFind = Console.ReadLine();
                    int index = 0;
                    int index2 = 0;
                    foreach (List<string> contact in contactList)
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
                                List<string> toDelete = new List<string> { name, number, sIndex };
                                return toDelete;


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
            List<string> toDelete = FindContactD(ContactList);
            string index = toDelete[2];
            int realIndex = int.Parse(index);

            bool invalidInput = true;
            while (invalidInput)
            {
                Console.WriteLine(string.Format("Contact with name: {0} and number: {1} will be deleted, are you sure?(Y/N)", ContactList[realIndex][0], ContactList[realIndex][1]));
                string input = Console.ReadLine();
                input = input.ToUpper();
                if (input == "Y")
                {

                    invalidInput = false;
                    string sRealIndex = realIndex.ToString();
                    List<string> ToDelete = new List<string> { sRealIndex };
                    return ToDelete;
                }
                else if (input == "N")
                    invalidInput = false;

                else
                {
                    Console.WriteLine("Invalid input");

                }
            }
            return toDelete;

        }
        static void SearchContact(List<List<string>> contactList)
        {
            bool found = false;

            Console.WriteLine("What is the name or number of the contact you want to search for? ");
            string toFind = Console.ReadLine();
            int index = 0;
            int index2 = 0;
            foreach (List<string> contact in contactList)
            {
                foreach (string entry in contact)
                {

                    if (entry == toFind)
                    {
                        List<string> Wcontact = contact;
                        Console.WriteLine("Information linked to this contact:");
                        found = true;
                            foreach (string Wentry in Wcontact)
                            {
                                Console.WriteLine(Wentry);
                            }
                        
                    }

                    else
                        index2++;

                }
                if (!found)
                    index++;
            }
            if (!found) 
            {
                Console.WriteLine("Contact not found");
            }
        }   
        static void OutputAllContacts(List<List<string>> contactList)
        {
            foreach (List<string> contact in contactList)
            {
                foreach (string entry in contact)
                {
                    Console.WriteLine(entry);
                }

            }
        }
    }
}
        
        

    