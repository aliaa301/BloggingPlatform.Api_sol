using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloggingPlatform.Data.Entities
{
    public class Follower
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int FollowerId { get; set; }
        public User FollowerUser { get; set; }
    }
}
