using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FA.JustBlog.Modules
{
    public class ServiceModule:Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterAssemblyTypes(System.Reflection.Assembly.Load("FA.JustBlog.Service"))

                      .Where(t => t.Name.EndsWith("Service"))

                      .AsImplementedInterfaces()

                      .InstancePerLifetimeScope();

        }
    }
}