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

        public bool Delete(Channel item)
        {
            _forumContext.Channels.Remove(item);
            return _forumContext.Channels.Contains(item);
        }

        public IEnumerable<Channel> GetAll()
        {
            return _forumContext.Channels.ToList();
        }

        public Channel GetById(int id)
        {
            return _forumContext.Channels.FirstOrDefault(x => x.Id == id);
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