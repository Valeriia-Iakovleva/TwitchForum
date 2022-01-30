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

        public ForumController(IForumService forumService)
        {
            _forumService = forumService;
        }

        // GET: Forum
        public ActionResult Index()
        {
            return View(_forumService.GetAll());
        }

        public ActionResult Chenals(int id)
        {
            return View(_forumService.SearchByChannelId(id));
        }

        public ActionResult Search(string words)
        {
            return View(_forumService.Search(words));
        }

        // GET: Forum/Details/5
        public ActionResult Details(int id)
        {
            return View(_forumService.GetById(id));
        }

        // GET: Forum/Create
        public ActionResult Create()
        {
            return View();
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