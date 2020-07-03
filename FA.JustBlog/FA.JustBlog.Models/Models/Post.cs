using FA.JustBlog.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FA.JustBlog.Core.Models
{
    public class Post : BaseEntity
    {
       public Post()
        {
            Tags = new HashSet<Tag>();
        }
       
        [Required(ErrorMessage = "This {0} must be required")]
        [StringLength(255, ErrorMessage = "The {0} is less than 255 characters")]
        [DisplayName("Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "The {0} must be required")]
        [StringLength(500, ErrorMessage = "The {0} is less than 500 characters")]
        public string ShortDescription { get; set; }

        [Required(ErrorMessage ="This {0} must be required")]
        [StringLength(5000,ErrorMessage ="The {0} is less than 5000 characters")]
        [DisplayName("Post content")]
        public string PostContent { get; set; }

        [DisplayName("Url Slug")]
        public string UrlSlug { get; set; }

        public bool Published { get; set; }

        public DateTime PostedOn { get; set; } = DateTime.Now;

        public DateTime Modified { get; set; } 
        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public int? ViewCount { get; set; }
        public int? RateCount { get; set; }
        public int? TotalRate { get; set; }

        [NotMapped]
        public decimal Rate
        {
            get
            {
                if(RateCount == null || RateCount == 0)
                {
                    return 0;
                }
                return Math.Round((decimal)TotalRate.Value / RateCount.Value, 2);
            }
        }
    }


}
