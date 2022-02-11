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

        public async Task<bool> Delete(User message)
        {
            return await _uoW.UserRepository.Delete(message);
        }

        public IEnumerable<User> GetAll()
        {
            return _uoW.UserRepository.GetAll();
        }

        public User GetById(string id)
        {
            return _uoW.UserRepository.GetById(id);
        }

        public User GetByName(string name)
        {
            return _uoW.UserRepository.GetByName(name);
        }

        public IEnumerable<User> GetN(int n)
        {
            return _uoW.UserRepository.GetN(n);
        }
    }
}