using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchForum.BLL.Services.Interfaces;
using TwitchForum.DAL.Models;
using TwitchForum.DAL.UoW;

namespace TwitchForum.BLL.Services
{
    public class AnswerService : IAnswerService
    {
        private readonly IUnitOfWork _uoW;

        public AnswerService(IUnitOfWork unitOfWork)
        {
            _uoW = unitOfWork;
        }

        public Answer Add(Answer answer)
        {
            _uoW.AnswerRepository.Add(answer);
            return _uoW.AnswerRepository.Get(answer);
        }

        public bool Delete(Answer answer)
        {
            throw new NotImplementedException();
        }

        public Answer Get(Answer answer)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Answer> GetAll()
        {
            return _uoW.AnswerRepository.GetAll();
        }

        public Answer GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Answer> GetN(int n)
        {
            throw new NotImplementedException();
        }
    }
}