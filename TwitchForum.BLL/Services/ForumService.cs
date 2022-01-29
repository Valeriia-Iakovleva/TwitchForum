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
            return _uoW.DiscussionRepository.GetAll();
        }

        public async Task<Discussion> GetById(int Id)
        {
            return await _uoW.DiscussionRepository.GetById(Id);
        }

        public IEnumerable<Discussion> GetN(int n)
        {
            return _uoW.DiscussionRepository.GetN(n);
        }

        public IEnumerable<Discussion> Search(string words)
        {
            if (words.Length == 0 || words == null)
                throw new ArgumentNullException("words", "Try to search for nothing!");
            return _uoW.DiscussionRepository.Search(words);
        }

        public IEnumerable<Discussion> SearchByChannel(Channel channel)
        {
            if (channel == null)
                throw new ArgumentNullException("channel", "Try to search for channel that dosent exist!");
            return _uoW.DiscussionRepository.SearchforChannel(channel);
        }
    }
}