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
    public class ChannelService : IChannelService
    {
        private readonly IUnitOfWork _uoW;

        public ChannelService(IUnitOfWork unitOfWork)
        {
            _uoW = unitOfWork;
        }

        public Channel Add(Channel channel)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Channel channel)
        {
            throw new NotImplementedException();
        }

        public Channel Get(Channel channel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Channel> GetAll()
        {
            throw new NotImplementedException();
        }

        public Channel GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Channel> GetN(int n)
        {
            return _uoW.ChannelRepository.GetN(n);
        }
    }
}