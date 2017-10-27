using VTube.Core.Repositories;

namespace VTube.Core
{
    public interface IUnitOfWork
    {
        IVideoRepository Videos { get; }
        void Complete();
    }
}