using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

    }
}