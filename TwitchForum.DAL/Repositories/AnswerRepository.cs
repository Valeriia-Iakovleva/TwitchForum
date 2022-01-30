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

        public IEnumerable<Answer> GetAll()
        {
            return _forumContext.Answers;
        }

        public Answer GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Answer>> GetN(int n)
        {
            throw new NotImplementedException();
        }

        public Answer Update(Answer item)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Answer> IRepository<Answer>.GetN(int n)
        {
            throw new NotImplementedException();
        }
    }
}