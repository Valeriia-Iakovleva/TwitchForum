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
    public class ChannelRepository : IChannelRepository
    {
        private readonly ForumContext _forumContext;

        public ChannelRepository(ForumContext forumContext)
        {
            _forumContext = forumContext;
        }

        public Channel Add(Channel item)
        {
            _forumContext.Channels.Add(item);

            _forumContext.SaveChanges();

            return _forumContext.Channels.FirstOrDefault(x => x == item);
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

        public Channel Get(Channel channel)
        {
            return _forumContext.Channels.Find(channel);
        }

        public Channel Update(Channel item)
        {
            var channel = _forumContext.Channels.Attach(item);

            _forumContext.Entry(item).State = EntityState.Modified;

            _forumContext.SaveChanges();

            return channel;
        }
    }
}