using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace FPDF.User_Util
{
    internal class User
    {   
        /*--Fields--*/

        /*Class Fields*/
        private static string name;
        private static string surname;
        private static string email;
        private static string number;

        /*Singleton pattern*/
        private static User user = null;

        /*Builder*/
        private User(string Email, string Name = null, string Surname = null, string Number = null) 
        {
            name = Name;
            surname = Surname;
            number = Number;
            email = Email;
        }

        /*Singleton patern*/
        public static User getUser(string Email, string Name = null, string Surname = null, string Number = null)
        {
            if (user == null)
            {
                user = new User(Email, Name, Surname, Number);
            }
            return user;
        }

        public static User getUser() 
        {
            return user;
        }

        /*--Retrieve fields--*/

        /*Get name*/
        public string getName() 
        {
            if (name == null)
            {
                throw new Exception("Name is not available");
            }
            else 
            { 
                return name;
            }
        }

        /*Get surname*/
        public string getSurname() 
        {
            if (surname == null)
            {
                throw new Exception("Surname is not available");
            }
            else 
            { 
                return surname;
            }
        }

        /*Get mail*/
        public string getMail() 
        { 
            return email;
        }

        /*Get number*/
        public string getNumber() 
        {
            if (number == null)
            {
                throw new Exception("Number is not available");
            }
            else
            {
                return number;
            }
        }

        /*get Integer number*/
        public int getIntNumber() 
        {
            if (number == null)
            {
                throw new Exception("Number is not available");
            }
            else
            {
                return int.Parse(number);
            }
        }

        /*Obtain all name*/
        public string obtainName() 
        {
            if (name == null && surname == null && number == null)
            {
                return "Anonymous";
            }
            else 
            {

                if (name == null && surname == null && number != null)
                {
                    return "Personale number: " + number;
                }
                else 
                {
                    if (name == null && surname != null)
                    {
                        return surname;
                    }
                    else 
                    {
                        if (name != null && surname != null)
                        {
                            return name + " " + surname;
                        }
                        else 
                        {
                            if (name != number)
                            {
                                return name;
                            }
                            else
                            {
                                throw new Exception("Error to obtain user name");
                            }
                        }
                    }
                }
            }
        }
        
    }
}
