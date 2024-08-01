using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloggingPlatform.Service.Dtos
{
    public class FollowerDto
    {
        public int UserId { get; set; }
        public int FollowerId { get; set; }
    }
}
