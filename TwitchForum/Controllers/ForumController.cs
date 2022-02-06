using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TwitchForum.BLL.Services.Interfaces;
using TwitchForum.DAL.Models;

namespace TwitchForum.Controllers
{
    public class ForumController : Controller
    {
        private readonly IForumService _forumService;
        private readonly IAnswerService _answerService;

        public ForumController(IForumService forumService, IAnswerService answerService)
        {
            _forumService = forumService;
            _answerService = answerService;
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
            return View(_forumService.GetById(id));
        }

        // GET: Forum/Create
        public ActionResult Create()
        {
            return View(new Discussion());
        }

        public ActionResult Answer()
        {
            return PartialView();
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