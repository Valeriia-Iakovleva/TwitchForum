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
        public Answer Add(Answer item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Answer item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Answer> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Answer> GetById(int id)
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