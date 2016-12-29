using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationASP
{
    public class PersonService : Service
    {
        // Returns a list of people to the user given a GetPeopleRequest (which is empty)
        public List<Person> Get(GetPeopleRequest request)
        {
            // Notice we’re passing “Db” as a parameter to PersonDataProvider,
            // this Db variable is provided by the IOC Container we set up in
            // the ApplicationHost.Configure method.
            PersonWorker pdp = new PersonWorker(Db);
            return pdp.GetPeopleList();
        }

        // Return a single person given their PersonID
        public Person Get(PersonIDRequest request)
        {
            PersonWorker pdp = new PersonWorker(Db);
            return pdp.GetPersonByID(request.PersonID);
        }

        // Creates a new Person
        public int Post(PersonRequest request)
        {
            var p = new Person()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                EmailAddress = request.EmailAddress
            };

            PersonWorker pdp = new PersonWorker(Db);
            return pdp.AddPerson(p);
        }

        // Updates an existing person
        public Person Put(PersonRequest request)
        {
            var p = new Person()
            {
                ID = request.PersonID,
                FirstName = request.FirstName,
                LastName = request.LastName,
                EmailAddress = request.EmailAddress
            };

            PersonWorker pdp = new PersonWorker(Db);
            return pdp.UpdatePerson(p);
        }

        // Deletes a person
        public void Delete(PersonIDRequest request)
        {
            PersonWorker pdp = new PersonWorker(Db);
            pdp.DeletePersonByID(request.PersonID);
        }
    }
}