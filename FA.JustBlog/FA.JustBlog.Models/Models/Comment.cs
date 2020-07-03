using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Models
{
    public class Comment
    {
        public int CommentId { get; set; }

        [Required(ErrorMessage = "The  {0} must be required")]
        [StringLength(1000, ErrorMessage = "The {0} is less than {1} characters")]
        [DisplayName("Name")]
        public string Name { get; set; }

        [DisplayName("Email")]
        public string Email { get; set; }
        [DisplayName("Comment header")]
        public string CommentHeader  { get; set; }
        public string CommentText { get; set; }
        public DateTime CommentTime { get; set; }

        [ForeignKey("Post")]
        public int PostId { get; set; }
        public virtual Post Post { get; set; }
    }
}
