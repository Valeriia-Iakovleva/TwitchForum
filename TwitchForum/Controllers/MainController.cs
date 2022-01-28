using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TwitchForum.DAL;
using TwitchForum.DAL.Models;
using TwitchForum.DAL.Repositories.Interfaces;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using TwitchForum.BLL.Services.Interfaces;
using TwitchForum.Models;
using PagedList;

namespace TwitchForum.Controllers
{
    public class MainController : Controller
    {
        private ApplicationUserManager _userManager;
        private readonly IMessagesService _messageService;
        private readonly IUserService _userService;
        private readonly IChannelService _channelService;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public MainController(ApplicationUserManager userManager, IMessagesService messageRepository, IUserService userRepository, IChannelService channelService)
        {
            UserManager = userManager;
            _messageService = messageRepository;
            _userService = userRepository;
            _channelService = channelService;
        }

        // GET: Main
        public ActionResult Index(int? page)
        {
            var currentUser = this.User;
            var mainViewModel = new MainViewModel();
            mainViewModel.Messages = _messageService.GetAll().ToPagedList(mainViewModel.NumberfMesseges, page ?? 1);
            mainViewModel.Channels = _channelService.GetN(5).ToList();
            return View(mainViewModel);
        }

        public ActionResult SendMessege()
        {
            return View(new Message());
        }

        [HttpPost]
        public async Task<ActionResult> Send(Message m)
        {
            var user = await _userService.GetByName(User.Identity.Name);
            Message message = new Message() { Text = m.Text, Sender = user };
            await _messageService.Add(message);
            return Redirect("/Main/Index");
        }
    }
}