using AwesomeLibrary.Requests;
using AwesomeLibrary.Services;
using FastEndpoints;

namespace AwesomeLibrary.Endpoints
{
    public class DeletePerson : Endpoint<DeleteRequest, EmptyResponse>
    {

        public IPersonRepository _personRepository { get; set; }

        public override void Configure()
        {
            Delete("/api/person/{Id}");
            AllowAnonymous();
        }

        public override Task HandleAsync(DeleteRequest req, CancellationToken ct)
        {
            _personRepository.Delete(req.Id);

            return base.HandleAsync(req, ct);
        }
    }
}
