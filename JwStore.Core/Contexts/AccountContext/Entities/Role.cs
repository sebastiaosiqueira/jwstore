

using JwStore.Core.AccountContext.Entities;
using JwStore.Core.Contexts.AccountContext.SharedContext.Entities;


namespace JwStore.Core.Contexts.AccountContext.Entities;

public class Role : Entity
{
    public string Name { get; set; } = string.Empty;

    public List<User> Users { get; set; } = new();
}