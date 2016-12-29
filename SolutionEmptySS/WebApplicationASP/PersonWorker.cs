using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationASP
{
    public class PersonWorker
    {
        // The IDbConnection passed in from the IOC container on the service
        System.Data.IDbConnection _dbConnection;

        // Store the database connection passed in
        public PersonWorker(System.Data.IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        // Inserts a new row into the Person table
        public int AddPerson(Person p)
        {
            return (int)_dbConnection.Insert<Person>(p, selectIdentity: true);
        }

        // Return a list of people from our DB
        // (this is the equivilent of “SELECT * FROM Person”)
        public List<Person> GetPeopleList()
        {
            return _dbConnection.Select<Person>();
        }

        // Return a single person given their ID
        public Person GetPersonByID(int id)
        {
            return _dbConnection.SingleById<Person>(id);
        }

        // Updates a row in the Person table. Note that this call updates
        // all fields, in order to update only certain fields using OrmLite,
        // use an anonymous type like the below line, which would only
        // update the FirstName and LastName fields:
        // _dbConnection.Update(new { FirstName = “Gene”, LastName = “Rayburn” });
        public Person UpdatePerson(Person p)
        {
            _dbConnection.Update<Person>(p);
            return p;
        }

        // Deletes a row from the Person table
        public int DeletePersonByID(int id)
        {
            return _dbConnection.Delete(id);
        }
    }
}