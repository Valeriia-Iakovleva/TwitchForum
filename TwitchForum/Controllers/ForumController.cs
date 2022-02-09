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
using TwitchForum.Models;

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
            return View(_forumService.GetAll().OrderBy(x => x.Rating).ThenBy(x => x.PublicationTime));
        }

        public ActionResult Chenals(int id)
        {
            return View(_forumService.SearchByChannelId(id).OrderBy(x => x.Rating));
        }

        public ActionResult Search(string words)
        {
            return View(_forumService.Search(words).OrderBy(x => x.Rating));
        }

        // GET: Forum/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var details = new DetailsViewModel() { Answers = await _answerService.GetAllForChannel(id), Disscusion = _forumService.GetById(id), NewAnswer = new Answer() };
            return View(details);
        }

        // GET: Forum/Create
        public ActionResult Create()
        {
            var viewModel = new CreateDiscussionViewModel() { Channels = new SelectList(_channelService.GetAll(), "Id", "Name"), Discussion = new Discussion() };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Answer(DetailsViewModel viewModel)
        {
            var answer = new Answer()
            {
                Discussion = _forumService.GetById((int)viewModel.NewAnswer.DiscussionId),
                DiscussionId = (int)viewModel.NewAnswer.DiscussionId,
                Sender = _userService.GetByName(viewModel.NewAnswer.UserId),
                Text = viewModel.NewAnswer.Text,
                UserId = _userService.GetByName(viewModel.NewAnswer.UserId).Id
            };
            _answerService.Add(answer);
            return RedirectToAction("Details", answer.DiscussionId);
        }

        // POST: Forum/Create
        [HttpPost]
        public ActionResult Create(CreateDiscussionViewModel viewModel)
        {
            try
            {
                // TODO: Add insert logic here
                var discussion = new Discussion()
                {
                    Channel = _channelService.GetById((int)viewModel.Discussion.ChannelId),
                    Text = viewModel.Discussion.Text,
                    Title = viewModel.Discussion.Title,
                    ChannelId = viewModel.Discussion.ChannelId,
                };
                discussion.UserId = UserManager.Users.FirstOrDefault(x => x.UserName == viewModel.Name).Id;
                _forumService.Add(discussion);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(new CreateDiscussionViewModel());
            }
        }

        // GET: Forum/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Forum/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Forum/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Forum/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}