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
    public class AnswerRepository : IAnswerRepository
    {
        private readonly ForumContext _forumContext;

        public AnswerRepository(ForumContext forumContext)
        {
            _forumContext = forumContext;
        }

        public Answer Add(Answer item)
        {
            item.Sender = _forumContext.Users.FirstOrDefault(x => x.Id == item.UserId);

            _forumContext.Answers.Add(item);

            _forumContext.SaveChanges();

            return _forumContext.Answers.Attach(item);
        }

        public bool Delete(Answer item)
        {
            _forumContext.Answers.Remove(item);
            return _forumContext.Answers.Contains(item);
        }

        public Answer Get(Answer item)
        {
            var answer = _forumContext.Answers.FirstOrDefault(x => x == item);

            Construct(answer);

            return answer;
        }

        public IEnumerable<Answer> GetAll()
        {
            var answers = _forumContext.Answers;

            Construct(answers.ToArray());

            return answers;
        }

        public async Task<IEnumerable<Answer>> GetAllForChannel(int id)
        {
            var answers = _forumContext.Answers.Where(x => x.DiscussionId == id);

            Construct(answers.ToArray());

            return await answers.ToListAsync();
        }

        public Answer GetById(int id)
        {
            var answer = _forumContext.Answers.FirstOrDefault(x => x.Id == id);

            Construct(answer);

            return answer;
        }

        public IEnumerable<Answer> GetN(int n)
        {
            var answer = _forumContext.Answers.Take(n);

            Construct(answer.ToArray());

            return answer;
        }

        public Answer Update(Answer item)
        {
            throw new NotImplementedException();
        }

        private void Construct(params Answer[] answers)
        {
            foreach (var item in answers)
            {
                item.Discussion = _forumContext.Discussions.FirstOrDefault(x => x.Id == item.DiscussionId);
                item.Sender = _forumContext.Users.FirstOrDefault(x => x.Id == item.UserId);
            }
        }
    }
}