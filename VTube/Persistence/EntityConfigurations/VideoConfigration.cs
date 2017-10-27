using System.Data.Entity.ModelConfiguration;
using VTube.Core.Models;

namespace VTube.Persistence.EntityConfigurations
{
    public class VideoConfigration : EntityTypeConfiguration<Video>
    {
        public VideoConfigration()
        {
            Property(v => v.Description)
                .HasMaxLength(1024);

            Property(v => v.Path)
                .IsRequired();

            Property(v => v.Title)
                .IsRequired()
                .HasMaxLength(64);

            Property(v => v.UserId)
                .IsRequired();
        }
    }
}