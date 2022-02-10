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
            item.Sender = _forumContext.Users.FirstOrDefault(x => x.Id == item.UserId);
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
            var message = _forumContext.Messages.Find(item);

            Construct(message);

            return message;
        }

        public IEnumerable<Message> GetAll()
        {
            var messages = _forumContext.Messages;

            Construct(messages.ToArray());

            return messages;
        }

        public Message GetById(int id)
        {
            var message = _forumContext.Messages.FirstOrDefault(x => x.Id == id);

            Construct(message);

            return message;
        }

        public IEnumerable<Message> GetN(int n)
        {
            var messages = _forumContext.Messages.Take(n);

            Construct(messages.ToArray());

            return messages;
        }

        public Message Update(Message item)
        {
            throw new NotImplementedException();
        }

        private void Construct(params Message[] messages)
        {
            foreach (var item in messages)
            {
                item.Sender = _forumContext.Users.FirstOrDefault(x => x.Id == item.UserId);
            }
        }
    }
}