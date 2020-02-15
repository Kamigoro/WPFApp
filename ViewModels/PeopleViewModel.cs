using DatabaseTestWPF.DataAccess;
using DatabaseTestWPF.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseTestWPF.ViewModels
{
    public class PeopleViewModel
    {

        public PeopleViewModel()
        {

        }

        public List<PersonModel> GetAllPeopleInDB()
        {
            using (var database = new DataAccessor())
            {
                return database.People.ToList();
            }     
        }

        public void AddPersonInDB(string firstName, string lastName, string email)
        {
            PersonModel person = new PersonModel() { FirstName = firstName, LastName = lastName, Email = email };
            using (var database = new DataAccessor())
            {
                database.People.Add(person);
                database.SaveChanges();
            }    
        }

        public void DeletePersonInDB(int personId)
        {
            using(var database = new DataAccessor())
            {
                PersonModel personToDelete = database.People.Where(person => person.Id == personId).First();
                database.People.Remove(personToDelete);
                database.SaveChanges();
            } 
        }

        public void DeleteAllPeopleInDB()
        {
            using (var database = new DataAccessor())
            {
                foreach (PersonModel person in GetAllPeopleInDB())
                {
                    database.People.Remove(person);
                }
                database.SaveChanges();
            }
        }
    }
}
