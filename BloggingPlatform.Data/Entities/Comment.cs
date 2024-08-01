using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloggingPlatform.Data.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string CommenterName { get; set; }
        public string CommenterEmail { get; set; }
        public string Text { get; set; }
        public int BlogPostId { get; set; }
        public BlogPost BlogPost { get; set; }
    }
}
