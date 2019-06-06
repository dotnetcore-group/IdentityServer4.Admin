using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IdentityServer4.Admin.BuildingBlock.Email
{
    public interface IEmailSender
    {
        Task SendEmailConfirmationAsync(string email, string callbackUrl);
    }
}
