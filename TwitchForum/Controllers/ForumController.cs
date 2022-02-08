using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TwitchForum.BLL.Services.Interfaces;
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

        public ForumController(IForumService forumService, IAnswerService answerService, IChannelService channelService, IUserService userService)
        {
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
        public ActionResult Details(int id)
        {
            var details = new DetailsViewModel() { Answers = _answerService.GetAllForChannel(id), Disscusion = _forumService.GetById(id), NewAnswer = new Answer() };
            return View(details);
        }

        // GET: Forum/Create
        public ActionResult Create()
        {
            var s = ;
            var viewModel = new CreateDiscussionViewModel() { Channels = new SelectList(_channelService.GetAll(), "Id", "Name"), Discussion = new Discussion() };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Answer(CreateDiscussionViewModel viewModel)
        {
            try
            {
                var answer = new Answer()
                {
                    Discussion = viewModel.Discussion,
                    DiscussionId = viewModel.Discussion.Id,
                    Sender = _userService.GetByName(viewModel.Name),
                    Text = viewModel.Discussion.Text,
                    UserId = _userService.GetByName(viewModel.Name).Id
                };
                _answerService.Add(answer);
                return RedirectToAction("Details", answer.DiscussionId);
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        // POST: Forum/Create
        [HttpPost]
        public ActionResult Create(Discussion discussion)
        {
            try
            {
                // TODO: Add insert logic here
                _forumService.Add(discussion);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
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