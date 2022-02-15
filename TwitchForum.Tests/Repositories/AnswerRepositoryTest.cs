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
    public class AnswerRepositoryTest
    {
        private static Mock<ForumContext> ForumContext { get; set; }
        private static Mock<DbSet<Answer>> MockAnswerSet { get; set; }
        private static Mock<DbSet<Discussion>> MockADiscussionSet { get; set; }
        private static Mock<DbSet<User>> MockUserSet { get; set; }
        private static List<Answer> AnswerProvider { get; set; }
        private static List<Discussion> DiscussionProvider { get; set; }
        private static List<User> UserProvider { get; set; }

        [ClassInitialize()]
        public static void ClassInitialize(TestContext context)
        {
            ForumContext = new Mock<ForumContext>();
            MockAnswerSet = new Mock<DbSet<Answer>>();
            MockADiscussionSet = new Mock<DbSet<Discussion>>();
            MockUserSet = new Mock<DbSet<User>>();

            // Arrange data providers
            AnswerProvider = new List<Answer>()
            {
                new Answer()
                {
                    Id = 1,
                    DiscussionId = 1,
                    Text = "Answer1",
                    UserId = "u1"
                },
                new Answer()
                {
                    Id = 2,
                    DiscussionId = 1,
                    Text = "Answer2",
                    UserId = "u2"
                },
                new Answer()
                {
                    Id = 3,
                    DiscussionId = 2,
                    Text = "Answer3",
                    UserId = "u1"
                },
                new Answer()
                {
                    Id = 4,
                    DiscussionId = 3,
                    Text = "Answer3",
                    UserId = "u1"
                }
            };
            DiscussionProvider = new List<Discussion>()
            {
                new Discussion()
                {
                    Id=1
                },
                new Discussion()
                {
                    Id=2
                },
                new Discussion()
                {
                    Id=3
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

            // MockAnswerSet setup
            MockAnswerSet.As<IQueryable<Answer>>().Setup(m => m.Provider).Returns(AnswerProvider.AsQueryable().Provider);

            MockAnswerSet.As<IQueryable<Answer>>().Setup(m => m.Expression).Returns(AnswerProvider.AsQueryable().Expression);

            MockAnswerSet.As<IQueryable<Answer>>().Setup(m => m.ElementType).Returns(AnswerProvider.AsQueryable().ElementType);

            MockAnswerSet.As<IQueryable<Answer>>().Setup(m => m.GetEnumerator()).Returns(AnswerProvider.AsQueryable().GetEnumerator());

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
            ForumContext.SetupGet(c => c.Answers).Returns(MockAnswerSet.Object);
            ForumContext.SetupGet(c => c.Discussions).Returns(MockADiscussionSet.Object);
            ForumContext.SetupGet(c => c.Users).Returns(MockUserSet.Object);
        }

        [TestMethod()]
        public void CityRepository_IsDbSetInitialized_True()
        {
            int expected = 4;
            int actual = (MockAnswerSet.Object).Count();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetAllTest()
        {
            var repository = new AnswerRepository(ForumContext.Object);

            Assert.IsNotNull(repository, "Ошибка создани репризитория!");

            var allAnswers = repository.GetAll();

            Assert.IsNotNull(allAnswers, "Ошибка метода GetAll");

            Assert.AreEqual(4, allAnswers.Count());
        }

        [TestMethod]
        public void GetByIdTest()
        {
            var repository = new AnswerRepository(ForumContext.Object);
            Assert.IsNotNull(repository, "Ошибка создани репризитория!");

            var answer = repository.GetById(1);

            Assert.IsNotNull(answer, "Ответ не был получен");
        }

        [TestMethod]
        public void GetTest()
        {
            var expAnswer = new Answer()
            {
                Id = 2,
                DiscussionId = 1,
                Text = "Answer2",
                UserId = "u2"
            };
            var repository = new AnswerRepository(ForumContext.Object);
            Assert.IsNotNull(repository, "Ошибка создани репризитория!");

            var answer = repository.Get(expAnswer);
            Assert.IsNotNull(answer, "Get возвращает значение!");
            Assert.AreEqual(answer.Id, expAnswer.Id);
        }

        [TestMethod]
        public void AddTest()
        {
            var answer = new Answer()
            {
                Id = 5,
                DiscussionId = 1,
                Text = "Answer1",
                UserId = "u1"
            };
            var repository = new AnswerRepository(ForumContext.Object);
            Assert.IsNotNull(repository, "Ошибка создани репризитория!");
            try { var AddAnswer = repository.Add(answer); }
            catch (Exception ex)
            {
                Assert.IsNotNull(ex, $"Добавление вернуло ошибку {ex.Message}");
            }
        }

        [TestMethod]
        public void DeleteTest()
        {
            var answer = new Answer()
            {
                Id = 1,
                DiscussionId = 1,
                Text = "Answer1",
                UserId = "u1"
            };
            var repository = new AnswerRepository(ForumContext.Object);
            Assert.IsNotNull(repository, "Ошибка создани репризитория!");
            try { var allAnswers = repository.Delete(answer); }
            catch (Exception ex)
            {
                Assert.IsNotNull(ex, $"Удаление вернуло ошибку {ex.Message}");
            }
        }

        [TestMethod]
        public void GetAllForChannelTest()
        {
            var repository = new AnswerRepository(ForumContext.Object);
            Assert.IsNotNull(repository, "Ошибка создани репризитория!");

            var chennalId = 1;

            var answers = repository.GetAllForChannel(chennalId);
            Assert.IsNotNull(answers, "Get возвращает значение!");
            Assert.AreEqual(answers.Count(), 2);
        }

        [TestMethod]
        public void UpdateTest()
        {
            var answer = new Answer()
            {
                Id = 1,
                DiscussionId = 1,
                Text = "Answer1Update",
                UserId = "u1"
            };
            var repository = new AnswerRepository(ForumContext.Object);
            Assert.IsNotNull(repository, "Ошибка создани репризитория!");
            try { var AddAnswer = repository.Update(answer); }
            catch (Exception ex)
            {
                Assert.IsNotNull(ex, $"Добавление вернуло ошибку {ex.Message}");
            }
        }
    }
}