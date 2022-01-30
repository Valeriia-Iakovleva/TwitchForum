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
            return _forumContext.Discussions.Add(item);
        }

        public bool Delete(Discussion item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Discussion> GetAll()
        {
            return _forumContext.Discussions.ToList();
        }

        public Discussion GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Discussion>> GetN(int n)
        {
            throw new NotImplementedException();
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

        IEnumerable<Discussion> IRepository<Discussion>.GetN(int n)
        {
            throw new NotImplementedException();
        }
    }
}