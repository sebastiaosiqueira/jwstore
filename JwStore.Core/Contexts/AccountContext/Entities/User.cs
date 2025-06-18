
using JwStore.Core.Contexts.AccountContext.Entities;
using JwStore.Core.Contexts.AccountContext.SharedContext.Entities;
using JwStore.Core.Contexts.AccountContext.ValueObjects;


namespace JwStore.Core.Contexts.AccountContext.Entities
{
    public class User : Entity
    {
        protected User()
        {

        }
        public User(string name, Email email, Password password)
        {
            Name = name;
            Email = email;
            Passowrd = password;
        }
        public User(string email, string? password = null)
        {
            Email = email;
            Passowrd = new Password(password);
        }
        public User(string name, Password passowrd) 
        {
            Name = name;
           Passowrd = passowrd;
   
        }
        public string Name { get; private set; } = string.Empty;
        public Email Email { get; set; } = null!;
        public Password Passowrd { get; private set; } = null!;
        public string Image { get; private set; } = string.Empty;
          public List<Role> Roles { get; set; } = new();

        public void UpdatePassword(string plainTextPassword, string code)
        {
            if (!string.Equals(code.Trim(), Passowrd.ResetCode.Trim(), StringComparison.CurrentCultureIgnoreCase))

                throw new Exception("Codigo de restauração inválido");

            var password = new Password(plainTextPassword);
            Passowrd = password;

        }

        public void UpdateEmail(Email email)
        {
            Email = email;
        }
        public void ChangePassword(string plainTextPassowrd)
        {
            var password = new Password(plainTextPassowrd);
            Passowrd = password;
        }
        
    }
}