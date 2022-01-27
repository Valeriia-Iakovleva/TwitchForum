using System;
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

        static ForumContext()
        {
            // Set the database intializer which is run once during application start
            // This seeds the database with admin user credentials and admin role
            Database.SetInitializer(new ApplicationDbInitializer());
        }

        public static ForumContext Create()
        {
            return new ForumContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Message>().HasOptional<User>(x => x.Sender).WithMany(m => m.Messages).HasForeignKey(x => x.UserId);
            //this.SeedUsers(modelBuilder);
            //this.SeedUserRoles(modelBuilder);
        }

        public class ApplicationDbInitializer : CreateDatabaseIfNotExists<ForumContext>
        {
            protected override void Seed(ForumContext context)
            {
                //InitializeIdentityForEF(context);
                base.Seed(context);
            }

            public static void InitializeIdentityForEF(ForumContext db)
            {
                if (!db.Users.Any())
                {
                    var roleStore = new RoleStore<IdentityRole>(db);
                    var roleManager = new Microsoft.AspNet.Identity.RoleManager<IdentityRole>(roleStore);
                    var userStore = new UserStore<User>(db);
                    var userManager = new Microsoft.AspNet.Identity.UserManager<User>(userStore);

                    // Add missing roles
                    var role = roleManager.FindByName("Admin");
                    if (role == null)
                    {
                        role = new IdentityRole("Admin");
                        roleManager.Create(role);
                    }

                    // Create test users
                    var user = userManager.FindByName("admin");
                    if (user == null)
                    {
                        var newUser = new User()
                        {
                            UserName = "admin",
                            FirstName = "Admin",
                            LastName = "User",
                            Email = "xxx@xxx.net",
                            PhoneNumber = "5551234567",
                        };
                        userManager.Create(newUser, "Password1");
                        userManager.SetLockoutEnabled(newUser.Id, false);
                        userManager.AddToRole(newUser.Id, "admin");
                    }
                }
            }
        }
    }
}