using System.Data.Entity;
using VTube.Core.Models;

namespace VTube.Persistence
{
    public interface IApplicationDbContext
    {
        DbSet<Video> Videos { get; set; }
    }
}