using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchForum.DAL.Models;

namespace TwitchForum.BLL.Services.Interfaces
{
    public interface IForumService
    {
        IEnumerable<Discussion> GetAll();

        IEnumerable<Discussion> GetAllForStartPage();

        IEnumerable<Discussion> GetN(int n);

        IEnumerable<Discussion> Search(string words);

        IEnumerable<Discussion> SearchByChannel(Channel channel);

        IEnumerable<Discussion> SearchByChannelId(int id);

        Discussion GetById(int Id);

        Discussion Get(Discussion discussion);

        Discussion Add(Discussion discussion);

        bool Delete(int id);

        Discussion Update(Discussion discussion);
    }
}