using FA.JustBlog.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FA.JustBlog.Core.Models
{
    public class Category : BaseEntity
    {
        [Required(ErrorMessage ="The Category Name must be required")]
        [StringLength(255,ErrorMessage ="The {0} is less than {1} characters")]
        [Display(Name ="Category name")]
        public string Name { get; set; }

        [Display(Name ="Url slug")]
        public string UrlSlug { get; set; }

        public string Description { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
