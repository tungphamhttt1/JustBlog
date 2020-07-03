using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FA.JustBlog.ViewModels
{
    public class PostViewModels
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "This {0} must be required")]
        [StringLength(255, ErrorMessage = "The {0} is less than 255 characters")]
        [DisplayName("Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "The {0} must be required")]
        [StringLength(500, ErrorMessage = "The {0} is less than 500 characters")]
        [Display(Name ="Short Description")]
        public string ShortDescription { get; set; }

        public bool Published { get; set; }

        public DateTime PostedOn { get; set; } = DateTime.Now;

        public DateTime Modified { get; set; }
        [ForeignKey("Category")]
 
        public int? TotalRate { get; set; }

    }
}