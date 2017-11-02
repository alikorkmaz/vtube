using System.Collections.Generic;
using VTube.Core.Models;

namespace VTube.Core.Repositories
{
    public interface ICommentRepository
    {
        Comment Get(int id);
        void Add(Comment comment);
        IEnumerable<Comment> GetAll();
    }
}
