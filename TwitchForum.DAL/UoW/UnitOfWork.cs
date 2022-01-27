using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchForum.DAL.Repositories.Interfaces;

namespace TwitchForum.DAL.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ForumContext _context;
        public IMessagesRepository MessagesRepository { get; }

        public IUserRepository UserRepository { get; }

        public IChannelRepository ChannelRepository { get; }

        public IAnswerRepository AnswerRepository { get; }

        public IDiscussionRepository DiscussionRepository { get; }

        public UnitOfWork(ForumContext context, IMessagesRepository messagesRepository, IUserRepository userRepository, IChannelRepository channelRepository, IAnswerRepository answerRepository, IDiscussionRepository discussionRepository)
        {
            _context = context;
            UserRepository = userRepository;
            ChannelRepository = channelRepository;
            AnswerRepository = answerRepository;
            DiscussionRepository = discussionRepository;
            MessagesRepository = messagesRepository;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }

        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}