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
            return _uoW.DiscussionRepository.Add(discussion);
        }

        public bool Delete(int id)
        {
            return _uoW.DiscussionRepository.Delete(_uoW.DiscussionRepository.GetById(id));
        }

        public Discussion Get(Discussion discussion)
        {
            return _uoW.DiscussionRepository.Get(discussion);
        }

        public IEnumerable<Discussion> GetAll()
        {
            var discussions = _uoW.DiscussionRepository.GetAll();
            return discussions;
        }

        public IEnumerable<Discussion> GetAllForStartPage()
        {
            var returnDiscussions = GetAll();
            foreach (var item in returnDiscussions)
            {
                if (item.Text.Length > 200)
                {
                    item.Text = item.Text.Substring(0, 200) + "...";
                }
                else
                {
                    item.Text = item.Text + "...";
                }
            }
            return returnDiscussions;
        }

        public Discussion GetById(int Id)
        {
            return _uoW.DiscussionRepository.GetById(Id);
        }

        public IEnumerable<Discussion> GetN(int n)
        {
            var discussions = _uoW.DiscussionRepository.GetN(n);
            return discussions;
        }

        public IEnumerable<Discussion> Search(string words)
        {
            if (words == null)
                throw new ArgumentNullException("words", "Try to search for nothing!");
            if (words.Length == 0)
                throw new ArgumentNullException("words", "Try to search for nothing!");
            var discussions = _uoW.DiscussionRepository.Search(words);
            return discussions;
        }

        public IEnumerable<Discussion> SearchByChannel(Channel channel)
        {
            if (channel == null)
                throw new ArgumentNullException("channel", "Try to search for channel that dosent exist!");
            var discussions = _uoW.DiscussionRepository.SearchforChannel(channel);
            return discussions;
        }

        public IEnumerable<Discussion> SearchByChannelId(int id)
        {
            var discussions = _uoW.DiscussionRepository.SearchforChannel(_uoW.ChannelRepository.GetById(id));
            return discussions;
        }

        public Discussion Update(Discussion discussion)
        {
            return _uoW.DiscussionRepository.Update(discussion);
        }
    }
}