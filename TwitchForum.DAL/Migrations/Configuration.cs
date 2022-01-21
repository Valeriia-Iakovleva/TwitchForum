namespace TwitchForum.DAL.Migrations
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web;
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.Owin.Security;
    using TwitchForum.DAL.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TwitchForum.DAL.ForumContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TwitchForum.DAL.ForumContext context)
        {
            var userManager = new ApplicationUserManager(new UserStore<User>(context));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            var role1 = new IdentityRole { Name = "manager" };
            var role2 = new IdentityRole { Name = "admin" };
            var role3 = new IdentityRole { Name = "user" };

            roleManager.Create(role1);
            roleManager.Create(role2);
            roleManager.Create(role3);
        }
    }
}