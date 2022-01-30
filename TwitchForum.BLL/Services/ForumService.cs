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
    public class ForumService : IForumService
    {
        private readonly IUnitOfWork _uoW;

        public ForumService(IUnitOfWork unitOfWork)
        {
            _uoW = unitOfWork;
        }

        public Discussion Add(Discussion discussion)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Discussion discussion)
        {
            throw new NotImplementedException();
        }

        public Discussion Get(Discussion discussion)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Discussion> GetAll()
        {
            var discussions = _uoW.DiscussionRepository.GetAll();
            return Construnct(discussions);
        }

        public Discussion GetById(int Id)
        {
            return _uoW.DiscussionRepository.GetById(Id);
        }

        public IEnumerable<Discussion> GetN(int n)
        {
            var discussions = _uoW.DiscussionRepository.GetN(n);
            return Construnct(discussions);
        }

        public IEnumerable<Discussion> Search(string words)
        {
            if (words.Length == 0 || words == null)
                throw new ArgumentNullException("words", "Try to search for nothing!");
            var discussions = _uoW.DiscussionRepository.Search(words);
            return Construnct(discussions);
        }

        public IEnumerable<Discussion> SearchByChannel(Channel channel)
        {
            if (channel == null)
                throw new ArgumentNullException("channel", "Try to search for channel that dosent exist!");
            var discussions = _uoW.DiscussionRepository.SearchforChannel(channel);
            return Construnct(discussions);
        }

        public IEnumerable<Discussion> SearchByChannelId(int id)
        {
            var discussions = _uoW.DiscussionRepository.SearchforChannel(_uoW.ChannelRepository.GetById(id));
            return Construnct(discussions);
        }

        private IEnumerable<Discussion> Construnct(IEnumerable<Discussion> discussions)
        {
            foreach (var descus in discussions)
            {
                descus.Channel = _uoW.ChannelRepository.GetById((int)descus.ChannelId);
                descus.User = _uoW.UserRepository.GetById(descus.UserId.ToString());
            }
            return discussions;
        }
    }
}