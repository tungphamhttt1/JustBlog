using Autofac;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.UnitOfWork;
using System.Data.Entity;

namespace FA.JustBlog.Modules
{
    public class EFModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new RepositoryModule());

            builder.RegisterType(typeof(JustBlogDbContext)).As(typeof(DbContext)).InstancePerLifetimeScope();

            builder.RegisterType(typeof(UnitOfWork)).As(typeof(IUnitOfWork)).InstancePerRequest();

        }
    }
}