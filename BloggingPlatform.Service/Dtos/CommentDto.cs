using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloggingPlatform.Service.Dtos
{
    public class CommentDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string CommenterName { get; set; }
        [Required]
        [EmailAddress]
        public string CommenterEmail { get; set; }
        public string Text { get; set; }
        public int BlogPostId { get; set; }
    }
}
