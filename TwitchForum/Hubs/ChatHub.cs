using Microsoft.AspNet.SignalR;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TwitchForum.BLL.Services;
using TwitchForum.BLL.Services.Interfaces;
using TwitchForum.DAL;
using TwitchForum.DAL.Models;
using TwitchForum.DAL.Repositories.Interfaces;

namespace TwitchForum.Hubs
{
    public class ChatHub : Hub
    {
        private IUserService _userService;

        private IMessagesService _messagesService;

        public IUserService UserService

        {
            get
            {
                if (_userService == null)
                {
                    _userService = DependencyResolver.Current.GetService<IUserService>();
                    return _userService;
                }
                else
                    return _userService;
            }
            set
            {
                _userService = value;
            }
        }

        public IMessagesService MessagesService

        {
            get
            {
                if (_messagesService == null)
                {
                    _messagesService = DependencyResolver.Current.GetService<IMessagesService>();
                    return _messagesService;
                }
                else
                    return _messagesService;
            }
            set
            {
                _messagesService = value;
            }
        }

        public ChatHub()
        {
        }

        public void Send(string name, string message)
        {
            var user = UserService.GetByName(Context.User.Identity.Name);
            MessagesService.Add(new Message() { SendingTime = DateTime.Now, Text = message, UserId = user.Id });

            if (Context.User.IsInRole("user"))
                Clients.All.addNewMessageToPage(Context.User.Identity.Name, message);
            else
                Clients.All.addMenegerMessageToPage(Context.User.Identity.Name, message);
        }
    }
}