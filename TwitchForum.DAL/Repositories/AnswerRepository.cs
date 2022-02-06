using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchForum.DAL.Models;
using TwitchForum.DAL.Repositories.Interfaces;

namespace TwitchForum.DAL.Repositories
{
    public class AnswerRepository : IAnswerRepository
    {
        private readonly ForumContext _forumContext;

        public AnswerRepository(ForumContext forumContext)
        {
            _forumContext = forumContext;
        }

        public Answer Add(Answer item)
        {
            _forumContext.Answers.Add(item);
            return _forumContext.Answers.FirstOrDefault(x => x == item);
        }

        public bool Delete(Answer item)
        {
            _forumContext.Answers.Remove(item);
            return _forumContext.Answers.Contains(item);
        }

        public Answer Get(Answer item)
        {
            return _forumContext.Answers.FirstOrDefault(x => x == item);
        }

        public IEnumerable<Answer> GetAll()
        {
            return _forumContext.Answers.ToList();
        }

        public Answer GetById(int id)
        {
            return _forumContext.Answers.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Answer> GetN(int n)
        {
            return _forumContext.Answers.Take(n);
        }

        public Answer Update(Answer item)
        {
            throw new NotImplementedException();
        }
    }
}