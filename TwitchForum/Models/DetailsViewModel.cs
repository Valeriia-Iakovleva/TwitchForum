using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TwitchForum.DAL.Models;

namespace TwitchForum.Models
{
    public class DetailsViewModel
    {
        public Discussion Disscusion { get; set; }
        public Answer NewAnswer { get; set; }
        public string AnswerUserName { get; set; }
        public IEnumerable<Answer> Answers { get; set; }
    }
}