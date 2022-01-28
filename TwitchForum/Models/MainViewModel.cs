using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TwitchForum.DAL.Models;

namespace TwitchForum.Models
{
    public class MainViewModel
    {
        public int NumberfMesseges { get; set; } = 10;
        public IPagedList<Message> Messages { get; set; }
        public List<Channel> Channels { get; set; }
    }
}