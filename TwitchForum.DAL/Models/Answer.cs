using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchForum.DAL.Models
{
    public class Answer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Text { get; set; }
        public string UserId { get; set; }

        [Required]
        public User Sender { get; set; }

        public int? DiscussionId { get; set; }
        public Discussion Discussion { get; set; }
    }
}