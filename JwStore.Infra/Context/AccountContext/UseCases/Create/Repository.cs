using JwStore.Core.Contexts.AccountContext.Entities;
using JwStore.Core.Contexts.AccountContext.UseCases.Create.Contracts;
using JwStore.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace JwStore.Infra.Context.AccountContext.UseCases.Create
{
    public class Repository : IRepository
    {
        private readonly AppDbContext _context;
        public Repository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> AnyAsync(string email, CancellationToken cancellationToken)
        => await _context.Users.AsNoTracking().AnyAsync(x => x.Email == email);
        public async Task SaveAsync(User user, CancellationToken cancellationToken)
        {
            await _context.Users.AddAsync(user, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
           
        }
    }
}