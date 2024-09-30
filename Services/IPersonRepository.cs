using AwesomeLibrary.Entities;
using AwesomeLibrary.Requests;
using System.Collections.ObjectModel;

namespace AwesomeLibrary.Services
{
    public interface IPersonRepository
    {
        Person Get(int id);
        ReadOnlyCollection<Person> Get();
        void Delete(int personId);
        Person Insert (CreatePerson person);
    }
}
