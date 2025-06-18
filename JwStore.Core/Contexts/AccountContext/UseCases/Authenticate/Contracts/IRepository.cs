using JwStore.Core.Contexts.AccountContext.Entities;

namespace JwStore.Core.Contexts.AccountContext.UseCases.Authenticate.Contracts
{
    public interface IRepository
    {
          Task<User?> GetUserByEmailAsync(string email, CancellationToken cancellationToken);
    }
}