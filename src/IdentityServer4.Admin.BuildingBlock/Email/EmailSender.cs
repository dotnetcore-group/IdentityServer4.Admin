using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Admin.BuildingBlock.Email
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailConfirmationAsync(string email, string callbackUrl)
        {
            return Task.CompletedTask;
        }
    }
}
