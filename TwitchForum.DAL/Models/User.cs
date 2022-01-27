using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TwitchForum.DAL.Models
{
    public class User : IdentityUser
    {
        public User()
        {
            Messages = new HashSet<Message>();
            Answers = new List<Answer>();
            Discussions = new List<Discussion>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
        public virtual ICollection<Discussion> Discussions { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Обратите внимание, что authenticationType должен совпадать с типом, определенным в CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Здесь добавьте утверждения пользователя
            return userIdentity;
        }
    }
}