using AwesomeLibrary.Requests;
using AwesomeLibrary.Responses;
using AwesomeLibrary.Services;
using FastEndpoints;

namespace AwesomeLibrary.Endpoints;

public class PostPerson : Endpoint<CreatePerson, PostPersonResponse>
{

    public IPersonRepository _personRepository { get; set; }

    public override void Configure()
    {
        Post("/api/person");
        AllowAnonymous();
    }

    public override async Task HandleAsync(CreatePerson req, CancellationToken ct)
    {
        Entities.Person createPersonResponse = _personRepository.Insert(req);

        await SendAsync(new PostPersonResponse
        {
            Id = createPersonResponse.Id,
            Name = createPersonResponse.Name,
            Age = createPersonResponse.Age,
        });
    }
}
