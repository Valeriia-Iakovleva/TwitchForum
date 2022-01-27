using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TwitchForum.DAL;
using TwitchForum.DAL.Models;
using TwitchForum.DAL.Repositories.Interfaces;

namespace TwitchForum.Hubs
{
    public class ChatHub : Hub
    {
        private readonly IRepository<Message> _messageRepository;
        private readonly IUserRepository _userRepository;

        public ChatHub()
        {
        }

        public ChatHub(IRepository<Message> repository, IUserRepository userRepository)
        {
            _messageRepository = repository;
            _userRepository = userRepository;
        }

        public void Send(string name, string message)
        {
            // Call the addNewMessageToPage method to update clients.
            //if (Context.User.IsInRole("user")

            Clients.All.addNewMessageToPage(Context.User.Identity.Name, message);
            SaveMessege(Context.User.Identity.Name, message);
        }

        private async void SaveMessege(string name, string message)
        {
            var user = await _userRepository.GetByName(name);
            _messageRepository.Add(new Message() { Sender = user, SendingTime = DateTime.Now, Text = message, UserId = user.Id });
        }
    }
}