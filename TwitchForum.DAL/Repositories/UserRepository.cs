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

        public User Add(User item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(User item)
        {
            throw new NotImplementedException();
        }

        public User GetById(string id)
        {
            return _forumContext.Users.FirstOrDefault(x => x.Id == id);
        }

        public User GetByName(string name)
        {
            return _forumContext.Users.FirstOrDefault(u => u.UserName == name);
        }

        public Task<IEnumerable<User>> GetN(int n)
        {
            throw new NotImplementedException();
        }

        public User Update(User item)
        {
            throw new NotImplementedException();
        }
    }
}