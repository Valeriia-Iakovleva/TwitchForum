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

        public async Task<Message> Add(Message message)
        {
            if (message == null)
                throw new ArgumentNullException("message", "Message to add wasnt found!");

            _uoW.MessagesRepository.Add(message);

            return await _uoW.MessagesRepository.GetById(message.Id);
        }

        public bool Delete(Message message)
        {
            throw new NotImplementedException();
        }

        public Message Get(Message message)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Message>> GetAll()
        {
            var messanges = _uoW.MessagesRepository.GetAll();
            foreach (var massage in messanges)
            {
                massage.Sender = await _uoW.UserRepository.GetById(massage.UserId);
            }
            return messanges;
        }

        public Message GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Message> GetN(int n)
        {
            return _uoW.MessagesRepository.GetN(n);
        }
    }
}