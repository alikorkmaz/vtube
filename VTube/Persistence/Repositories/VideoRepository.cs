using System.Collections.Generic;
using System.Linq;
using VTube.Core.Models;
using VTube.Core.Repositories;

namespace VTube.Persistence.Repositories
{
    public class VideoRepository : IVideoRepository
    {
        private readonly IApplicationDbContext _context;

        public VideoRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public Video Get(int id)
        {
            return _context.Videos
                .SingleOrDefault(v => v.Id == id);
        }

        public void Add(Video video)
        {
            _context.Videos.Add(video);
        }

        public IEnumerable<Video> GetAll()
        {
            return _context.Videos.ToList();
        }
    }
}