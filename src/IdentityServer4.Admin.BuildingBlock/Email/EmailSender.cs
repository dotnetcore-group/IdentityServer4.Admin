using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Admin.BuildingBlock.Email
{
    public class EmailSender : IEmailSender
    {
        private readonly ILogger<EmailSender> _logger;
        public EmailSender(ILogger<EmailSender> logger)
        {
            _logger = logger;
        }

        public Task SendEmailConfirmationAsync(string email, string callbackUrl)
        {
            _logger.LogDebug($"{email} : {callbackUrl}");
            return Task.CompletedTask;
        }
    }
}
