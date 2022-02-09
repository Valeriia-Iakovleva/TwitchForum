using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchForum.DAL.Models;

namespace TwitchForum.BLL.Services.Interfaces
{
    public interface IAnswerService
    {
        IEnumerable<Answer> GetAll();

        IEnumerable<Answer> GetN(int n);

        Task<IEnumerable<Answer>> GetAllForChannel(int id);

        Answer GetById(int Id);

        Answer Get(Answer answer);

        Answer Add(Answer answer);

        bool Delete(Answer answer);
    }
}