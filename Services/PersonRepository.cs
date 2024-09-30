using AwesomeLibrary.Entities;
using AwesomeLibrary.Requests;
using System.Collections.ObjectModel;

namespace AwesomeLibrary.Services
{
    public class PersonRepository : IPersonRepository
    {

        private List<Person> _people = [new() { Age = 39, Name = "Renyo", Id = 1}];
        private int Id = 0;

        public void Delete(int personId)
        {
            var person = _people.First(x => x.Id == personId);
            _people.Remove(person);
        }

        public ReadOnlyCollection<Person> Get() => _people.AsReadOnly();

        public Person Get(int id) => _people.First(x => x.Id == id);

        public Person Insert(CreatePerson person)
        {
            var next = _people.Last().Id;
            Person item = new()
            {
                Id = ++next,
                Age = person.Age,
                Name = person.Name,
            };
            _people.Add(item);

            return item;
        }
    }
}
