using AwesomeLibrary.Requests;
using AwesomeLibrary.Responses;
using AwesomeLibrary.Services;
using FastEndpoints;

namespace AwesomeLibrary.Endpoints;

public class GetPersonById : EndpointWithoutRequest<GetPersonResponse>
{
    public IPersonRepository _personRepository { get; set; }

    public override void Configure()
    {
        Get("/api/person/{id}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var id = Route<int>("id");

        Entities.Person person = _personRepository.Get(id);

        await SendAsync(
            new GetPersonResponse 
            { 
                Id = id,
                Age = person.Age,
                Name = person.Name,
            });
    }
}
