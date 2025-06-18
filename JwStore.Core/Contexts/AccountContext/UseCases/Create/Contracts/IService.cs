using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JwStore.Core.Contexts.AccountContext.Entities;


namespace JwStore.Core.Contexts.AccountContext.UseCases.Create.Contracts
{
    public interface IService
    {
        Task SendVerificationEmailAsync(User user, CancellationToken cancellationToken);
        
    }
}