namespace Contact_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] contact = NewContact();

            Console.WriteLine(contact[0] + " " + contact[1]);
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
            string[] Newcontact = new string[] { contact.Name, contact.phoneNumber };
            return Newcontact;
        }
        
    }   
}