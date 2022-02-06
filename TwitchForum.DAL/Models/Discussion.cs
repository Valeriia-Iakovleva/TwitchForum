using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchForum.DAL.Models
{
    public class Discussion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Title { get; set; }
        public string Text { get; set; }

        public int Rating { get; set; } = 0;
        public DateTime PublicationTime { get; set; } = DateTime.Now;
        public int? ChannelId { get; set; }
        public Channel Channel { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }
        public ICollection<Answer> Answers { get; set; }

        public Discussion()
        {
            Answers = new List<Answer>();
        }
    }
}