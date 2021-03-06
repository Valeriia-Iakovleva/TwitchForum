using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchForum.DAL.Models;

namespace TwitchForum.DAL.Repositories.Interfaces
{
    public interface IUserRepository
    {
        User GetByName(string name);

        IEnumerable<User> GetN(int n);

        User GetById(string id);

        Task<bool> Delete(User item);

        User Update(User item);

        IEnumerable<User> GetAll();
    }
}