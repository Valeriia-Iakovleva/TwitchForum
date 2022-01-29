﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchForum.DAL.Models;

namespace TwitchForum.BLL.Services.Interfaces
{
    public interface IMessagesService
    {
        Task<IEnumerable<Message>> GetAll();

        IEnumerable<Message> GetN(int n);

        Message GetById(int Id);

        Message Get(Message message);

        Task<Message> Add(Message message);

        bool Delete(Message message);
    }
}