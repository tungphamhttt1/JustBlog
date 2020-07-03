
using Fa.JustBlog.Service.EntityService;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repositories;
using FA.JustBlog.Core.UnitOfWork;


namespace FA.JustBlog.Service.Services
{
    public class TagService: EntityService<Tag>, ITagService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITagRepository _tagRepository;
        public TagService(IUnitOfWork unitOfWork, ITagRepository tagRepository):base(unitOfWork, tagRepository)
        {
            _unitOfWork = unitOfWork;
            _tagRepository = tagRepository;
        }
    }
}
