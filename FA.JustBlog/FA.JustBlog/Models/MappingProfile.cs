using AutoMapper;
using FA.JustBlog.Core.Models;
using FA.JustBlog.ViewModels;

namespace FA.JustBlog.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Bản khai báo các class cần nạp tại đây
            CreateMap<Post, PostViewModels>().ReverseMap();
            CreateMap<Category, CategoryEditViewModels>().ReverseMap();
            CreateMap<Tag, TagEditViewModels>().ReverseMap();
        }
    }
}