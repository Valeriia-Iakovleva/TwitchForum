using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchForum.DAL.Models;
using TwitchForum.DAL.Repositories.Interfaces;

namespace TwitchForum.DAL.Repositories
{
    public class DiscussionRepository : IDiscussionRepository
    {
        private readonly ForumContext _forumContext;

        public DiscussionRepository(ForumContext forumContext)
        {
            _forumContext = forumContext;
        }

        public Discussion Add(Discussion item)
        {
            var created = _forumContext.Discussions.Add(item);

            _forumContext.SaveChanges();

            return _forumContext.Discussions.FirstOrDefault(x => x.Id == created.Id);
        }

        public bool Delete(Discussion item)
        {
            _forumContext.Discussions.Remove(item);

            _forumContext.SaveChanges();

            return _forumContext.Discussions.FirstOrDefault(x => x.Id == item.Id) == null;
        }

        public IEnumerable<Discussion> GetAll()
        {
            var discussion = _forumContext.Discussions;

            Construct(discussion.ToArray());

            return discussion;
        }

        public Discussion GetById(int id)
        {
            var discuss = _forumContext.Discussions.FirstOrDefault(x => x.Id == id);

            Construct(discuss);

            return discuss;
        }

        public Discussion Get(Discussion discussion)
        {
            var discuss = _forumContext.Discussions.Find(discussion);

            Construct(discuss);

            return discuss;
        }

        public IEnumerable<Discussion> GetN(int n)
        {
            var discuss = _forumContext.Discussions.Take(n);

            Construct(discuss.ToArray());

            return discuss;
        }

        public IEnumerable<Discussion> Search(string words)
        {
            var discuss = _forumContext.Discussions.Where(x => x.Title.ToLower().Contains(words.ToLower()) || x.Text.Contains(words.ToLower()) || x.Channel.Name.Contains(words.ToLower()));

            Construct(discuss.ToArray());

            return discuss;
        }

        public IEnumerable<Discussion> SearchforChannel(Channel channel)
        {
            var discuss = _forumContext.Discussions.Where(x => x.Channel == channel);

            Construct(discuss.ToArray());

            return discuss;
        }

        public Discussion Update(Discussion item)
        {
            var discussion = _forumContext.Discussions.Attach(item);

            _forumContext.Entry(item).State = EntityState.Modified;

            _forumContext.SaveChanges();

            return discussion;
        }

        private void Construct(params Discussion[] discussions)
        {
            foreach (var item in discussions)
            {
                item.Channel = _forumContext.Channels.FirstOrDefault(x => x.Id == item.ChannelId);
                item.User = _forumContext.Users.FirstOrDefault(x => x.Id == item.UserId);
            }
        }
    }
}