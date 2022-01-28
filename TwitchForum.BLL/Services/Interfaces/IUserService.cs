using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchForum.DAL.Models;

namespace TwitchForum.BLL.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> GetByName(string name);

        IEnumerable<User> GetAll();

        IEnumerable<User> GetN(int n);

        User GetById(int Id);

        User Get(User message);

        User Add(User message);

        bool Delete(User message);
    }
}