using Microsoft.AspNet.Identity;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using TwitchForum;
using TwitchForum.Controllers;

using System.Threading.Tasks;
using TwitchForum.DAL.AcountsServices;
using TwitchForum.DAL.Models;
using TwitchForum.DAL;
using System.Data.Entity;
using TwitchForum.DAL.Repositories;
using TwitchForum.DAL.Repositories.Interfaces;
using TwitchForum.DAL.UoW;
using TwitchForum.BLL.Services.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TwitchForum.DAL.ViewModels;
using PagedList;

namespace TwitchForum.Tests.Controllers
{
    [TestClass]
    public class MainControllerTest
    {
        private IEnumerable<Message> GetTestMessanges()
        {
            return new List<Message>() {  new Message() { Id=1,   Sender = new User(), Text = "Парни, кеф на спирит 1.86!", SendingTime = new DateTime(2022, 1, 25, 12, 54, 00) },
              new Message() { Id=2, Sender = new User(), Text = "спс",  SendingTime = new DateTime(2022, 1, 25, 12, 54, 30) },
              new Message() {  Id=3,Sender = new User(), Text = "А если луз?",  SendingTime = new DateTime(2022, 1, 25, 12, 55, 12) },
              new Message() {  Id=4,Sender = new User(), Text = "Анриал",  SendingTime = new DateTime(2022, 1, 25, 12, 55, 46) },
                new Message() { Id=5, Sender = new User(), Text = "Спам!", SendingTime = new DateTime(2022, 1, 25, 23, 54, 00) },
                new Message() { Id=6, Sender = new User(), Text = "Спам!", SendingTime = new DateTime(2022, 1, 25, 23, 54, 5) },
                new Message() { Id=7, Sender = new User(), Text = "Спам!",  SendingTime = new DateTime(2022, 1, 25, 23, 54, 7) },
                new Message() { Id=8, Sender = new User(), Text = "Спам!",  SendingTime = new DateTime(2022, 1, 25, 23, 54, 9) },
                new Message() { Id=9, Sender = new User(), Text = "Спам!",  SendingTime = new DateTime(2022, 1, 25, 23, 54, 10) } };
        }

        private IEnumerable<Channel> GetTestChannels()
        {
            return new List<Channel>() { new Channel() { Name = "Ninja", OwnerName = "Richard Blevins", Followers = 17400000 },
                   new Channel() { Name = "auronplay", OwnerName = "Raúl Alvarez", Followers = 11500000, },
                   new Channel() { Name = "Rubius", OwnerName = "Rubén Doblas", Followers = 11000000 },
                   new Channel() { Name = "Tfue", OwnerName = "Turner Tenney", Followers = 10800000 },
                   new Channel() { Name = "shroud", OwnerName = "Michael Grzesiek", Followers = 9800000 } };
        }

        [TestMethod]
        public void Index()
        {
            // Arrange
            var mockUserMen = new Mock<ApplicationUserManager>(new Mock<IUserStore<User>>().Object);
            var mockMessService = new Mock<IMessagesService>();
            var mockChannelService = new Mock<IChannelService>();
            var mockUserService = new Mock<IUserService>();
            mockMessService.Setup(repo => repo.GetAll()).Returns(GetTestMessanges());
            mockChannelService.Setup(repo => repo.GetN(5)).Returns(GetTestChannels());

            var controller = new MainController(mockUserMen.Object, mockMessService.Object, mockUserService.Object, mockChannelService.Object);

            // Act
            var result = controller.Index(1);

            // Assert
            Assert.IsNotNull(result);
            ViewResult viewResult = controller.Index(1) as ViewResult;
            Assert.IsNotNull(viewResult);
            Assert.IsInstanceOfType(viewResult.Model, typeof(MainViewModel));
        }
    }
}