using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;

namespace TwitchForum.BLL.AcountsServices
{
    public class SmsService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Подключите здесь службу SMS, чтобы отправить текстовое сообщение.
            return Task.FromResult(0);
        }
    }
}