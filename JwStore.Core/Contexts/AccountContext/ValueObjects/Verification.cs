


using JwStore.Core.Contexts.SharedContext.ValueObjects;

namespace JwStore.Core.AccountContext.ValueObjects
{
    public class Verification : ValueObject
    {
        public Verification()
        {
            
        }
        public string Code { get; } = Guid.NewGuid().ToString("N")[..6].ToUpper();
        public DateTime? ExpiresAt { get; private set; } = DateTime.UtcNow.AddMinutes(5);
        public DateTime? VerifieAt { get; private set; } = null;
        public bool IsActive => VerifieAt != null && ExpiresAt == null;
        public void Verify(string code)
        {
            if (IsActive)
                throw new Exception("Este item ja fi ativado");
            if (ExpiresAt < DateTime.UtcNow)
                throw new Exception("Este código já expirou");
            if (!string.Equals(code.Trim(), Code.Trim(), StringComparison.CurrentCultureIgnoreCase))
                throw new Exception("Codigo verificação inválido");

            ExpiresAt = null;
            VerifieAt = DateTime.UtcNow;
        }
        
    }
}