using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchForum.DAL.Models
{
    public class Channel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }
        public string OwnerName { get; set; }
        public int Followers { get; set; }

        public ICollection<Discussion> Discussions { get; set; }

        public Channel()
        {
            Discussions = new List<Discussion>();
        }
    }
}