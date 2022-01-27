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
    public class MessagesRepository : IRepository<Message>
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

        public async Task<bool> Delete(Message item)
        {
            _forumContext.Messages.Remove(item);

            await _forumContext.SaveChangesAsync();

            return await _forumContext.Messages.FindAsync(item) == null;
        }

        public Task<Message> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Message>> GetN(int n)
        {
            return await _forumContext.Messages.Take(n).ToListAsync();
        }

        public Message Update(Message item)
        {
            throw new NotImplementedException();
        }
    }
}