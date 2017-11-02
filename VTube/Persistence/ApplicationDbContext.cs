using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using VTube.Core.Models;
using VTube.Persistence.EntityConfigurations;

namespace VTube.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {
        public DbSet<Video> Videos { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new VideoConfigration());
            modelBuilder.Configurations.Add(new CommentConfigration());

            base.OnModelCreating(modelBuilder);
        }
    }
}