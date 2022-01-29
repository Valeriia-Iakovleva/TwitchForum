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
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _uoW;

        public UserService(IUnitOfWork unitOfWork)
        {
            _uoW = unitOfWork;
        }

        public User Add(User message)
        {
            throw new NotImplementedException();
        }

        public bool Delete(User message)
        {
            throw new NotImplementedException();
        }

        public User Get(User user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public User GetByName(string name)
        {
            return _uoW.UserRepository.GetByName(name);
        }

        public IEnumerable<User> GetN(int n)
        {
            throw new NotImplementedException();
        }
    }
}