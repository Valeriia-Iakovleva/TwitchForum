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

namespace TwitchForum.Controllers
{
    public class MainController : Controller
    {
        private ApplicationUserManager _userManager;
        private readonly IRepository<Message> _messageRepository;
        private readonly IUserRepository _userRepository;

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

        public MainController(ApplicationUserManager userManager, IRepository<Message> repository, IUserRepository userRepository)
        {
            UserManager = userManager;
            _messageRepository = repository;
            _userRepository = userRepository;
        }

        // GET: Main
        public ActionResult Index()
        {
            var currentUser = this.User;
            ViewBag.Messege = currentUser.Identity.Name;
            return View();
        }

        public ActionResult SendMessege()
        {
            return View(new Message());
        }

        [HttpPost]
        public async Task<ActionResult> Send(Message m)
        {
            var user = await _userRepository.GetByName(User.Identity.Name);
            Message message = new Message() { Text = m.Text, Sender = user };
            _messageRepository.Add(message);
            return Redirect("/Main/Index");
        }
    }
}