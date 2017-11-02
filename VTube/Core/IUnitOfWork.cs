using VTube.Core.Repositories;

namespace VTube.Core
{
    public interface IUnitOfWork
    {
        IVideoRepository Videos { get; }
        ICommentRepository Comments { get; }
        void Complete();
    }
}