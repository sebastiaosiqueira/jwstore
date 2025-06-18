
using JwStore.Core.Contexts.AccountContext.Entities;
using JwStore.Core.Contexts.AccountContext.UseCases.Authenticate.Contracts;
using JwStore.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace JwStore.Infra.Context.AccountText.UseCases.Authenticate
{
    public class Repository : IRepository
    {
        private readonly AppDbContext _context;
        public Repository(AppDbContext context) => _context = context;
        public async Task<User?> GetUserByEmailAsync(string email, CancellationToken cancellationToken)=>
        
             await _context
            .Users
            .AsNoTracking()
            .Include(x => x.Roles)
            .FirstOrDefaultAsync(x => x.Email.Address == email, cancellationToken);
        
    }
}