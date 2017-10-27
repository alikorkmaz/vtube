using VTube.Core.Models;

namespace VTube.Core.Repositories
{
    public interface IVideoRepository
    {
        Video Get(int id);
        void Add(Video video);
    }
}