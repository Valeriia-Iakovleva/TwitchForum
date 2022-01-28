using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchForum.DAL.Models;
using TwitchForum.DAL.Repositories.Interfaces;

namespace TwitchForum.DAL.Repositories
{
    public class DiscussionRepository : IDiscussionRepository
    {
        public Discussion Add(Discussion item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Discussion item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Discussion> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Discussion> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Discussion>> GetN(int n)
        {
            throw new NotImplementedException();
        }

        public Discussion Update(Discussion item)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Discussion> IRepository<Discussion>.GetN(int n)
        {
            throw new NotImplementedException();
        }
    }
}