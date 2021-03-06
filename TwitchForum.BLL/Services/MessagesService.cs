using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchForum.BLL.Services.Interfaces;
using TwitchForum.DAL.Models;
using TwitchForum.DAL.Repositories.Interfaces;
using TwitchForum.DAL.UoW;

namespace TwitchForum.BLL.Services
{
    public class MessagesService : IMessagesService
    {
        private readonly IUnitOfWork _uoW;

        public MessagesService(IUnitOfWork unitOfWork)
        {
            _uoW = unitOfWork;
        }

        public Message Add(Message message)
        {
            if (message == null)
                throw new ArgumentNullException("message", "Message to add wasnt found!");

            return _uoW.MessagesRepository.Add(message); ;
        }

        public bool Delete(Message message)
        {
            return _uoW.MessagesRepository.Delete(message);
        }

        public Message Get(Message message)
        {
            return _uoW.MessagesRepository.Get(message);
        }

        public IEnumerable<Message> GetAll()
        {
            return _uoW.MessagesRepository.GetAll().ToList();
        }

        public Message GetById(int id)
        {
            return _uoW.MessagesRepository.GetById(id);
        }

        public IEnumerable<Message> GetN(int n)
        {
            return _uoW.MessagesRepository.GetN(n);
        }
    }
}