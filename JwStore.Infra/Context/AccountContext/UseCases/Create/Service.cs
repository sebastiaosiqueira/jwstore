using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JwStore.Core;
using JwStore.Core.Contexts.AccountContext.Entities;
using JwStore.Core.Contexts.AccountContext.UseCases.Create.Contracts;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace JwStore.Infra.Context.AccountContext.UseCases.Create
{
    public class Service : IService
    {
        public async Task SendVerificationEmailAsync(User user, CancellationToken cancellationToken)
        {
                  var client = new SendGridClient(Configuration.SendGrid.ApiKey);
        var from = new EmailAddress(Configuration.Email.DefaultFromEmail, Configuration.Email.DefaultFromName);
        const string subject = "Verifique sua conta";
        var to = new EmailAddress(user.Email, user.Name);
        var content = $"Código {user.Email.Verification.Code}";
        var msg = MailHelper.CreateSingleEmail(from, to, subject, content, content);
        await client.SendEmailAsync(msg, cancellationToken);

        }
    }
}