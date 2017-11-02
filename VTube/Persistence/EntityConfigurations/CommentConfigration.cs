using System.Data.Entity.ModelConfiguration;
using VTube.Core.Models;

namespace VTube.Persistence.EntityConfigurations
{
    public class CommentConfigration : EntityTypeConfiguration<Comment>
    {
        public CommentConfigration()
        {
            Property(c => c.Text)
                .IsRequired();

            Property(c => c.UserId)
                .IsRequired();

            Property(c => c.VideoId)
                .IsRequired();
        }
    }
}