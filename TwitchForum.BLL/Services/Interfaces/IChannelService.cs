using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchForum.DAL.Models;

namespace TwitchForum.BLL.Services.Interfaces
{
    public interface IChannelService
    {
        IEnumerable<Channel> GetAll();

        IEnumerable<Channel> GetN(int n);

        Channel GetById(int Id);

        Channel Get(Channel message);

        Channel Add(Channel message);

        bool Delete(Channel message);
    }
}