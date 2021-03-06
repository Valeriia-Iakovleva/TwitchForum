using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchForum.DAL.Models;

namespace TwitchForum.DAL.Repositories.Interfaces
{
    public interface IChannelRepository : IRepository<Channel>
    {
        IEnumerable<Channel> GetN(int n);
    }
}