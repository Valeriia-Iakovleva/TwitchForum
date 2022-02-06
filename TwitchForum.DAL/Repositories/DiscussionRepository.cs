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
        private readonly ForumContext _forumContext;

        public DiscussionRepository(ForumContext forumContext)
        {
            _forumContext = forumContext;
        }

        public Discussion Add(Discussion item)
        {
            _forumContext.Discussions.Add(item);

            _forumContext.SaveChanges();

            return _forumContext.Discussions.Find(item);
        }

        public bool Delete(Discussion item)
        {
            _forumContext.Discussions.Remove(item);

            _forumContext.SaveChanges();

            return _forumContext.Discussions.FirstOrDefault(x => x.Id == item.Id) == null;
        }

        public IEnumerable<Discussion> GetAll()
        {
            return _forumContext.Discussions.ToList();
        }

        public Discussion GetById(int id)
        {
            return _forumContext.Discussions.FirstOrDefault(x => x.Id == id);
        }

        public Discussion Get(Discussion discussion)
        {
            return _forumContext.Discussions.Find(discussion);
        }

        public IEnumerable<Discussion> GetN(int n)
        {
            return _forumContext.Discussions.Take(n);
        }

        public IEnumerable<Discussion> Search(string words)
        {
            return _forumContext.Discussions.Where(x => x.Title.ToLower().Contains(words.ToLower()) || x.Text.Contains(words.ToLower()) || x.Channel.Name.Contains(words.ToLower()));
        }

        public IEnumerable<Discussion> SearchforChannel(Channel channel)
        {
            return _forumContext.Discussions.Where(x => x.Channel == channel);
        }

        public Discussion Update(Discussion item)
        {
            throw new NotImplementedException();
        }
    }
}