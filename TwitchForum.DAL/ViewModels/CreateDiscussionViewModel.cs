using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TwitchForum.DAL.Models;

namespace TwitchForum.DAL.ViewModels
{
    public class CreateDiscussionViewModel
    {
        public Discussion Discussion { get; set; }

        public SelectList Channels { get; set; }

        public string Name { get; set; }
    }
}