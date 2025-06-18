using MediatR;

namespace JwStore.Core.Contexts.AccountContext.UseCases.Authenticate
{
    public record Request(
        string Name,
        string Email,
        string Password

    ) : IRequest<Response>;
}