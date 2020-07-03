using FA.JustBlog.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FA.JustBlog.Core.Models
{
    public class Tag : BaseEntity
    {
      public  Tag() 
        {
            Posts = new HashSet<Post>();
        }
        [Required(ErrorMessage = "The {0} must be required")]
        [StringLength(50, ErrorMessage = "The {0} is less than {1} characters")]
        [Display(Name ="Tag name")]
        public string Name { get; set; }

        public string UrlSlug { get; set; }
        public string Description { get; set; }
        [DefaultValue(0)]
        //public int Count { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }


}
