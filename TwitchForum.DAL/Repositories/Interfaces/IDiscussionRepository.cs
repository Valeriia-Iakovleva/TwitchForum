﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchForum.DAL.Models;

namespace TwitchForum.DAL.Repositories.Interfaces
{
    public interface IDiscussionRepository : IRepository<Discussion>
    {
        IEnumerable<Discussion> Search(string words);

        IEnumerable<Discussion> SearchforChannel(Channel channel);
    }
}