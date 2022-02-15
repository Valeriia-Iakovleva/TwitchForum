using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchForum.DAL;
using TwitchForum.DAL.Models;
using TwitchForum.DAL.Repositories;
using TwitchForum.DAL.Repositories.Interfaces;

namespace TwitchForum.Tests.Repositories
{
    [TestClass]
    public class ForumRepositoryTest
    {
        private static Mock<ForumContext> ForumContext { get; set; }
        private static Mock<DbSet<Channel>> MockChannelrSet { get; set; }
        private static Mock<DbSet<Discussion>> MockADiscussionSet { get; set; }
        private static Mock<DbSet<User>> MockUserSet { get; set; }
        private static List<Channel> ChannelProvider { get; set; }
        private static List<Discussion> DiscussionProvider { get; set; }
        private static List<User> UserProvider { get; set; }

        [ClassInitialize()]
        public static void ClassInitialize(TestContext context)
        {
            ForumContext = new Mock<ForumContext>();
            MockChannelrSet = new Mock<DbSet<Channel>>();
            MockADiscussionSet = new Mock<DbSet<Discussion>>();
            MockUserSet = new Mock<DbSet<User>>();

            ChannelProvider = new List<Channel>()
            {
                new Channel()
                {
                    Id = 1
                },
                new Channel()
                {
                    Id = 2
                },
                new Channel()
                {
                    Id = 3
                },
                new Channel()
                {
                    Id = 4
                }
            };
            DiscussionProvider = new List<Discussion>()
            {
                new Discussion()
                {
                    Id=1,
                    ChannelId = 1,
                    UserId="u1",
                    Rating = 1000,
                    Title ="Сикрет успеха Ninja",
                    Text= "Ninja также отметил, что аудитория Twitch стала более агрессивной, в особенности ему надоедают несовершеннолетние стримеры."
                },
                new Discussion()
                {
                    Id=2,
                    ChannelId = 1,
                    UserId="u1",
                    Rating = 750,
                    Title ="Ibai и NOBRU среди лучших — итоги и статистика крупнейшей киберспортивной премии Esports Awards 2021",
                    Text= "В этом году мероприятие транслировалось не только организаторами, но и стримерами Twitch."
                },
                new Discussion()
                {
                    Id=3,
                    ChannelId = 1,
                    UserId="u1",
                    Rating = 800,
                    Title ="TFUE ОН УШЕЛ ИЗ FORTNITE",
                    Text= "Один из самых плодовитых стримеров Twitch - Тернер «Tfue» Тенни - выйти из игры."
                }
            };
            UserProvider = new List<User>()
            {
                new User()
                {
                    Id = "u1"
                },
                new User()
                {
                    Id="u2"
                }
            };

            // MockChannelrSet setup
            MockChannelrSet.As<IQueryable<Channel>>().Setup(m => m.Provider).Returns(ChannelProvider.AsQueryable().Provider);

            MockChannelrSet.As<IQueryable<Channel>>().Setup(m => m.Expression).Returns(ChannelProvider.AsQueryable().Expression);

            MockChannelrSet.As<IQueryable<Channel>>().Setup(m => m.ElementType).Returns(ChannelProvider.AsQueryable().ElementType);

            MockChannelrSet.As<IQueryable<Channel>>().Setup(m => m.GetEnumerator()).Returns(ChannelProvider.AsQueryable().GetEnumerator());

            // MockADiscussionSet setup
            MockADiscussionSet.As<IQueryable<Discussion>>().Setup(m => m.Provider).Returns(DiscussionProvider.AsQueryable().Provider);

            MockADiscussionSet.As<IQueryable<Discussion>>().Setup(m => m.Expression).Returns(DiscussionProvider.AsQueryable().Expression);

            MockADiscussionSet.As<IQueryable<Discussion>>().Setup(m => m.ElementType).Returns(DiscussionProvider.AsQueryable().ElementType);

            MockADiscussionSet.As<IQueryable<Discussion>>().Setup(m => m.GetEnumerator()).Returns(DiscussionProvider.AsQueryable().GetEnumerator());

            // MockUserSet setup
            MockUserSet.As<IQueryable<User>>().Setup(m => m.Provider).Returns(UserProvider.AsQueryable().Provider);

            MockUserSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(UserProvider.AsQueryable().Expression);

            MockUserSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(UserProvider.AsQueryable().ElementType);

            MockUserSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(UserProvider.AsQueryable().GetEnumerator());

            // mockContext setup
            ForumContext.SetupGet(c => c.Channels).Returns(MockChannelrSet.Object);
            ForumContext.SetupGet(c => c.Discussions).Returns(MockADiscussionSet.Object);
            ForumContext.SetupGet(c => c.Users).Returns(MockUserSet.Object);
        }

        [TestMethod()]
        public void CityRepository_IsDbSetInitialized_True()
        {
            int expected = 3;
            int actual = (MockADiscussionSet.Object).Count();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddTest()
        {
            var repository = new DiscussionRepository(ForumContext.Object);
            Assert.IsNotNull(repository, "Ошибка создани репризитория!");

            var newDiscussion = new Discussion()
            {
                Id = 4,
                UserId = "u2",
                ChannelId = 2
            };
            try { var discussion = repository.Add(newDiscussion); }
            catch (Exception ex)
            {
                Assert.IsNotNull(ex, $"Добавление вернуло ошибку {ex.Message}");
            }
        }

        [TestMethod]
        public void GetAllTest()
        {
            var repository = new DiscussionRepository(ForumContext.Object);

            Assert.IsNotNull(repository, "Ошибка создани репризитория!");

            var allAnswers = repository.GetAll();

            Assert.IsNotNull(allAnswers, "Ошибка метода GetAll");
            Assert.AreEqual(3, allAnswers.Count());
        }

        [TestMethod]
        public void SearchTest()
        {
            var repository = new DiscussionRepository(ForumContext.Object);

            Assert.IsNotNull(repository, "Ошибка создани репризитория!");

            var allAnswers = repository.Search("Twitch");

            Assert.IsNotNull(allAnswers, "Ошибка метода GetAll");
            Assert.AreEqual(2, allAnswers.Count());
        }

        [TestMethod]
        public void SearchforChannelTest()
        {
            var repository = new DiscussionRepository(ForumContext.Object);

            Assert.IsNotNull(repository, "Ошибка создани репризитория!");
            var channel = new Channel() { Id = 1 };

            var allAnswers = repository.SearchforChannel(channel);

            Assert.IsNotNull(allAnswers, "Ошибка метода GetAll");
            Assert.AreEqual(3, allAnswers.Count());
        }
    }
}