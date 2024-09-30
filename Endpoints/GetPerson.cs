using FastEndpoints;
using AwesomeLibrary.Entities;
using AwesomeLibrary.Requests;
using AwesomeLibrary.Responses;
using AwesomeLibrary.Services;
using System.Collections.ObjectModel;

namespace AwesomeLibrary.Endpoints;

public class GetPerson : Endpoint<GetPersonRequest, List<GetPersonResponse>>
{

    public IPersonRepository _personRepository { get; set; }

    public override void Configure()
    {
        Get("/api/person");
        AllowAnonymous();
    }

    public override async Task HandleAsync(GetPersonRequest req, CancellationToken ct)
    {

        ReadOnlyCollection<Person> persons = _personRepository.Get();

        List<GetPersonResponse> result = persons.Select(x => new GetPersonResponse
        {
            Id = x.Id,
            Age = x.Age,
            City = "",
            Name = x.Name,
        }).ToList();


        await SendAsync(result);
        
    }
}
