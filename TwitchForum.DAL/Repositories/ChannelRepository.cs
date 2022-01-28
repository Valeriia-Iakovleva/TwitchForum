using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchForum.DAL.Models;
using TwitchForum.DAL.Repositories.Interfaces;

namespace TwitchForum.DAL.Repositories
{
    public class ChannelRepository : IChannelRepository
    {
        private readonly ForumContext _forumContext;

        public ChannelRepository(ForumContext forumContext)
        {
            _forumContext = forumContext;
        }

        public Channel Add(Channel item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Channel item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Channel> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Channel> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Channel> GetN(int n)
        {
            return _forumContext.Channels.Take(n);
        }

        public Channel Update(Channel item)
        {
            throw new NotImplementedException();
        }
    }
}