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
            _uoW.AnswerRepository.Delete(answer);
            return _uoW.AnswerRepository.Get(answer) == null;
        }

        public Answer Get(Answer answer)
        {
            return _uoW.AnswerRepository.Get(answer);
        }

        public IEnumerable<Answer> GetAll()
        {
            return _uoW.AnswerRepository.GetAll();
        }

        public async Task<IEnumerable<Answer>> GetAllForChannel(int id)
        {
            return await _uoW.AnswerRepository.GetAllForChannel(id);
        }

        public Answer GetById(int Id)
        {
            return _uoW.AnswerRepository.GetById(Id);
        }

        public IEnumerable<Answer> GetN(int n)
        {
            return _uoW.AnswerRepository.GetN(n);
        }
    }
}