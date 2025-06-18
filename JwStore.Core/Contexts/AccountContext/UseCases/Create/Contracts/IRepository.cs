using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JwStore.Core.Contexts.AccountContext.Entities;


namespace JwStore.Core.Contexts.AccountContext.UseCases.Create.Contracts
{
    public interface IRepository
    {
        Task<bool> AnyAsync(string email, CancellationToken cancellationToken);
        Task SaveAsync(User user, CancellationToken cancellationToken);
    }
}