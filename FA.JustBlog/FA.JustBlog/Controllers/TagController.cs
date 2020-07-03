using AutoMapper;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Service.Services;
using PagedList;
using System.Linq;
using System.Web.Mvc;

namespace FA.JustBlog.Controllers
{
    public partial class TagController : Controller
    {
        private ITagService _tagService;
        static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }
        // GET: Tag
        public ActionResult Index()
        { 
            return View();
        }
    }
    public partial class TagController : Controller
    {
        // Class CRUD Tag
        public ActionResult ShowTags(int? page)
        {
            var listTags = _tagService.GetAll();
            // 1. Tham số int? dùng để thể hiện null và kiểu int
            // page có thể có giá trị là null và kiểu int.

            // 2. Nếu page = null thì đặt lại là 1.
            if (page == null) page = 1;

            // 3. Tạo truy vấn, lưu ý phải sắp xếp theo trường nào đó, ví dụ OrderBy
            // theo LinkID mới có thể phân trang.
            var links = listTags.OrderBy(x => x.Id);

            // 4. Tạo kích thước trang (pageSize) hay là số Link hiển thị trên 1 trang
            int pageSize = 3;

            // 4.1 Toán tử ?? trong C# mô tả nếu page khác null thì lấy giá trị page, còn
            // nếu page = null thì lấy giá trị 1 cho biến pageNumber.
            int pageNumber = (page ?? 1);

            // 5. Trả về các Link được phân trang theo kích thước và số trang.
            return View(links.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Delete(int tagId)
        {
            _tagService.Delete(tagId);
            return RedirectToAction("ShowTags");
        }

        public ActionResult AddTag()
        {
            var tagEditViewModel = new TagEditViewModels();
            return View(tagEditViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult AddTag(TagEditViewModels tagEditViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(tagEditViewModel);
            }

            var tag = Mapper.Map<Tag>(tagEditViewModel);

            _tagService.Create(tag);
            // Write Log Add
            log.Info(User.Identity.Name.Split('@')[0] + " add tag with Id = " + tagEditViewModel.Id);
            return RedirectToAction("ShowTags");
        }

        public ActionResult EditTag(int tagId)
        {
            var tag = _tagService.GetById(tagId);

            var tagEditViewMode = Mapper.Map<TagEditViewModels>(tag);

            return View(tagEditViewMode);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult EditTag(TagEditViewModels tagEditViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(tagEditViewModel);
            }
                
            var tag = Mapper.Map<Tag>(tagEditViewModel);

            _tagService.Update(tag);
            // Write Log Add
            log.Info(User.Identity.Name.Split('@')[0] + " update tag with Id = " + tagEditViewModel.Id);
            return RedirectToAction("ShowTags");
        }
    }
}