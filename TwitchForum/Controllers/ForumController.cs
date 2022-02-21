using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TwitchForum.BLL.Services.Interfaces;
using TwitchForum.DAL;
using TwitchForum.DAL.Models;
using TwitchForum.DAL.ViewModels;

namespace TwitchForum.Controllers
{
    public class ForumController : Controller
    {
        private readonly IForumService _forumService;
        private readonly IAnswerService _answerService;
        private readonly IChannelService _channelService;
        private readonly IUserService _userService;
        private ApplicationUserManager _userManager;

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

        public ForumController(ApplicationUserManager userManager, IForumService forumService, IAnswerService answerService, IChannelService channelService, IUserService userService)
        {
            UserManager = userManager;
            _forumService = forumService;
            _answerService = answerService;
            _channelService = channelService;
            _userService = userService;
        }

        // GET: Forum
        public ActionResult Index()
        {
            ViewBag.Title = "Twitch Forum";
            return View(_forumService.GetAllForStartPage().OrderBy(x => x.Rating).ThenBy(x => x.PublicationTime));
        }

        public ActionResult Chennals(int id)
        {
            return View("Search", _forumService.SearchByChannelId(id).OrderBy(x => x.Rating));
        }

        [HttpPost]
        public ActionResult Search(string words)
        {
            return View(_forumService.Search(words).OrderBy(x => x.Rating));
        }

        // GET: Forum/Details/5
        public ActionResult Details(int id)
        {
            var details = new DetailsViewModel() { Answers = _answerService.GetAllForChannel(id).ToList(), Disscusion = _forumService.GetById(id), NewAnswer = new Answer() };
            return View(details);
        }

        // GET: Forum/Create
        public ActionResult Create()
        {
            var viewModel = new CreateDiscussionViewModel() { Channels = new SelectList(_channelService.GetAll(), "Id", "Name"), Discussion = new Discussion() };
            return View(viewModel);
        }

        [Authorize]
        public ActionResult Answer(DetailsViewModel viewModel)
        {
            var answer = new Answer()
            {
                DiscussionId = (int)viewModel.NewAnswer.DiscussionId,
                Text = viewModel.NewAnswer.Text,
                UserId = _userService.GetByName(viewModel.NewAnswer.UserId).Id
            };
            _answerService.Add(answer);
            return RedirectToAction("Details", new { id = answer.DiscussionId });
        }

        // POST: Forum/Create
        [HttpPost]
        public ActionResult Create(CreateDiscussionViewModel viewModel)
        {
            // TODO: Add insert logic here
            var discussion = new Discussion()
            {
                Text = viewModel.Discussion.Text,
                Title = viewModel.Discussion.Title,
                ChannelId = _channelService.GetById((int)viewModel.Discussion.ChannelId).Id,
                UserId = UserManager.Users.FirstOrDefault(x => x.UserName == viewModel.Name).Id
            };

            _forumService.Add(discussion);

            return RedirectToAction("Index");
        }

        // GET: Forum/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            return View(_forumService.GetById(id));
        }

        // POST: Forum/Edit/5
        [HttpPost]
        public ActionResult Edit(Discussion discussion)
        {
            try
            {
                _forumService.Update(discussion);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        [Authorize(Roles = "manager, admin")]
        public ActionResult Delete(int id)
        {
            return View(_forumService.GetById(id));
        }

        // POST: Forum/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "manager, admin")]
        public ActionResult Delete(Discussion discussion)
        {
            // TODO: Add delete logic here
            _forumService.Delete(discussion.Id);

            return RedirectToAction("Index");
        }

        [HttpPost]
        [Authorize]
        public ActionResult DeleteByUser(string user, int id)
        {
            if (user == _forumService.GetById(id).User.UserName)
            {
                _forumService.Delete(id);
            }
            else
            {
                throw new HttpAntiForgeryException("Exese denide! You are trying to delete not your forum");
            }
            // TODO: Add delete logic here

            return RedirectToAction("Index");
        }
    }
}