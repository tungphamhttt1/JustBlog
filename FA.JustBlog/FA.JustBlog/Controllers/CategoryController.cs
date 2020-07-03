using AutoMapper;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Models.Models;
using FA.JustBlog.Service.Services;
using FA.JustBlog.ViewModels;
using PagedList;
using System.Linq;
using System.Web.Mvc;

namespace FA.JustBlog.Controllers
{
    public partial class CategoryController : Controller
    {
        private ICategoryService _categoryService;
        static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult DisplayCategory()
        {
            var listCategory = _categoryService.GetAll();
            return PartialView("DisplayCategory", listCategory);
        }
    }
    public partial class CategoryController: Controller
    {
        //class slove CRUD Category
        public ActionResult ShowCategory(int? page)
        {
            var listCategory = _categoryService.GetAll();

            // 1. Tham số int? dùng để thể hiện null và kiểu int
            // page có thể có giá trị là null và kiểu int.

            // 2. Nếu page = null thì đặt lại là 1.
            if (page == null) page = 1;

            // 3. Tạo truy vấn, lưu ý phải sắp xếp theo trường nào đó, ví dụ OrderBy
            // theo LinkID mới có thể phân trang.
            var links = (from l in listCategory
                         select l).OrderBy(x => x.Id);

            // 4. Tạo kích thước trang (pageSize) hay là số Link hiển thị trên 1 trang
            int pageSize = 3;

            // 4.1 Toán tử ?? trong C# mô tả nếu page khác null thì lấy giá trị page, còn
            // nếu page = null thì lấy giá trị 1 cho biến pageNumber.
            int pageNumber = (page ?? 1);

            // 5. Trả về các Link được phân trang theo kích thước và số trang.
            return View(links.ToPagedList(pageNumber, pageSize));
        }


        [HttpPost]
        [RequireAuthorizeFront(Roles = "Blog Owner, Admin")]
        public ActionResult Delete(int categoryId)
        {
            _categoryService.Delete(categoryId);
            // Write Log delete
            log.Info(User.Identity.Name.Split('@')[0] + " edit category with Id = " + categoryId);
            return RedirectToAction("ShowCategory");
        }


        [RequireAuthorizeFront(Roles = "Blog Owner,Admin")]
        public ActionResult AddCategory()
        {
            var categoryEditViewModel = new CategoryEditViewModels();

            return View(categoryEditViewModel);
        }

        [RequireAuthorizeFront(Roles = "Blog Owner, Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult AddCategory(CategoryEditViewModels categoryEditViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(categoryEditViewModel);
            }

            var category = Mapper.Map<Category>(categoryEditViewModel);

            _categoryService.Create(category);
            log.Info(User.Identity.Name.Split('@')[0] + " add category with Id = " + categoryEditViewModel.Id);
            return RedirectToAction("ShowCategory");
        }

        [RequireAuthorizeFront(Roles = "Blog Owner, Admin")]
        public ActionResult EditCategory(int categoryId)
        {
            var category = _categoryService.GetById(categoryId);

            var categoryEditViewModel = Mapper.Map<CategoryEditViewModels>(category);

            return View(categoryEditViewModel);
        }

        [RequireAuthorizeFront(Roles = "Blog Owner, Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult EditCategory(CategoryEditViewModels categoryEditViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(categoryEditViewModel);
            }
                
            var category = Mapper.Map<Category>(categoryEditViewModel);
            _categoryService.Update(category);
            log.Info(User.Identity.Name.Split('@')[0] + " edit category with Id = " + categoryEditViewModel.Id);
            return RedirectToAction("ShowCategory");
        }
    }

}