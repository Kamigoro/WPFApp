using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseTestWPF.Models
{
    public class PersonModel
    {
        private string firstName;
        private string lastName;
        private string email;


        public int Id { get; set; }
        public string FirstName 
        { 
            get { return firstName; }
            set 
            {
                if (value != "")
                {
                    firstName = value;
                }
                else
                {
                    throw new ArgumentNullException("FirstName");
                }
            }
        }
        public string LastName
        {
            get { return lastName; }
            set
            {
                if (value != "")
                {
                    lastName = value;
                }
                else
                {
                    throw new ArgumentNullException("LastName");
                }
            }
        }
        public string Email
        {
            get { return email; }
            set
            {
                if (value != "")
                {
                    email = value;
                }
                else
                {
                    throw new ArgumentNullException("Email");
                }
            }
        }

        public override string ToString()
        {
            return $"Prénom : {FirstName}, Nom : {LastName}, Email : {Email}";
        }
    }
}
