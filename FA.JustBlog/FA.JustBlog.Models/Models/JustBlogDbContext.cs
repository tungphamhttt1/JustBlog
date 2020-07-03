using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
namespace FA.JustBlog.Core.Models
{
    public class JustBlogDbContext : IdentityDbContext<User>
    {
        public JustBlogDbContext()
            : base("JustBlogConn", throwIfV1Schema: false)
        {
        }

        static JustBlogDbContext()
        {
            // Set the database initializer which is run once during application start
            // This seeds the database with admin user credentials and admin role
            Database.SetInitializer<JustBlogDbContext>(new JustBlogDbInitializer());
        }

        public static JustBlogDbContext Create()
        {
            return new JustBlogDbContext();
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserRoles");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogins");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaims");

            modelBuilder.Entity<Post>()
               .HasMany<Tag>(p => p.Tags)
               .WithMany(t => t.Posts)
               .Map(PostTagMaps =>
               {
                   PostTagMaps.MapLeftKey("PostId")
                              .MapRightKey("TagId")
                              .ToTable("PostTags")
                              ;
               });
        }

    }
}