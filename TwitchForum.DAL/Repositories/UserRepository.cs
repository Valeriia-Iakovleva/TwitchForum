using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchForum.DAL.Models;
using TwitchForum.DAL.Repositories.Interfaces;

namespace TwitchForum.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ForumContext _forumContext;

        public UserRepository(ForumContext forumContext)
        {
            _forumContext = forumContext;
        }

        public async Task<bool> Delete(User item)
        {
            _forumContext.Users.Remove(item);

            return await _forumContext.Users.FirstOrDefaultAsync(x => x == item) == null;
        }

        public User GetById(string id)
        {
            return _forumContext.Users.FirstOrDefault(x => x.Id == id);
        }

        public User GetByName(string name)
        {
            return _forumContext.Users.FirstOrDefault(u => u.UserName == name);
        }

        public IEnumerable<User> GetN(int n)
        {
            return _forumContext.Users.Take(n);
        }

        public IEnumerable<User> GetAll()
        {
            return _forumContext.Users.ToList();
        }

        public User Update(User item)
        {
            var user = _forumContext.Users.Attach(item);

            _forumContext.Entry(item).State = EntityState.Modified;

            _forumContext.SaveChanges();

            return user;
        }
    }
}