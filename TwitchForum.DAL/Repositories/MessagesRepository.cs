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
    public class MessagesRepository : IMessagesRepository
    {
        private readonly ForumContext _forumContext;

        public MessagesRepository(ForumContext forumContext)
        {
            _forumContext = forumContext;
        }

        public Message Add(Message item)
        {
            _forumContext.Messages.Add(item);

            _forumContext.SaveChanges();

            return _forumContext.Messages.Attach(item);
        }

        public bool Delete(Message item)
        {
            _forumContext.Messages.Remove(item);

            _forumContext.SaveChanges();

            return _forumContext.Messages.Find(item) == null;
        }

        public Message Get(Message item)
        {
            return _forumContext.Messages.Attach(item);
        }

        public IEnumerable<Message> GetAll()
        {
            return _forumContext.Messages.ToList();
        }

        public Message GetById(int id)
        {
            return _forumContext.Messages.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Message> GetN(int n)
        {
            return _forumContext.Messages.Take(n).ToList();
        }

        public Message Update(Message item)
        {
            throw new NotImplementedException();
        }
    }
}