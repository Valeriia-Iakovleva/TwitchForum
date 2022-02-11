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
            return _uoW.ChannelRepository.Add(channel);
        }

        public bool Delete(Channel channel)
        {
            return _uoW.ChannelRepository.Delete(channel);
        }

        public Channel Get(Channel channel)
        {
            return _uoW.ChannelRepository.Get(channel);
        }

        public IEnumerable<Channel> GetAll()
        {
            return _uoW.ChannelRepository.GetAll();
        }

        public Channel GetById(int Id)
        {
            return _uoW.ChannelRepository.GetById(Id);
        }

        public IEnumerable<Channel> GetN(int n)
        {
            return _uoW.ChannelRepository.GetN(n);
        }
    }
}