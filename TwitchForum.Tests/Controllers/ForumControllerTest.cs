using Microsoft.AspNet.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using TwitchForum.BLL.Services.Interfaces;
using TwitchForum.Controllers;
using TwitchForum.DAL;
using TwitchForum.DAL.Models;

namespace TwitchForum.Tests.Controllers
{
    [TestClass]
    public class ForumControllerTest
    {
        private IEnumerable<Discussion> GetTestDiscussions()
        {
            return new List<Discussion>()
            {
                 new Discussion() { Id = 22, Title = "Переход на Mixer", Channel = new Channel(), ChannelId = 1, Text = @"Стример Тайлер Ninja Блевинс рассказал, как ему далось возвращение с Mixer на Twitch, а также прокомментировал повышенное внимание к своей персоне. По словам Ninja, в последнее время негатива в его сторону стало значительно больше. Об этом Блевинс рассказал в интервью The New York Times.
                          Ninja также отметил, что аудитория Twitch стала более агрессивной, в особенности ему надоедают несовершеннолетние стримеры.
                          В 2019 году Ninja покинул Twitch и подписал контракт с Mixer, созданной Microsoft. До ухода он был самым популярным стримером на платформе с аудиторией в 14,5 млн фолловеров и 437 млн просмотров. В 2020 году Mixer объявила о закрытии, а Блевинс вернулся на Twitch, подписав с компанией многолетний контракт", Rating = 1500, PublicationTime = new DateTime(2019, 2, 5, 17, 46, 00), User = new User(), UserId = "1" },
                new Discussion() { Id = 23, Title = "Ibai и NOBRU среди лучших — итоги и статистика крупнейшей киберспортивной премии Esports Awards 2021", Channel = new Channel(), ChannelId = 2, Text = @"В минувшие выходные в Арлингтоне, Техас, завершилась одна из самых престижных премий в индустрии киберспорта и гейминга — Esports Awards 2021. В этом году мероприятие транслировалось не только организаторами, но и стримерами Twitch, что позволило ему собрать рекордную аудиторию. Streams Charts подводит итоги ивента и рассказывает о его зрительской статистике.", Rating = 1000, PublicationTime = new DateTime(2021, 11, 16, 00, 00, 00), User = new User(), UserId = "1" },
                new Discussion() { Id = 24, Title = "киберспортивный клуб KOI Squad ", Channel = new Channel(), ChannelId = 3, Text = @"Футболист Жерар Пике вместе с популярным стримером #Ibai открыли киберспортивный клуб KOI Squad с составом по League of Legends 🎮

                          Презентация клуба состоялась в Барселоне, частью которой стал шоуматч между KOI SQUAD и Karmine Corp по Лиге Легенд. В состав новоиспечённой команды вошли: #SLT, #Koldo, #Hatrixx, #Rafitta, #Seaz и #Falco в качестве тренера.

                          Клуб также подписал 12 испаноязычных контент-мейкеров.", Rating = 500, PublicationTime = new DateTime(2021,2,5,17,46,0) } };
        }

        [TestMethod]
        public void Index()
        {
            var mockUserMen = new Mock<ApplicationUserManager>(new Mock<IUserStore<User>>().Object);
            var mockForumService = new Mock<IForumService>();
            var mockAnswerService = new Mock<IAnswerService>();
            var mockMessService = new Mock<IMessagesService>();
            var mockChannelService = new Mock<IChannelService>();
            var mockUserService = new Mock<IUserService>();
            mockForumService.Setup(x => x.GetAll()).Returns(GetTestDiscussions());
            var controller = new ForumController(mockUserMen.Object, mockForumService.Object, mockAnswerService.Object, mockChannelService.Object, mockUserService.Object);

            // Act
            var result = controller.Index();

            // Assert
            Assert.IsNotNull(result);
            ViewResult viewResult = result as ViewResult;
            Assert.IsNotNull(viewResult);
            Assert.IsInstanceOfType(viewResult.Model, typeof(IEnumerable<Discussion>));
        }
    }
}