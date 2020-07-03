using System.ComponentModel.DataAnnotations;

namespace FA.JustBlog
{
    public class TagEditViewModels
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The {0} must be required")]
        [StringLength(50, ErrorMessage = "The {0} is less than {1} characters")]
        [Display(Name = "Tag name")]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}