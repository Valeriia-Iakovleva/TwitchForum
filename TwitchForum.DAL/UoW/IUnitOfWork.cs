using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchForum.DAL.Repositories.Interfaces;

namespace TwitchForum.DAL.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        IMessagesRepository MessagesRepository { get; }
        IUserRepository UserRepository { get; }
        IChannelRepository ChannelRepository { get; }
        IAnswerRepository AnswerRepository { get; }
        IDiscussionRepository DiscussionRepository { get; }

        int Save();
    }
}