using Autofac;
using Autofac.Integration.Mvc;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repositories;
using FA.JustBlog.Repository.Repositories;
using System.Web.Mvc;

namespace FA.JustBlog.App_Start
{
    public class ContainerConfig
    {
        public static void RegisterContainer()
        {
            var builder = new ContainerBuilder();
            // Register your MVC controllers. (MvcApplication is the name of
            // the class in Global.asax.)
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<PostRepository>().As<IPostRepository>().WithParameter(new TypedParameter(typeof(JustBlogDbContext), new JustBlogDbContext()));
            builder.RegisterType<TagRepository>().As<ITagRepository>().WithParameter(new TypedParameter(typeof(JustBlogDbContext), new JustBlogDbContext()));
            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>().WithParameter(new TypedParameter(typeof(JustBlogDbContext), new JustBlogDbContext()));
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

          
        }
    }
}