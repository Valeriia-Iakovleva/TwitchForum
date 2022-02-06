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

            //   var userm = new User() { UserName = "manager", Email = "twitchmanageruser@gmail.com", };
            //   userManager.Create(userm, "Test123456789!");
            //   userManager.AddToRole(userManager.FindByName("manager").Id, "manager");

            //   var userad = new User() { UserName = "administrator3000", Email = "twitchmanageruser@gmail.com", };

            //   userManager.Create(userad, "Test123456789!");
            //   userManager.AddToRole(userManager.FindByName("administrator3000").Id, "admin");

            //   context.Channels.AddOrUpdate(new Channel() { Name = "Ninja", OwnerName = "Richard Blevins", Followers = 17400000 },
            //       new Channel() { Name = "auronplay", OwnerName = "Raúl Alvarez", Followers = 11500000, },
            //       new Channel() { Name = "Rubius", OwnerName = "Rubén Doblas", Followers = 11000000 },
            //       new Channel() { Name = "Tfue", OwnerName = "Turner Tenney", Followers = 10800000 },
            //       new Channel() { Name = "shroud", OwnerName = "Michael Grzesiek", Followers = 9800000 },
            //       new Channel() { Name = "xQcOW", OwnerName = "Félix Lengyel", Followers = 9900000 },
            //       new Channel() { Name = "TheGrefg", OwnerName = "David Cánovas", Followers = 9400000 },
            //       new Channel() { Name = "ibai", OwnerName = "Ibai Llanos", Followers = 92400000 },
            //       new Channel() { Name = "pokimane", OwnerName = "Imane Anys", Followers = 9400000 },
            //       new Channel() { Name = "Myth", OwnerName = "Ali Kabbani", Followers = 7400000 },
            //       new Channel() { Name = "Heelmike", OwnerName = "Michael Peters", Followers = 7400000 },
            //       new Channel() { Name = "Nix", OwnerName = "Alexander Levin", Followers = 175000 }
            //       );
            //   context.SaveChanges();
            context.Discussions.AddOrUpdate(new Discussion() { Id = 21, Title = "Сикрет успеха Ninja", Channel = context.Channels.FirstOrDefault(x => x.Name == "Ninja"), ChannelId = context.Channels.FirstOrDefault(x => x.Name == "Ninja").Id, Text = @"Самый популярный видеоблогер — Пьюдипай, а самый популярный стример — Нинджа. А теперь он один из 100 самых влиятельных людей мира по версии Time. Редактор сайта «Чемпионат» Георгий Ядвидчук рассказывает, как 27-летний стример стал популярным и куда его привел хайп.
                      Как Нинджа стал популярным
                          Когда‑то 27 - летний американец Тайлер Блевинс был профессиональным игроком в Halo 3,
                          а потом самым обычным стримером,
                          в лучшие дни собирал максимум по 10–15 тыс.зрителей и довольствовался этим.Но с появлением игр в жанре королевская битва его популярность начала расти со страшной скоростью,
                          а Fortnite — самая популярная из королевских битв — стала для паренька пропуском в элиту.

                          Окончательно все изменила трансляция с Дрейком — именно из‑за нее имя Нинджи стало доноситься из каждого утюга.Конечно,
                          на стриме с ними еще были Трэвис Скотт и игрок НФЛ ДжуДжу Смит - Шустер,
                          выступающий за «Питтсбург Стилерз»,
                          но многие так и запомнили тот день,
                          когда Дрейк и Нинджа были в Fortnite против всех.Этого хватило,
                          чтобы весь мир сошел с ума за одну ночь,
                          и 15 марта 2018 года на стриминговой платформе Twitch поставили рекорд для личных трансляций.На пике за игрой звезд и стримера,
                          который еще не был в топе,
                          следили 635 тыс.зрителей.", Rating = 1000, PublicationTime = new DateTime(2021, 10, 5, 12, 45, 00), User = userManager.FindByName("administrator3000"), UserId = userManager.FindByName("administrator3000").Id },
                new Discussion() { Id = 22, Title = "Переход на Mixer", Channel = context.Channels.FirstOrDefault(x => x.Name == "Ninja"), ChannelId = context.Channels.FirstOrDefault(x => x.Name == "Ninja").Id, Text = @"Стример Тайлер Ninja Блевинс рассказал, как ему далось возвращение с Mixer на Twitch, а также прокомментировал повышенное внимание к своей персоне. По словам Ninja, в последнее время негатива в его сторону стало значительно больше. Об этом Блевинс рассказал в интервью The New York Times.
                          Ninja также отметил, что аудитория Twitch стала более агрессивной, в особенности ему надоедают несовершеннолетние стримеры.
                          В 2019 году Ninja покинул Twitch и подписал контракт с Mixer, созданной Microsoft. До ухода он был самым популярным стримером на платформе с аудиторией в 14,5 млн фолловеров и 437 млн просмотров. В 2020 году Mixer объявила о закрытии, а Блевинс вернулся на Twitch, подписав с компанией многолетний контракт", Rating = 1500, PublicationTime = new DateTime(2019, 2, 5, 17, 46, 00), User = userManager.FindByName("administrator3000"), UserId = userManager.FindByName("administrator3000").Id },
                new Discussion() { Id = 23, Title = "Ibai и NOBRU среди лучших — итоги и статистика крупнейшей киберспортивной премии Esports Awards 2021", Channel = context.Channels.FirstOrDefault(x => x.Name == "ibai"), ChannelId = context.Channels.FirstOrDefault(x => x.Name == "ibai").Id, Text = @"В минувшие выходные в Арлингтоне, Техас, завершилась одна из самых престижных премий в индустрии киберспорта и гейминга — Esports Awards 2021. В этом году мероприятие транслировалось не только организаторами, но и стримерами Twitch, что позволило ему собрать рекордную аудиторию. Streams Charts подводит итоги ивента и рассказывает о его зрительской статистике.", Rating = 1000, PublicationTime = new DateTime(2021, 11, 16, 00, 00, 00), User = userManager.FindByName("administrator3000"), UserId = userManager.FindByName("administrator3000").Id },
                new Discussion() { Id = 24, Title = "киберспортивный клуб KOI Squad ", Channel = context.Channels.FirstOrDefault(x => x.Name == "ibai"), ChannelId = context.Channels.FirstOrDefault(x => x.Name == "ibai").Id, Text = @"Футболист Жерар Пике вместе с популярным стримером #Ibai открыли киберспортивный клуб KOI Squad с составом по League of Legends 🎮

                          Презентация клуба состоялась в Барселоне, частью которой стал шоуматч между KOI SQUAD и Karmine Corp по Лиге Легенд. В состав новоиспечённой команды вошли: #SLT, #Koldo, #Hatrixx, #Rafitta, #Seaz и #Falco в качестве тренера.

                          Клуб также подписал 12 испаноязычных контент-мейкеров.", Rating = 500, PublicationTime = new DateTime(2021, 11, 20, 12, 45, 00), User = userManager.FindByName("administrator3000"), UserId = userManager.FindByName("administrator3000").Id },
                new Discussion()
                {
                    Id = 25,
                    Title = "TFUE ОН УШЕЛ ИЗ FORTNITE ",
                    Channel = context.Channels.FirstOrDefault(x => x.Name == "Tfue"),
                    ChannelId = context.Channels.FirstOrDefault(x => x.Name == "Tfue").Id,
                    Text = @"Один из самых плодовитых стримеров Twitch - Тернер «Tfue» Тенни - выйти из игры, которая много лет назад помогла ему стать суперзвездой. Многие сразу же подумают о Fortnite: Battle Royale, поскольку она является синонимом названия Tfue. История бывшего игрока FaZe Clan в Fortnite не имеет себе равных. Tfue выигрывал много разных турниров и выступал дольше, чем большинство оригинальных игроков. В конце концов он достиг конца своего путешествия по Fortnite, несмотря на безумные успехи. Последний раз Tfue транслировал Fortnite в августе и не принимал участия в турнирах с июля. Звезда Twitch недавно присоединился к профессиональному игроку в Fortnite Arab's Подкаст о рисках для бренда, где он рассказал, почему ушел из Fortnite.",
                    Rating = 1600,
                    PublicationTime = new DateTime(2021, 10, 27, 16, 20, 00),
                    User = userManager.FindByName("ivall"),
                    UserId = userManager.FindByName("ivall").Id
                });

            context.Answers.AddOrUpdate(new Answer()
            {
                Discussion = context.Discussions.FirstOrDefault(x => x.Title == "Переход на Mixer"),
                Sender = userManager.FindByName("manager"),
                DiscussionId = context.Discussions.FirstOrDefault(x => x.Title == "Переход на Mixer").Id,
                Text = "GGWP",
                UserId = userManager.FindByName("manager").Id
            },
         new Answer()
         {
             Discussion = context.Discussions.FirstOrDefault(x => x.Title == "Сикрет успеха Ninja"),
             Sender = userManager.FindByName("manager"),
             DiscussionId = context.Discussions.FirstOrDefault(x => x.Title == "Сикрет успеха Ninja").Id,
             Text = "Чел просто фрик",
             UserId = userManager.FindByName("manager").Id
         });

            context.Messages.AddOrUpdate(new Message() { Sender = userManager.FindByName("manager"), Text = "Я поймал рошана", SendingTime = new DateTime(2022, 1, 25, 12, 45, 00), UserId = userManager.FindByName("manager").Id },
              new Message() { Sender = userManager.FindByName("ivall"), Text = "Парни, кеф на спирит 1.86!", UserId = userManager.FindByName("ivall").Id, SendingTime = new DateTime(2022, 1, 25, 12, 54, 00) },
              new Message() { Sender = userManager.FindByName("administrator300"), Text = "спс", UserId = userManager.FindByName("ivall").Id, SendingTime = new DateTime(2022, 1, 25, 12, 54, 30) },
              new Message() { Sender = userManager.FindByName("manager"), Text = "А если луз?", UserId = userManager.FindByName("ivall").Id, SendingTime = new DateTime(2022, 1, 25, 12, 55, 12) },
              new Message() { Sender = userManager.FindByName("ivall"), Text = "Анриал", UserId = userManager.FindByName("ivall").Id, SendingTime = new DateTime(2022, 1, 25, 12, 55, 46) },
                new Message() { Sender = userManager.FindByName("ivall"), Text = "Спам!", UserId = userManager.FindByName("ivall").Id, SendingTime = new DateTime(2022, 1, 25, 23, 54, 00) },
                new Message() { Sender = userManager.FindByName("ivall"), Text = "Спам!", UserId = userManager.FindByName("ivall").Id, SendingTime = new DateTime(2022, 1, 25, 23, 54, 5) },
                new Message() { Sender = userManager.FindByName("ivall"), Text = "Спам!", UserId = userManager.FindByName("ivall").Id, SendingTime = new DateTime(2022, 1, 25, 23, 54, 7) },
                new Message() { Sender = userManager.FindByName("ivall"), Text = "Спам!", UserId = userManager.FindByName("ivall").Id, SendingTime = new DateTime(2022, 1, 25, 23, 54, 9) },
                new Message() { Sender = userManager.FindByName("ivall"), Text = "Спам!", UserId = userManager.FindByName("ivall").Id, SendingTime = new DateTime(2022, 1, 25, 23, 54, 10) },
                new Message() { Sender = userManager.FindByName("ivall"), Text = "Спам!", UserId = userManager.FindByName("ivall").Id, SendingTime = new DateTime(2022, 1, 25, 23, 54, 16) },
                new Message() { Sender = userManager.FindByName("ivall"), Text = "Спам86!", UserId = userManager.FindByName("ivall").Id, SendingTime = new DateTime(2022, 1, 25, 23, 54, 18) },
                new Message() { Sender = userManager.FindByName("ivall"), Text = "Спам!", UserId = userManager.FindByName("ivall").Id, SendingTime = new DateTime(2022, 1, 25, 23, 54, 21) },
                new Message() { Sender = userManager.FindByName("ivall"), Text = "Спам!", UserId = userManager.FindByName("ivall").Id, SendingTime = new DateTime(2022, 1, 25, 23, 54, 24) },
                new Message() { Sender = userManager.FindByName("ivall"), Text = "Спам!", UserId = userManager.FindByName("ivall").Id, SendingTime = new DateTime(2022, 1, 25, 23, 54, 27) },
                new Message() { Sender = userManager.FindByName("ivall"), Text = "Спам!", UserId = userManager.FindByName("ivall").Id, SendingTime = new DateTime(2022, 1, 25, 23, 54, 32) },
                new Message() { Sender = userManager.FindByName("ivall"), Text = "Спам!", UserId = userManager.FindByName("ivall").Id, SendingTime = new DateTime(2022, 1, 25, 23, 54, 38) },
                new Message() { Sender = userManager.FindByName("ivall"), Text = "Спам!", UserId = userManager.FindByName("ivall").Id, SendingTime = new DateTime(2022, 1, 25, 23, 54, 42) },
                new Message() { Sender = userManager.FindByName("ivall"), Text = "Спам!", UserId = userManager.FindByName("ivall").Id, SendingTime = new DateTime(2022, 1, 25, 23, 54, 45) });
        }
    }
}