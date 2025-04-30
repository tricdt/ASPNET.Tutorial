using System;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace Tedu.KnowledgeSpace.BackendServer.Services;

public class EmailSenderService : IEmailSender
{
    public Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        throw new NotImplementedException();
    }
}
