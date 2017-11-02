using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VTube.Core.Models;
using VTube.Core.Repositories;

namespace VTube.Persistence.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly IApplicationDbContext _context;

        public CommentRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public Comment Get(int id)
        {
            return _context.Comments
                .SingleOrDefault(c => c.Id == id);
        }

        public void Add(Comment comment)
        {
            _context.Comments.Add(comment);
        }

        public IEnumerable<Comment> GetAll()
        {
            return _context.Comments.ToList();
        }
    }
}