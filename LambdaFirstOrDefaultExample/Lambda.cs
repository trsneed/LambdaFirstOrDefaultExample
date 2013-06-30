using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaFirstOrDefaultExample
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void FirstOrDefaultExample()
        {
            var people = new People().Persons;

            var tim = people.Where(p => p.PersonId == 1).FirstOrDefault();
            var timNew = people.FirstOrDefault(p => p.PersonId == 1);

            var jack = people.Where(p => p.FirstName == "Jack").Single();
            var jackNew = people.Single(p => p.FirstName == "Jack");

            Assert.AreEqual(tim, timNew);
            Assert.AreEqual(jack, jackNew);
        }
    }

    public class People
    {
        public List<Person> Persons { get; set; }

        public People()
        {
            Persons = new List<Person>();

            Persons.Add(Person.CreatePerson(1, "Tim", "Sneed"));
            Persons.Add(Person.CreatePerson(2, "Dirk", "Pitt"));
            Persons.Add(Person.CreatePerson(3, "Jack", "Ryan"));
            Persons.Add(Person.CreatePerson(4, "Mitch", "Rapp"));
            Persons.Add(Person.CreatePerson(5, "Thomas", "Jefferson"));

        }
    }

    public class Person
    {
        public int PersonId { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        private Person()
        {

        }

        public static Person CreatePerson(int personId, string firstName, string LastName)
        {
            return new Person() { FirstName = firstName, LastName = LastName, PersonId = personId };
        }
    }
}
