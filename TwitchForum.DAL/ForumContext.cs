﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchForum.DAL.Models;
using Microsoft.AspNet.Identity;

using Microsoft.AspNet.Identity;

using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using Microsoft.AspNetCore.Identity;

namespace TwitchForum.DAL
{
    public class ForumContext : IdentityDbContext<User>
    {
        public DbSet<Message> Messages { get; set; }
        public DbSet<Channel> Channels { get; set; }
        public DbSet<Discussion> Discussions { get; set; }
        public DbSet<Answer> Answers { get; set; }

        public ForumContext() : base("ForumContext")
        {
        }

        public static ForumContext Create()
        {
            return new ForumContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}