
using AutoMapper;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Models.Models;
using FA.JustBlog.Service.Services;
using FA.JustBlog.ViewModels;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace FA.JustBlog.Controllers
{
    public partial class PostController : Controller
    {
        static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public IPostService _postService;
        public ICategoryService _categoryService;
        public ITagService _tagService;
        public PostController(IPostService postService, ICategoryService categoryService, ITagService tagService)
        {
            _postService = postService;
            _categoryService = categoryService;
            _tagService = tagService;
        }
        public ActionResult Index()
        {
            var allPosts = _postService.GetAll();
            return View(allPosts);
        }

        [ChildActionOnly]
        public ActionResult LastestPosts()
        {
            var lastestPosts = _postService.GetAll().OrderBy(x => x.PostedOn).Take(10).OrderByDescending(x => x.PostedOn).ToList();
            ViewBag.PartialTitle = "Lastest Posts";
            return PartialView("_ListPosts", lastestPosts);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var postDetail = _postService.GetById(id);


            return View(postDetail);
        }

        public ActionResult MostViewedPosts()
        {
            var mostViewPosts = _postService.GetMostViewedPost(5).ToList();
            ViewBag.PartialTitle = "Most View Posts";
            return PartialView("_ListPosts", mostViewPosts);
        }
    }

    public partial class PostController : Controller
    {
        // class CRUD Post 
        public ActionResult DisplayListPost(int? page)
        {
            var listPosts = _postService.GetAll();
            var listPostModels = AutoMapper.Mapper.Map<IEnumerable<PostViewModels>>(listPosts);

            // 1. Tham số int? dùng để thể hiện null và kiểu int
            // page có thể có giá trị là null và kiểu int.

            // 2. Nếu page = null thì đặt lại là 1.
            if (page == null) page = 1;

            // 3. Tạo truy vấn, lưu ý phải sắp xếp theo trường nào đó, ví dụ OrderBy
            // theo LinkID mới có thể phân trang.
            var links = (from l in listPostModels
                         select l).OrderBy(x => x.Id);

            // 4. Tạo kích thước trang (pageSize) hay là số Link hiển thị trên 1 trang
            int pageSize = 10;

            // 4.1 Toán tử ?? trong C# mô tả nếu page khác null thì lấy giá trị page, còn
            // nếu page = null thì lấy giá trị 1 cho biến pageNumber.
            int pageNumber = (page ?? 1);

            // 5. Trả về các Link được phân trang theo kích thước và số trang.
            return View(links.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult AddPost()
        {

            return View();
        }


        [RequireAuthorizeFront(Roles = "Blog Owner")]
        [HttpPost]
        public ActionResult Delete(int id)
        {
            _postService.Delete(id);
            // Write Log Delete
            log.Info(User.Identity.Name.Split('@')[0] + " Delete post with Id = " + id);
            return RedirectToAction("DisplayListPost");
        }

        [RequireAuthorizeFront(Roles = "Blog Owner")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult AddPost(PostViewModels postViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(postViewModel);
            }

            var post = Mapper.Map<Post>(postViewModel);

            _postService.Create(post);
            // Write Log Add
            log.Info(User.Identity.Name.Split('@')[0] + " add post with Id = " + post.Id);
            return RedirectToAction("DisplayListPost");
        }
        [RequireAuthorizeFront(Roles = "Blog Owner")]
        public ActionResult EditPost(int id)
        {
            var post = _postService.GetById(id);
            var categoryList = _categoryService.GetAll();
            SelectList list = new SelectList(categoryList, "Id", "Name");
            ViewBag.categories = list;

            var tagsListSelected = _postService.GetTagsByPost(id);
            SelectList listTags = new SelectList(tagsListSelected, "Id", "Name");
            ViewBag.tags = listTags;

            var tagsAll = _tagService.GetAll();
            ViewBag.tagAll = tagsAll;
            
            return View(post);
        }

        [RequireAuthorizeFront(Roles = "Blog Owner")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult EditPost(Post post, FormCollection formCollection)
        {
            if (!ModelState.IsValid)
            {
                return View(post);
            }
            var oldpost = _postService.GetById(post.Id);
            oldpost.Modified = post.Modified;
            oldpost.PostedOn = post.PostedOn;
            oldpost.Published = post.Published;
            oldpost.RateCount = post.RateCount;
            oldpost.ShortDescription = post.ShortDescription;
            oldpost.Title = post.Title;
            oldpost.UrlSlug = post.UrlSlug;
            oldpost.ViewCount = post.ViewCount;
            oldpost.Category = post.Category;

            oldpost.Tags.Clear();
            _postService.Update(oldpost);
            string[] arrayIdTags = formCollection["states[]"].ToString().Split(',');

            var tags = new List<Tag>();
            foreach (var item in arrayIdTags.ToList())
            {
                tags.Add(_tagService.GetById(Int16.Parse(item)));
            }
            oldpost.Tags = tags;
            _postService.Update(oldpost);

            // Write Log Edit
            log.Info(User.Identity.Name.Split('@')[0] + " edit post with Id = " + post.Id);

            return RedirectToAction("DisplayListPost");
        }
    }
}