using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.IO;

namespace FA.JustBlog.Core.Models
{
    // This is useful if you do not want to tear down the database each time you run the application.
    // public class ApplicationDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    // This example shows you how to create a new database if the Model changes
    public class JustBlogDbInitializer : CreateDatabaseIfNotExists<JustBlogDbContext>
    {
        protected override void Seed(JustBlogDbContext context)
        {
            InitializeIdentity(context);
            base.Seed(context);
            SeedData(context);
        }

        private static void SeedData(JustBlogDbContext context)
        {
            string pathSqlDataFile = System.AppDomain.CurrentDomain.BaseDirectory.ToString() + "App_Data";
            context.Database.ExecuteSqlCommand(File.ReadAllText(pathSqlDataFile + "\\justblog.sql"));
        }

        //Create User=Admin@Admin.com with password=Admin@123456 in the Admin role        
        public static void InitializeIdentity(JustBlogDbContext db)
        {
            var userManager = new UserManager<User>(new UserStore<User>(db));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            const string name = "admin@example.com";
            const string password = "Admin@123456";
            const string roleName = "Blog Owner";

            //Create Role Admin if it does not exist
            var role = roleManager.FindByName(roleName);
            if (role == null)
            {
                role = new IdentityRole(roleName);
                var roleResult = roleManager.Create(role);
            }

            //Create more 3 roles: User, Contributor, Blog Owner
            var roleUser = new IdentityRole("User");
            roleManager.Create(roleUser);
            var roleContributor = new IdentityRole("Contributor");
            roleManager.Create(roleContributor);
            var roleBlogOwner = new IdentityRole("Blog Owner");
            roleManager.Create(roleBlogOwner);

            var user = userManager.FindByName(name);
            if (user == null)
            {
                user = new User { UserName = name, Email = name };
                var result = userManager.Create(user, password);
                result = userManager.SetLockoutEnabled(user.Id, false);
            }

            // Add user admin to Role Admin if not already added
            var rolesForUser = userManager.GetRoles(user.Id);
            if (!rolesForUser.Contains(role.Name))
            {
                var result = userManager.AddToRole(user.Id, role.Name);
            }

            
        }
    }
}
