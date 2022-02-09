using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.SignalR;
using Ninject.Modules;
using Ninject.Web.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TwitchForum.BLL;
using TwitchForum.BLL.Services;
using TwitchForum.BLL.Services.Interfaces;
using TwitchForum.DAL;
using TwitchForum.DAL.Models;
using TwitchForum.DAL.Repositories;
using TwitchForum.DAL.Repositories.Interfaces;
using TwitchForum.DAL.UoW;

namespace TwitchForum.DependencyInjection
{
    public class DependencyModule : NinjectModule
    {
        public override void Load()
        {
            //Bind<DbContext>().To<ForumContext>();
            Bind<DbContext>().To<ForumContext>().InSingletonScope();
            Bind(typeof(IUserStore<User>)).To(typeof(UserStore<User>)).InRequestScope();
            Bind<IMessagesRepository>().To<MessagesRepository>();
            Bind<IUserRepository>().To<UserRepository>();
            Bind<IAnswerRepository>().To<AnswerRepository>();
            Bind<IChannelRepository>().To<ChannelRepository>();
            Bind<IDiscussionRepository>().To<DiscussionRepository>();
            Bind<IUnitOfWork>().To<UnitOfWork>();
            Bind<IUserService>().To<UserService>();
            Bind<IMessagesService>().To<MessagesService>();
            Bind<IChannelService>().To<ChannelService>();
            Bind<IForumService>().To<ForumService>();
            Bind<IAnswerService>().To<AnswerService>();

            //Bind<IUserService>().To<UserService>().WithPropertyValue("userService", new UnitOfWork());
        }
    }
}